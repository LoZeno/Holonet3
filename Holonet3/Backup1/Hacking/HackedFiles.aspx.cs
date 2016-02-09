using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Holonet3.CartellaPersonale;
using DataAccessLayer;
using Holonet3.Messaggi;
using Holonet3.Utilities;
using HolonetWebControls;

namespace Holonet3.Hacking
{
	public partial class HackedFiles : HolonetPage, IFilePersonali, IHackablePage, ICryptable
	{
		public bool ShowEncrypted
		{
			get
			{
				object obj = ViewState["ShowEncrypted"];
				if (obj != null)
				{
					return (bool)obj;
				}
				return true;
			}
			set
			{
				ViewState["ShowEncrypted"] = value;
			}
		}
		protected override void Page_PreInit(object sender, EventArgs e)
		{
			if (Session["TemaHacking"] != null)
			{
				Page.Theme = Session["TemaHacking"].ToString();
			}
			else
			{
				Page.Theme = "TemaBlu";
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			((SiteMaster)this.Page.Master).FindControl("NavigationMenu").Visible = false;
			if (!IsPostBack)
			{
				caricaFiles();
			}
		}

		private void caricaFiles()
		{
			
			listaFilePersonali.Visible = true;
			List<MessaggioSalvato> elenco = new List<MessaggioSalvato>();
			long accountInfranto = (long)Session["AccountInfranto"];
			using (HolonetEntities context = new HolonetEntities())
			{
				var character = (from personaggio in context.Personaggios
								 where personaggio.NumeroPG == accountInfranto
								 select personaggio).First();

				var filesToRead = (from files in context.MessaggioSalvatoes
										where files.NumeroPG == character.NumeroPG
										//where files.Cancellata == false
										select files).OrderByDescending(mexs => mexs.Progressivo);
				foreach (MessaggioSalvato item in filesToRead)
				{
					if (!item.PersonaggioReference.IsLoaded)
					{
						item.PersonaggioReference.Load();
					}
				}
				if (filesToRead.Count() > 0)
				{
					elenco = filesToRead.ToList();
				}
				listaFilePersonali.refCharacter = character;
			}
			panMessage.Visible = false;
			panSalvato.Visible = false;

			//Passo l'elenco dei messaggi al controllo che creerà la lista visibile, e invoco il databind esplicito
			listaFilePersonali.Files = elenco;
			listaFilePersonali.Carica();
		}

		#region IFilePersonali Members

		public DataAccessLayer.MessaggioSalvato FileDaMostrare
		{
			get
			{
				object obj = ViewState["FileDaMostrare"];
				if (obj != null)
				{
					return (MessaggioSalvato)obj;
				}
				return null;
			}
			set
			{
				ViewState["FileDaMostrare"] = value;
			}
		}

		public void MostraFile()
		{
			MessaggioSalvato fileDaMostrare = FileDaMostrare;
			if (fileDaMostrare != null)
			{
				//procedere a mostrare il tutto
				panMessage.Visible = true;
				panSalvato.Visible = false;
				lblTitolo.Text = fileDaMostrare.Titolo;
				if (ShowEncrypted && fileDaMostrare.LivelloCrittazione > 0)
				{
					ucDecrypt.LivelloDifficolta = fileDaMostrare.LivelloCrittazione;
					lblTesto.Text = Encryption.ReturnEncryptedText(fileDaMostrare.Contenuto);
					btnSalva.Visible = false;
				}
				else
				{
					lblTesto.Text = fileDaMostrare.Contenuto;
					btnSalva.Visible = true;
					ShowEncrypted = true;
				}
			}
		}

		#endregion

		protected void btnSalva_Click(object sender, EventArgs e)
		{
			ucDecrypt.Visible = false;
			ucHacking.IdentificatoreElemento = FileDaMostrare.Progressivo;
			ucHacking.AccettaSpina = true;
			ucHacking.LivelloHacking = FileDaMostrare.Hacking;
			ucHacking.ParteDaHackerare = hackables.files;
			ucHacking.Visible = true;
			ucHacking.Carica();
		}


		#region IHackablePage Members

		public bool Hacked
		{
			get
			{
				object obj = ViewState["Hacked"];
				if (obj != null)
				{
					return (bool)obj;
				}
				return false;
			}
			set
			{
				ViewState["Hacked"] = value;
			}
		}

		public void OnHackedSuccess(long hackerAccount)
		{
			//Salvare il messaggio nell'account dell'Hacker e registrare il successo
			using (HolonetEntities context = new HolonetEntities())
			{
				MessaggioSalvato message = new MessaggioSalvato();
				message.Contenuto = "Da: " + FileDaMostrare.Personaggio.Nome + "<br/>" + FileDaMostrare.Contenuto;
				message.Titolo = FileDaMostrare.Titolo;
				message.NumeroPG = hackerAccount;
				message.Hacking = FileDaMostrare.Hacking;
				message.Provenienza = "MISSIONI";
				context.AddToMessaggioSalvatoes(message);
				context.SaveChanges();
			}
			HackingEngine.RegistraHackingFile(FileDaMostrare.Progressivo, hackerAccount, true);
			panMessage.Visible = false;
			panSalvato.Visible = true;
			ucHacking.Visible = false;
		}

		public void OnHackedFailure(long hackerAccount)
		{
			HackingEngine.RegistraHackingFile(FileDaMostrare.Progressivo, hackerAccount, false);
			Response.Redirect("~/Hacking/HackedAccount.aspx", true);
		}

		#endregion

		#region ICryptable Members

		public long Crypted
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void OnCrypting(long crypterLevel)
		{
			throw new NotImplementedException();
		}

		public void OnDecryptSuccess(long crypterAccount)
		{
			ShowEncrypted = false;
			MostraFile();
		}

		#endregion
	}
}
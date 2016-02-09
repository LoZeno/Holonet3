using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Holonet3.Messaggi;
using DataAccessLayer;
using Holonet3.Utilities;
using HolonetWebControls;

namespace Holonet3.Hacking
{
	public partial class HackedIncoming : HolonetPage, IMessaggi, IHackablePage, ICryptable
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
				caricaMessaggiInArrivo();
			}
		}

		private void caricaMessaggiInArrivo()
		{
			listaMessaggiRicevuti.Visible = true;
			List<PostaInArrivo> elenco;
			long accountInfranto = (long)Session["AccountInfranto"];
			using (HolonetEntities context = new HolonetEntities())
			{
				var character = (from personaggio in context.Personaggios
								where personaggio.NumeroPG == accountInfranto
								select personaggio).First();
				DateTime dataDaConfrontare = DateTime.Today.AddMonths(-6);

				var messaggiInArrivo = (from messages in context.PostaInArrivoes
										where messages.NumeroPG == character.NumeroPG
										&& (messages.DataCancellazione == null || messages.DataCancellazione >= dataDaConfrontare)
										//where messages.Cancellata == false
										select messages).OrderByDescending(mexs => mexs.NumeroMissione);

				foreach (var messaggio in messaggiInArrivo)
				{
					if (!messaggio.MissioneReference.IsLoaded)
					{
						messaggio.MissioneReference.Load();
						if (!messaggio.Missione.PersonaggioReference.IsLoaded)
						{
							messaggio.Missione.PersonaggioReference.Load();
						}
					}
					if (messaggio.Cancellata == true)
					{
						messaggio.Missione.LivelloHacking += 5;
					}
				}
				elenco = messaggiInArrivo.ToList();
				listaMessaggiRicevuti.refCharacter = character;
			}
			panMessage.Visible = false;
			panSalvato.Visible = false;

			//Passo l'elenco dei messaggi al controllo che creerà la lista visibile, e invoco il databind esplicito
			listaMessaggiRicevuti.Messaggi = elenco;
			listaMessaggiRicevuti.Carica();
		}

		#region IMessaggi Members

		public bool IsInUscita
		{
			get
			{
				object obj = ViewState["IsInUscita"];
				if (obj != null)
				{
					return (bool)obj;
				}
				return false;
			}
			set
			{
				ViewState["IsInUscita"] = value;
			}
		}

		public DataAccessLayer.Missione MessaggioVisualizzato
		{
			get
			{
				object obj = ViewState["MessaggioVisualizzato"];
				if (obj != null)
				{
					return (Missione)obj;
				}
				return null;
			}
			set
			{
				ViewState["MessaggioVisualizzato"] = value;
				//MostraMessaggio();
			}
		}

		public void MostraMessaggio()
		{
			Missione messaggioDaMostrare = MessaggioVisualizzato;
			if (messaggioDaMostrare != null)
			{
				//procedere a mostrare il tutto
				panMessage.Visible = true;
				panSalvato.Visible = false;
				lblMittente.Visible = true;
				lblMittente.Text = "Mittente: " + messaggioDaMostrare.Personaggio.Nome;
				lblTitolo.Text = messaggioDaMostrare.Titolo;
				if (ShowEncrypted && messaggioDaMostrare.LivelloCrittazione > 0)
				{
					ucDecrypt.LivelloDifficolta = messaggioDaMostrare.LivelloCrittazione;
					lblTesto.Text = Encryption.ReturnEncryptedText(messaggioDaMostrare.Testo);
					btnSalva.Visible = false;
				}
				else
				{
					lblTesto.Text = messaggioDaMostrare.Testo;
					btnSalva.Visible = true;
					ShowEncrypted = true;
				}
			}
		}

		public void MostraMessaggioInUscita()
		{
			throw new NotImplementedException();
		}

		protected void btnSalva_Click(object sender, EventArgs e)
		{
			ucDecrypt.Visible = false;
			ucHacking.IdentificatoreElemento = MessaggioVisualizzato.NumeroMissione;
			ucHacking.AccettaSpina = true;
			ucHacking.LivelloHacking = MessaggioVisualizzato.LivelloHacking;
			ucHacking.ParteDaHackerare = hackables.missioni;
			ucHacking.Visible = true;
			ucHacking.Carica();
		}

		#endregion

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
				message.Contenuto = "Da: " + MessaggioVisualizzato.Mandante + "<br/>" + MessaggioVisualizzato.Testo;
				message.Titolo = MessaggioVisualizzato.Titolo;
				message.NumeroPG = hackerAccount;
				message.Hacking = MessaggioVisualizzato.LivelloHacking;
				message.Provenienza = "MISSIONI";
				context.AddToMessaggioSalvatoes(message);
				context.SaveChanges();
			}
			HackingEngine.RegistraHackingMissione(MessaggioVisualizzato.NumeroMissione, hackerAccount, true);
			panMessage.Visible = false;
			panSalvato.Visible = true;
			ucHacking.Visible = false;
		}

		public void OnHackedFailure(long hackerAccount)
		{
			HackingEngine.RegistraHackingMissione(MessaggioVisualizzato.NumeroMissione, hackerAccount, false);
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
			MostraMessaggio();
		}

		#endregion
	}
}
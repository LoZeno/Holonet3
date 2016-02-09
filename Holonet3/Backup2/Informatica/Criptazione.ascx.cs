using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Holonet3.Utilities;

namespace Holonet3.Informatica
{
	public partial class Criptazione : System.Web.UI.UserControl
	{
		public event EventHandler OnCancelOperation;

		public object IdentificatoreElemento
		{
			get
			{
				return ViewState["IdentificatoreElemento"];
			}
			set
			{
				ViewState["IdentificatoreElemento"] = value;
			}
		}

		public long LivelloCrittazione
		{
			get
			{
				object obj = ViewState["LivelloCrittazione"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["LivelloCrittazione"] = value;
			}
		}

		private int GiriDiOrologio
		{
			get
			{
				object obj = ViewState["GiriDiOrologio"];
				if (obj != null)
				{
					return (int)obj;
				}
				return 0;
			}
			set
			{
				ViewState["GiriDiOrologio"] = value;
			}
		}

		private long livelloOffuscatore
		{
			get
			{
				object obj = ViewState["livelloOffuscatore"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["livelloOffuscatore"] = value;
			}
		}

		private long characterAccount
		{
			get
			{
				object obj = ViewState["characterAccount"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["characterAccount"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				txtNumeroPg.Attributes.Add("onkeypress", "return isNumberKey(event)");
				Timer1.Interval = 10000;
				Carica();
			}
		}

		public void Carica()
		{
			txtPassword.Text = string.Empty;
			txtNumeroPg.Text = string.Empty;
			trErrorMessage.Visible = false;
			divStarter.Visible = true;
			divMain.Visible = false;
			divAttenderePrego.Visible = false;
			divSuccesso.Visible = false;
		}

		protected void btnInvia_Click(object sender, EventArgs e)
		{
			trErrorMessage.Visible = false;
			lblError.Text = string.Empty;
			GiriDiOrologio = 0;
			trErrorMessage.Visible = false;
			lblError.Text = string.Empty;
			Personaggio crypter = null;
			long numeroPg;
			string password;
			IQueryable<AbilitaPersonaggio> ricerca;
			int canCrypt = 0;
			try
			{
#warning sistemare le seguenti query LINQ perché così FA SCHIFO, troppe chiamate al database
				numeroPg = long.Parse(txtNumeroPg.Text.Trim());
				password = txtPassword.Text.Trim();
				using (HolonetEntities context = new HolonetEntities())
				{
					crypter = (from characters in context.Personaggios
							   where characters.NumeroPG == numeroPg
							   select characters).First();
					characterAccount = crypter.NumeroPG;
					ricerca = (from abilita in context.AbilitaPersonaggios
							   where abilita.NumeroPG == numeroPg
							   where abilita.CdAbilita == 11 //CRITTOGRAFIA I 
							   select abilita);
					canCrypt = ricerca.Count();
					if (canCrypt > 0)
					{
						livelloOffuscatore = 2;
						ricerca = (from abilita in context.AbilitaPersonaggios
								   where abilita.NumeroPG == numeroPg
								   where abilita.CdAbilita == 10 //CRITTOGRAFIA II
								   select abilita);
						if (ricerca.Count() > 0)
						{
							livelloOffuscatore = 3;
							ricerca = (from abilita in context.AbilitaPersonaggios
									   where abilita.NumeroPG == numeroPg
									   where abilita.CdAbilita == 12 //CRITTOGRAFIA III
									   select abilita);
							if (ricerca.Count() > 0)
							{
								livelloOffuscatore = 4;
							}
						}
					}
				}
			}
			catch (Exception)
			{
				lblError.Text = "Il numero inserito non è un account valido";
				trErrorMessage.Visible = true;
				return;
			}
			
			if (crypter.PasswordHolonet != password || canCrypt <= 0)
			{
				lblError.Text = "Secondo il database TU non puoi criptare...";
				trErrorMessage.Visible = true;
				return;
			}
			//Parte il timer dell'offuscamento
			divMain.Visible = false;
			divAttenderePrego.Visible = true;
			characterAccount = numeroPg;
			Timer1.Interval -= (int)(6000/livelloOffuscatore);
			Timer1.Enabled = true;
		}

		protected void btnAvviaEncoding_Click(object sender, EventArgs e)
		{
			divStarter.Visible = false;
			divSuccesso.Visible = false;
			divMain.Visible = true;
		}

		protected void btnAnnulla_Click(object sender, EventArgs e)
		{
			divMain.Visible = false;
			txtNumeroPg.Text = string.Empty;
			txtPassword.Text = string.Empty;
			divStarter.Visible = true;
			trErrorMessage.Visible = false;
			lblError.Text = string.Empty;
			if (OnCancelOperation != null)
			{
				OnCancelOperation(sender, e);
			}
		}

		protected void TimerTick(object sender, EventArgs e)
		{
			GiriDiOrologio++;
			if (GiriDiOrologio == 1)
			{
				lblAttendere.Text = "33%";
			}
			else if (GiriDiOrologio == 2)
			{
				lblAttendere.Text = "66%";
			}
			else if (GiriDiOrologio == 3)
			{
				lblAttendere.Text = "99%";
			}
			else if (GiriDiOrologio >= 4)
			{
				lblAttendere.Text = "100%";
				Timer1.Enabled = false;
				((ICryptable)this.Page).OnCrypting(livelloOffuscatore);
				divStarter.Visible = true;
				divSuccesso.Visible = true;
				divAttenderePrego.Visible = false;
				divMain.Visible = false;
				txtNumeroPg.Text = string.Empty;
				txtPassword.Text = string.Empty;
			}
		}
	}
}
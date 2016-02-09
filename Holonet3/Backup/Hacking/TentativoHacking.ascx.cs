using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Holonet3.Utilities;
using DataAccessLayer;
using HolonetWebControls;

namespace Holonet3.Hacking
{
	public partial class TentativoHacking : HolonetUserControl
	{
		public hackables ParteDaHackerare
		{
			get
			{
				object obj = ViewState["ParteDaHackerare"];
				if (obj != null)
				{
					return (hackables)obj;
				}
				return hackables.nulla;
			}
			set
			{
				ViewState["ParteDaHackerare"] = value;
			}
		}

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

		public long LivelloHacking
		{
			get
			{
				object obj = ViewState["LivelloHacking"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["LivelloHacking"] = value;
			}
		}

		public bool AccettaSpina
		{
			get
			{
				object obj = ViewState["AccettaSpina"];
				if (obj != null)
				{
					return (bool)obj;
				}
				return false;
			}
			set
			{
				ViewState["AccettaSpina"] = value;
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

		private long livelloHacker
		{
			get
			{
				object obj = ViewState["livelloHacker"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["livelloHacker"] = value;
			}
		}

		private long hackerAccount
		{
			get
			{
				object obj = ViewState["hackerAccount"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["hackerAccount"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				txtNumeroPg.Attributes.Add("onkeypress", "return isNumberKey(event)");
				Timer1.Interval = 15000;
				Carica();
			}
		}

		public void Carica()
		{
			if (!AccettaSpina)
			{
				trSpina.Visible = false;
			}
			else
			{
				trSpina.Visible = true;
			}
			txtSpina.Text = string.Empty;
			txtPassword.Text = string.Empty;
			txtNumeroPg.Text = string.Empty;
			trErrorMessage.Visible = false;
			lblError.Text = string.Empty;
			divStarter.Visible = true;
			divMain.Visible = false;
			divAttenderePrego.Visible = false;
		}

		protected void btnInvia_Click(object sender, EventArgs e)
		{
			GiriDiOrologio = 0;
			trErrorMessage.Visible = false;
			divAttenderePrego.Visible = false;
			lblError.Text = string.Empty;
			Personaggio hacker = null;
			//Carico il personaggio dell'Hacker, e controllo se è un hacker.
			long numeroPg;
			string password;
			try
			{
				numeroPg = long.Parse(txtNumeroPg.Text.Trim());
				password = txtPassword.Text.Trim();

				hacker = (from characters in DatabaseContext.Personaggios
	 						where characters.NumeroPG == numeroPg
							select characters).First();
				hackerAccount = hacker.NumeroPG;
			}
			catch
			{
				((IHackablePage)this.Page).Hacked = false;
				lblError.Text = "Il numero inserito non è un account valido";
				trErrorMessage.Visible = true;
				return;
			}
			if (hacker.PasswordHolonet != password)
			{
				((IHackablePage)this.Page).Hacked = false;
				lblError.Text = "Password errata";
				trErrorMessage.Visible = true;
				return;
			}
			//if (!hacker.Hacker.HasValue || hacker.Hacker == 0)
#if !DEBUG
			if (hacker.LivelloHacker == 0)
			{
				((IHackablePage)this.Page).Hacked = false;
				lblError.Text = "Secondo il database TU non sei un hacker...";
				trErrorMessage.Visible = true;
				return;
			}
#endif

			//controllo se il personaggio non ha già tentato l'hacking su questo elemento
			bool canHack = false;

			if (IdentificatoreElemento == null && ParteDaHackerare != hackables.rubrica && ParteDaHackerare != hackables.altro && ParteDaHackerare != hackables.nulla && ParteDaHackerare != hackables.files && ParteDaHackerare != hackables.notizia)
			{
				((IHackablePage)this.Page).Hacked = false;
				lblError.Text = "Errore probabilmente di sistema, chiamare lo Zeno e dirgli che (testualmente) in questa pagina l'Identificatore Elemento è pari a NULL. Non fatevi domande, fidatevi e basta.";
				trErrorMessage.Visible = true;
				return;
			}

			switch (ParteDaHackerare)
			{
				case hackables.account:
					canHack = HackingEngine.AbilitatoHackingAccount((long)IdentificatoreElemento, hacker.NumeroPG);
					break;
				case hackables.holodisk:
					canHack = HackingEngine.AbilitatoHolodiskHacking((long)IdentificatoreElemento, hacker.NumeroPG);
					break;
				case hackables.notizia:
					canHack = HackingEngine.AbilitatoNotiziaHacking((long)IdentificatoreElemento, hacker.NumeroPG);
					break;
				case hackables.rubrica:
					canHack = true;
					break;
				case hackables.missioni:
					canHack = HackingEngine.AbilitatoMissioneHacking((long)IdentificatoreElemento, hacker.NumeroPG);
					break;
				case hackables.files:
					canHack = true;
					break;
				case hackables.altro:
					canHack = true;
					break;
				case hackables.nulla:
					canHack = false;
					break;
				default:
					break;
			}

			//Se non può tentare l'hacking, ABORT MISSION
			if (!canHack)
			{
				((IHackablePage)this.Page).Hacked = false;
				lblError.Text = "Il sistema ha rilevato e bloccato il tuo tentativo di attacco!";
				trErrorMessage.Visible = true;
				((IHackablePage)this.Page).OnHackedFailure(hackerAccount);
				return;
			}
			//Parte il timer del tentativo di hacking!
			divMain.Visible = false;
			divAttenderePrego.Visible = true;
			livelloHacker = hacker.LivelloHacker;
			Timer1.Interval -= (int)(livelloHacker * 2000);
#if DEBUG
			Timer1.Interval = (int)100;
#endif
			Timer1.Enabled = true;
		}

		protected void btnAvviaHacking_Click(object sender, EventArgs e)
		{
			divStarter.Visible = false;
			divMain.Visible = true;
		}

		protected void btnAnnulla_Click(object sender, EventArgs e)
		{
			divMain.Visible = false;
			txtNumeroPg.Text = string.Empty;
			txtPassword.Text = string.Empty;
			txtSpina.Text = string.Empty;
			divStarter.Visible = true;
			trErrorMessage.Visible = false;
			lblError.Text = string.Empty;
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
				bool success = false;
				if (!string.IsNullOrWhiteSpace(txtSpina.Text))
				{
					var spine = (from hack in DatabaseContext.CodiciHackings
									where hack.Codice == txtSpina.Text.Trim()
									select hack);
					if (spine.Count() > 0)
					{
						CodiciHacking spina = spine.First();
						if (spina.Livello > LivelloHacking)
						{
							success = true;
						}
					}
				}
#if DEBUG
				success = true;
#endif
				if (!success)
				{
					success = HackingEngine.TentativoHacking(livelloHacker, LivelloHacking);
				}
				((IHackablePage)this.Page).Hacked = success;
				if (success)
				{
					((IHackablePage)this.Page).OnHackedSuccess(hackerAccount);
				}
				else
				{
					((IHackablePage)this.Page).OnHackedFailure(hackerAccount);
				}
			}
		}
	}
}
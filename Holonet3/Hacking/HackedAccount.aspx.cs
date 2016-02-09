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
	public partial class HackedAccount : HolonetPage, IHackablePage
	{
		private enum categorie
		{
			notizie,
			inarrivo,
			inuscita,
			contatti,
			files,
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

		private long livelloHacking
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

		private categorie oggettoHacking
		{
			get
			{
				object obj = ViewState["oggettoHacking"];
				if (obj != null)
				{
					return (categorie)obj;
				}
				return categorie.contatti;
			}
			set
			{
				ViewState["oggettoHacking"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			((SiteMaster)this.Page.Master).FindControl("NavigationMenu").Visible = false;
			if (!IsPostBack)
			{
				long accountInfranto = (long)Session["AccountInfranto"];
				using (HolonetEntities context = new HolonetEntities())
				{
					var account = (from personaggio in context.Personaggios
								   where personaggio.NumeroPG == accountInfranto
								   select personaggio).First();

					lblNomeProprietario.Text = account.Nome;
					livelloHacking = account.Protezione;
					//if (account.Hacker.HasValue && account.Hacker > 1)
					//{
					//    livelloHacking = (long)account.Hacker;
					//}
					//else
					//{
					//    livelloHacking = 1;
					//}
					//if (account.UltimaCrittazione.HasValue && account.UltimaCrittazione > DateTime.Now.AddHours(-3))
					//{
					//    livelloHacking += account.LivelloCrittazione;
					//}
				}
			}
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
			switch (oggettoHacking)
			{
				case categorie.notizie:
					Response.Redirect("~/Hacking/HackedNews.aspx", true);
					break;
				case categorie.inarrivo:
					Response.Redirect("~/Hacking/HackedIncoming.aspx", true);
					break;
				case categorie.inuscita:
					Response.Redirect("~/Hacking/HackedOutgoing.aspx", true);
					break;
				case categorie.contatti:
					break;
				case categorie.files:
					Response.Redirect("~/Hacking/HackedFiles.aspx", true);
					break;
				default:
					break;
			}
		}

		public void OnHackedFailure(long hackerAccount)
		{
			switch (oggettoHacking)
			{
				case categorie.notizie:
					Response.Redirect("~/Hacking/HackedNetwork.aspx", true);
					break;
				case categorie.inarrivo:
					Response.Redirect("~/Hacking/HackedNetwork.aspx", true);
					break;
				case categorie.inuscita:
					Response.Redirect("~/Hacking/HackedNetwork.aspx", true);
					break;
				case categorie.contatti:
					Response.Redirect("~/Hacking/HackedNetwork.aspx", true);
					break;
				case categorie.files:
					Response.Redirect("~/Hacking/HackedNetwork.aspx", true);
					break;
				default:
					break;
			}
		}

		#endregion

		protected void btnNotizie_Click(object sender, EventArgs e)
		{
			oggettoHacking = categorie.notizie;
			ucHacking.Visible = true;
			ucHacking.AccettaSpina = false;
			ucHacking.LivelloHacking = livelloHacking;
			ucHacking.ParteDaHackerare = hackables.altro;
			ucHacking.Carica();
		}

		protected void btnInArrivo_Click(object sender, EventArgs e)
		{
			oggettoHacking = categorie.inarrivo;
			ucHacking.Visible = true;
			ucHacking.AccettaSpina = true;
			ucHacking.LivelloHacking = livelloHacking * 2;
			ucHacking.ParteDaHackerare = hackables.altro;
			ucHacking.Carica();
		}

		protected void btnInUscita_Click(object sender, EventArgs e)
		{
			oggettoHacking = categorie.inuscita;
			ucHacking.Visible = true;
			ucHacking.AccettaSpina = true;
			ucHacking.LivelloHacking = livelloHacking * 2;
			ucHacking.ParteDaHackerare = hackables.altro;
			ucHacking.Carica();
		}

		protected void btnRubrica_Click(object sender, EventArgs e)
		{

		}

		protected void btnFiles_Click(object sender, EventArgs e)
		{
			oggettoHacking = categorie.files;
			ucHacking.Visible = true;
			ucHacking.AccettaSpina = false;
			ucHacking.LivelloHacking = livelloHacking * 2;
			ucHacking.ParteDaHackerare = hackables.files;
			ucHacking.Carica();
		}
	}
}
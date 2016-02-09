using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using System.Text;
using CommonBusiness.Rete;
using System.Collections;
using Holonet3.Utilities;
using DataAccessLayer;
using CommonBusiness.Personaggi;

namespace Holonet3.Hacking
{
	public partial class NewHackedNetwork : HolonetPage, IHackablePage
	{
		private int rete
		{
			get
			{
                object obj = Session["HackingRete"];
                if (obj != null)
                {
                    return (int)obj;
                }
				obj = Session["Rete"];
				if (obj != null)
				{
					return (int)obj;
				}
				return 0;
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

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//Il pezzo seguente è necessario per far funzionare jScrollPane con gli update panels
			StringBuilder str = new StringBuilder();
			str.Append(@"var myheight = $(window).height();");
			str.Append(@"myheight = (myheight * 70) / 100;");
			str.Append(@"myheight = parseInt(myheight);");
			str.Append(@"$('.scroll-pane').css('height', myheight + 'px');");
			str.Append(@"$('.scroll-pane').jScrollPane({ showArrows: true });");
			ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "testingloader", str.ToString(), true);

            Label lblTitolo = (Label)((SiteMaster)this.Page.Master).FindControl("lblTitolo");
            switch (rete)
            {
                case 0:
                    lblTitolo.Text = "HOLONET";
                    break;
                case 1:
                    lblTitolo.Text = "NUOVA REPUBBLICA";
                    break;
                case 2:
                    lblTitolo.Text = "IMPERO GALATTICO";
                    break;
                case 3:
                    lblTitolo.Text = "FED. PIANETI INDIPENDENTI";
                    break;
                default:
                    lblTitolo.Text = "HOLONET";
                    break;
            }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			((SiteMaster)this.Page.Master).FindControl("NavigationMenu").Visible = false;
			if (!IsPostBack)
			{
				caricaAccountList();
			}
		}

		private void caricaAccountList()
		{
			ReteManager manager = new ReteManager(DatabaseContext);
			grdAccount.DataSource = manager.GetAvailableAccounts(rete).ToList();
			grdAccount.DataBind();
			pageViews.SetActiveView(viewAccountList);
		}

		protected void grdAccount_RowClicked(object sender, GridViewRowClickedEventArgs args)
		{
			try
			{
				errorMessage.Visible = false;
				long accountToHack = long.Parse(args.Row.Cells[0].Text.Trim());
				long livelloHacking = -1;
				PersonaggiManagerNew charactermanager = new PersonaggiManagerNew(DatabaseContext);
				Personaggio account = charactermanager.GetCharacterByNumber(accountToHack);
				if (account.Fazione != rete)
				{
					return;
				}
				
				long valoreProtezione = account.LivelloProtezione;
				if (valoreProtezione > livelloHacking)
				{
					livelloHacking = valoreProtezione;
				}
				hackControl.IdentificatoreElemento = accountToHack;
				hackControl.LivelloHacking = livelloHacking;
				hackControl.Carica();
				pageViews.SetActiveView(viewHackAccount);
			}
			catch
			{
				pageViews.SetActiveView(viewAccountList);
			}
		}

		protected void grdAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			errorMessage.Visible = false;
			grdAccount.PageIndex = e.NewPageIndex;
			caricaAccountList();
		}

		#region IHackablePage Membri di

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
			HackingEngine.RegistraHackingAccount((long)hackControl.IdentificatoreElemento, hackerAccount, true);
			Session["AccountInfranto"] = (long)hackControl.IdentificatoreElemento;
			Response.Redirect("~/Hacking/HackedAccount.aspx");
		}

		public void OnHackedFailure(long hackerAccount)
		{
			HackingEngine.RegistraHackingAccount((long)hackControl.IdentificatoreElemento, hackerAccount, false);
			pageViews.SetActiveView(viewAccountList);
			errorMessage.Visible = true;
		}

		#endregion

		protected void lnkReload_Click(object sender, EventArgs e)
		{
			grdAccount.PageIndex = 0;
			caricaAccountList();
			pageViews.SetActiveView(viewAccountList);
		}
	}
}
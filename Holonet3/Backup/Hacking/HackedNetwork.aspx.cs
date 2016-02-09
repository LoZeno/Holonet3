using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using Holonet3.Utilities;
using HolonetWebControls;

namespace Holonet3.Hacking
{
	public partial class HackedNetwork : HolonetPage, IHackablePage
	{
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
				
				txtAccountDaAprire.Attributes.Add("onkeypress", "return isNumberKey(event)");
				this.Page.Header.Title = "LOGIN";
				object obj = Session["Rete"];
				int rete = (int)obj;
				Dictionary<long, string> values = new Dictionary<long, string>();
				using (HolonetEntities context = new HolonetEntities())
				{
					var accounts = (from people in context.Personaggios
									where people.Fazione == rete
									where people.Vivo == 1
									orderby people.NumeroPG
									select people);
					foreach (var item in accounts)
					{
						values.Add(item.NumeroPG, item.Nome);
					}
				}

				rptAccountRete.DataSource = values;
				rptAccountRete.DataBind();
			}
		}

		protected void rptAccountRete_ItemCreated(object sender, RepeaterItemEventArgs e)
		{

		}

		protected void rptAccountRete_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				KeyValuePair<long, string> elemento = (KeyValuePair<long, string>)e.Item.DataItem;

				Label numeroAccount = (Label)e.Item.FindControl("lblNumero");
				if (numeroAccount != null)
				{
					numeroAccount.Text = elemento.Key.ToString();
				}

				Label nomeAccount = (Label)e.Item.FindControl("lblNome");
				if (nomeAccount != null)
				{
					nomeAccount.Text = elemento.Value;
				}

			}
		}

		protected void btnTenta_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtAccountDaAprire.Text))
			{
				lblFallimento.Visible = false;
				divElenco.Visible = false;
				try
				{
					long numeroAccount = long.Parse(txtAccountDaAprire.Text.Trim());
					long livelloHacking = 1;
					using (HolonetEntities context = new HolonetEntities())
					{
						var personaggio = (from charac in context.Personaggios
												  where charac.NumeroPG == numeroAccount
												  select charac).First();
						object obj = Session["Rete"];
						int rete = (int)obj;
						if (personaggio.Fazione != rete)
						{
							divElenco.Visible = true;
							ucHacking.Visible = false;
							txtAccountDaAprire.Text = string.Empty;
							return;
						}

						long? personaggioHacking = personaggio.LivelloHacker;
						if (personaggioHacking.HasValue && personaggioHacking > livelloHacking)
						{
							livelloHacking = (long)personaggioHacking;
						}
					}
					ucHacking.IdentificatoreElemento = numeroAccount;
					ucHacking.LivelloHacking = livelloHacking;
					ucHacking.Visible = true;
					ucHacking.Carica();
				}
				catch
				{
					ucHacking.Visible = false;
					divElenco.Visible = true;
				}
			}
			
		}

		protected void btnAnnulla_Click(object sender, EventArgs e)
		{
			lblFallimento.Visible = false;
			ucHacking.Visible = false;
			divElenco.Visible = true;
			txtAccountDaAprire.Text = string.Empty;
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
			HackingEngine.RegistraHackingAccount(long.Parse(txtAccountDaAprire.Text.Trim()), hackerAccount, true);
			Session["AccountInfranto"] = long.Parse(txtAccountDaAprire.Text.Trim());
			Response.Redirect("~/Hacking/HackedAccount.aspx");
		}

		public void OnHackedFailure(long hackerAccount)
		{
			HackingEngine.RegistraHackingAccount(long.Parse(txtAccountDaAprire.Text.Trim()), hackerAccount, false);
			lblFallimento.Visible = true;
		}

		#endregion
	}
}
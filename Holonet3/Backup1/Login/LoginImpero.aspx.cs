using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Holonet3.Utilities;
using HolonetWebControls;

namespace Holonet3.Account
{
	public partial class LoginImpero : HolonetPage, IHackablePage
	{
		protected override void Page_PreInit(object sender, EventArgs e)
		{
			Page.Theme = "TemaVerde";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Page.Header.Title = "LOGIN";
			Session.Clear();
			Session.Add("Tema", "TemaVerde");
			Session.Add("Rete", 2);
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
			Session["TemaHacking"] = Page.Theme;
			Response.Redirect("~/Hacking/NewHackedNetwork.aspx");
		}

		public void OnHackedFailure(long hackerAccount)
		{
			Response.Redirect("~/Login/EndSession.aspx");
		}

		#endregion
	}
}
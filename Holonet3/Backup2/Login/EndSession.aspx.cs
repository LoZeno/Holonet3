using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;

namespace Holonet3.Login
{
	public partial class EndSession : HolonetPage
	{
		//protected void Page_PreInit(object sender, EventArgs e)
		//{
		//    if (Session["Tema"] != null)
		//    {
		//        Page.Theme = Session["Tema"].ToString();
		//    }
		//    else
		//    {
		//        Page.Theme = "TemaBlu";
		//    }
		//}

		protected void Page_Load(object sender, EventArgs e)
		{
            LoggedCharacter = null;
			//Session["Personaggio"] = null;
			Session["TemaHacking"] = null;
            //Context.Request.Cookies["Personaggio"].Value = null;
			Response.Redirect("~/Default.aspx");
		}
	}
}
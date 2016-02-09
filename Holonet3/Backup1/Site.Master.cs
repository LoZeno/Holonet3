using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Holonet3
{
	public partial class SiteMaster : System.Web.UI.MasterPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Page.Header.DataBind(); //necessario a far funzionare i blocchi nell'ASPX con ResolveUrl()
		}

		protected void Page_PreInit(object sender, EventArgs e)
		{
            if (Session["TemaHacking"] != null)
            {
                Page.Theme = Session["TemaHacking"].ToString();
            }
			else if (Session["Tema"] != null)
			{
				Page.Theme = Session["Tema"].ToString();
			}
			else
			{
				Page.Theme = "TemaBlu";
			}
		}


		protected void Page_Load(object sender, EventArgs e)
		{
			string rete = null;
			if (Session["Rete"] != null)
			{
				rete = Session["Rete"].ToString();
			}
			//Verifica che sia stato effettuato un login valido, altrimenti reindirizza subito alla pagina di login!
			int? numPG = null;
			if (Context != null)
			{
				HttpCookie cookie = Context.Request.Cookies["Personaggio"];
				if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value)) //Se c'è un cookie, e NON ha valore "vuoto", è stato fatto il login
				{
					//Recupero il numero PG dal cookie...
					numPG = int.Parse(cookie.Value);
				}
			}
			if (!numPG.HasValue && Session["Personaggio"] == null && this.Page.Header.Title != "LOGIN" && Session["TemaHacking"] == null)
			{

				//switch (rete)
				//{
				//    case "0":
				//        Response.Redirect("~/Login/LoginHolonet.aspx", true);
				//        break;
				//    case "1":
				//        Response.Redirect("~/Login/LoginRepubblica.aspx", true);
				//        break;
				//    case "2":
				//        Response.Redirect("~/Login/LoginImpero.aspx", true);
				//        break;
				//    case "3":
				//        Response.Redirect("~/Login/LoginFPI.aspx", true);
				//        break;
				//    default:
				//        Response.Redirect("~/Login/LoginHolonet.aspx", true);
				//        break;
				//}
				Response.Redirect("~/SelezioneRete.aspx", true);
			}
			//Se invece il login c'è stato...
			switch (rete)
			{
				case "0":
					lblTitolo.Text = "HOLONET";
					break;
				case "1":
					lblTitolo.Text = "NUOVA REPUBBLICA";
					break;
				case "2":
					lblTitolo.Text = "IMPERO GALATTICO";
					break;
				case "3":
					lblTitolo.Text = "FED. PIANETI INDIPENDENTI";
					break;
				default:
					lblTitolo.Text = "HOLONET";
					break;
			}
		}
	}
}

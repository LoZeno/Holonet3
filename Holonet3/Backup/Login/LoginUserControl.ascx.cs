using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.Account
{
	public partial class LoginUserControl : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void LoginButton_Click(object sender, EventArgs e)
		{
			bool success = false;
			int? numeroPG = null;
			Personaggio loggedCharacter = null;
			try
			{
				numeroPG = int.Parse(LoginUser.UserName.Trim());
			}
			catch (Exception)
			{
				numeroPG = null;
			}

			if (numeroPG != null)
			{
				string pass = LoginUser.Password;
				if (!string.IsNullOrWhiteSpace(pass))
				{
					string rete = Session["Rete"].ToString();
					if (string.IsNullOrWhiteSpace(rete))
					{
						rete = "0";
					}

					int numeroRete = int.Parse(rete.Trim());

					using (HolonetEntities context = new HolonetEntities())
					{
						if (numeroRete != 0)
						{
							var elements = (from characters in context.Personaggios
											where characters.NumeroPG == numeroPG
											where characters.Fazione == numeroRete
											select characters);
							if (elements.Count() > 0)
							{
								loggedCharacter = elements.First();
							}
						}
						else
						{
							var elements = (from characters in context.Personaggios
											   where characters.NumeroPG == numeroPG
											   select characters);
							if (elements.Count() > 0)
							{
								loggedCharacter = elements.First();
							}
						}
						if (loggedCharacter != null)
						{
							if (loggedCharacter.PasswordHolonet == pass)
							{
								success = true;
							}
						}
					}
				}
			}
			if (success)
			{
                HttpCookie cookie = Context.Request.Cookies["Personaggio"];
                if (cookie != null)
                {
                    cookie.Value = loggedCharacter.NumeroPG.ToString();
                }
                else
                {
                    Context.Response.Cookies.Add(new HttpCookie("Personaggio", loggedCharacter.NumeroPG.ToString()));
                }
				Session["Personaggio"] = loggedCharacter;
			}
			else
			{
				Session["Personaggio"] = null;
			}
			//Server.Transfer("~/Default.aspx", true);
			Response.Redirect("~/Default.aspx");
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;

namespace Holonet3.Login
{
	public partial class NewLogin : HolonetPage
	{
		protected override void Page_PreInit(object sender, EventArgs e)
		{
			Page.Theme = "TemaBlu";
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			qrReader.OnCodeDecoded += new EventHandler(qrReader_OnCodeDecoded);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Page.Header.Title = "LOGIN";
			Session.Clear();
			Session.Add("Tema", "TemaBlu");
			Session.Add("Rete", 0);

			
		}

		void qrReader_OnCodeDecoded(object sender, EventArgs e)
		{
			string myCode = qrReader.Code;
			//...e qui finalmente si potrà fare il login, usando myCode per cercare il codice nell'entità Personaggio.
		}

		
	}
}
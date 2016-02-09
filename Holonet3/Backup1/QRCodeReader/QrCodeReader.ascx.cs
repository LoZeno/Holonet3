using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Holonet3.QRCodeReader
{
	public partial class QrCodeReader : System.Web.UI.UserControl
	{
		public event EventHandler OnCodeDecoded;

		public string Code
		{
			get
			{
				object obj = ViewState["QRCode"];
				if (obj != null)
				{
					return obj.ToString();
				}
				return string.Empty;
			}
			set
			{
				ViewState["QRCode"] = value;
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//Creo la funzione Javascript per passare il codice decodificato dal lettore QR nell'hidden field e lanciare l'evento PostBack per poterlo usare lato server
			string scriptName = "postbacklauncher";
			StringBuilder script = new StringBuilder();
			script.Append("function LaunchPostBack(p_data) {");
			script.Append("$('#hidValue').val(p_data); "); //copia il valore che gli verrà dato dal decodificatore (p_data) dentro all'hiddenfield
			script.Append(Page.ClientScript.GetPostBackEventReference(btnForNothing, "p_data")); //questo genera il codice javascript per lanciare il PostBack dal pulsante fasullo, btnForNothing
			script.Append("}");
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), scriptName, script.ToString(), true);

			scriptName = "CameraInit";
			script = new StringBuilder();
			script.Append(@"$('#qrcodebox').WebcamQRCode({");
            script.Append(@"    onQRCodeDecode: function (p_data) {");
            script.Append(@"        $('#qrcode_result').html(p_data);");
            script.Append(@"        LaunchPostBack(p_data);");
			script.Append(@"    }");
			script.Append(@"});");
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), scriptName, script.ToString(), true);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			btnForNothing.Click += new EventHandler(btnForNothing_Click); //registro l'evento di click del bottone fasullo, utile SOLO a poter lanciare un postback tramite javascript
		}

		/// <summary>
		/// Questo metodo viene chiamato al click del bottone fasullo, in pratica quindi viene lanciato tramite il javascript creato nell'onprerender!
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnForNothing_Click(object sender, EventArgs e)
		{
			//Il valore del codice QR letto si trova nell'hiddenfield!
			string pdata = hidValue.Value;
			this.Code = pdata;
			OnCodeDecoded(sender, e);
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}
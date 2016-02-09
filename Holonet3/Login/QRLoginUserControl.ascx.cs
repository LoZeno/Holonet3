using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using CommonBusiness.Personaggi;
using DataAccessLayer;

namespace Holonet3.Login
{
	public partial class QRLoginUserControl : HolonetUserControl
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			qrReader.OnCodeDecoded += new EventHandler(qrReader_OnCodeDecoded);
		}

		void qrReader_OnCodeDecoded(object sender, EventArgs e)
		{
			//Tenere a mente: questo sistema di login si basa sul riconoscimento di UN codice recuperato da un QR Code.
			//Quindi non occorre confrontare password o che altro, basta recuperare il personaggio associato a quel codice, e verificare
			//che appartenga alla fazione corretta.
			string myCode = qrReader.Code; //fase 1: prendo il codice letto dal plugin
			if (!string.IsNullOrEmpty(myCode))
			{
				Guid uniqueCode;
				try
				{
					uniqueCode = new Guid(myCode);
				}
				catch
				{
					lblErrorMessage.Text = "Cartellino non valido"; //Se il codice è un codice ad cazzum, non un GUID, è ovviamente un QR Code sbagliato
					return;
				}
				PersonaggiManagerNew manager = new PersonaggiManagerNew(this.DatabaseContext);
				Personaggio loggedCharacter = manager.GetCharacterByGUID(uniqueCode); //Cerco nel database un PG associato a quel GUID
				if (loggedCharacter == null)
				{
					lblErrorMessage.Text = "Cartellino non di login"; //Se non ho PG associati a quel GUID, non è un cartellino di login. Forse un medicinale o droga o oggetto.
					return;
				}
				string rete = Session["Rete"].ToString(); //recupero il codice della rete a cui ci si sta loggando
				if (string.IsNullOrWhiteSpace(rete))
				{
					rete = "0";
				}
				int numeroRete = int.Parse(rete.Trim());
				if (numeroRete == 0 || loggedCharacter.Fazione == numeroRete) //il login è valido se la rete è 0 (Holonet blu), o se il PG appartiene alla fazione dell'holonet specifica (1 = repubblica, 2 = impero, 3 = federazione)
				{
					HttpCookie cookie = Context.Request.Cookies["Personaggio"]; //popolo il cookie col suo numero PG
					if (cookie != null)
					{
						cookie.Value = loggedCharacter.NumeroPG.ToString();
					}
					else
					{
						Context.Response.Cookies.Add(new HttpCookie("Personaggio", loggedCharacter.NumeroPG.ToString()));
					}
					Session["Personaggio"] = loggedCharacter;
					Response.Redirect("~/Default.aspx"); //pagina di default con redirect al menu iniziale
				}
				else //Login non valido: non è l'Holonet blu, il personaggio esiste ma non fa parte della fazione.
				{
					Session["Personaggio"] = null;
					lblErrorMessage.Text = "Utente non autorizzato all'accesso";
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}
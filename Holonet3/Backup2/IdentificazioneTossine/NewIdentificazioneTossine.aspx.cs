using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using CommonBusiness.Sostanze;
using DataAccessLayer;
using CommonBusiness.Personaggi;

namespace Holonet3.IdentificazioneTossine
{
    public partial class NewIdentificazioneTossine : HolonetPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            qrReader.OnCodeDecoded += new EventHandler(qrReader_OnCodeDecoded);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				bool canUse = false;
				if (LoggedCharacter != null)
				{
					PersonaggiManagerNew manager = new PersonaggiManagerNew(DatabaseContext);
					canUse = manager.HasSkill(LoggedCharacter.NumeroPG, 2);
				}
				if (canUse)
				{
					svuotaControlli();
				}
				else
				{
					Response.Redirect("~/Default.aspx");
				}
			}
        }

        private void svuotaControlli()
        {
            lblNome.Text =
            lblEffetto.Text =
            lblDescrizione.Text =
            lblData.Text =
            lblCosto.Text =
            lblEfficacia.Text =
            lblTipo.Text =
            lblModoUso.Text = string.Empty;
            imgOggetto.ImageUrl = string.Empty;
            imgOggetto.Visible = false;
        }

        void qrReader_OnCodeDecoded(object sender, EventArgs e)
        {
            string myCode = qrReader.Code;
            svuotaControlli();
            if (!string.IsNullOrEmpty(myCode))
            {
                Guid uniqueCode;
                try
                {
                    uniqueCode = new Guid(myCode);
                }
                catch
                {
                    lblDescrizione.Text = "Cartellino non valido"; //Se il codice è un codice ad cazzum, non un GUID, è ovviamente un QR Code sbagliato
                    return;
                }
                SostanzeManager manager = new SostanzeManager(DatabaseContext);
                NewSostanze myItem = manager.GetSubstanceFromQRCode(uniqueCode);
                if (myItem == null)
                {
                    lblDescrizione.Text = "Non è un cartellino di un composto";
                    return;
                }
                if (myItem.Tipo == 0 || myItem.Tipo == 2 || myItem.Tipo == 3)
                {
                    lblNome.Text = myItem.Nome;
                    if (!string.IsNullOrWhiteSpace(myItem.Descrizione))
                    {
                        lblDescrizione.Text = myItem.Descrizione.Replace("\r", "<br />");
                    }
                    if (!string.IsNullOrWhiteSpace(myItem.Effetto))
                    {
                        lblEffetto.Text = myItem.Effetto.Replace("\r", "<br />");
                    }
                    lblData.Text = myItem.DataScadenza.HasValue ? myItem.DataScadenza.Value.ToString("dd/MM/yyyy") : string.Empty;
                    lblCosto.Text = myItem.Costo.ToString();
                    lblEfficacia.Text = myItem.ValoreEfficacia.ToString();
                    lblTipo.Text = myItem.TipoSostanze.Descrizione;
                    lblModoUso.Text = myItem.ModoUso;
                    if (!string.IsNullOrWhiteSpace(myItem.Immagine))
                    {
                        imgOggetto.Visible = true;
                        imgOggetto.ImageUrl = myItem.Immagine;
                    }
                }
                else
                {
                    lblDescrizione.Text = "La sostanza non è nè un ingrediente nè una tossina o droga (forse medicinale?)";
                }
            }
        }
    }
}
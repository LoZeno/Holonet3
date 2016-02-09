using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using CommonBusiness.OggettiManager;
using DataAccessLayer;

namespace Holonet3.IdentificaOggetti
{
    public partial class NewIdentificaOggetti : HolonetPage
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
                svuotaControlli();
            }
        }

        private void svuotaControlli()
        {
            lblNome.Text =
                lblEffetto.Text =
                lblDescrizione.Text =
                lblData.Text =
                lblCosto.Text =
                lblTipo.Text =
                lblCariche.Text = string.Empty;
                imgOggetto.ImageUrl = string.Empty;
                imgOggetto.Visible = false;
        }

        private void qrReader_OnCodeDecoded(object sender, EventArgs e)
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
                OggettiManager manager = new OggettiManager(DatabaseContext);
                NewOggetti myItem = manager.GetItemFromQRCode(uniqueCode);
                if (myItem == null)
                {
                    lblDescrizione.Text = "Non è un cartellino oggetto";
                }
                else
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
                    if (myItem.Tipo.HasValue)
                    {
                        lblTipo.Text = myItem.TipoOggetti.Descrizione;
                    }
                    lblData.Text = myItem.DataScadenza.HasValue ? myItem.DataScadenza.Value.ToString("dd/MM/yyyy") : string.Empty;
                    lblCosto.Text = myItem.Costo.ToString();
                    lblCariche.Text = myItem.NumeroCariche.ToString();
                    if (!string.IsNullOrWhiteSpace(myItem.Immagine))
                    {
                        imgOggetto.Visible = true;
                        imgOggetto.ImageUrl = myItem.Immagine;
                    }
                }
            }
        }
    }
}
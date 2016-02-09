using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;

namespace Holonet3.IdentificaOggetti
{
    public partial class IdentificaOggetti : HolonetPage
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
            if (!IsPostBack)
            {
                if (LoggedCharacter != null)
                {
                }
            }
        }

        protected void btnIdentifica(object sender, EventArgs e)
        {
            string itemCode = txtCodice.Text.Trim();

            using (HolonetEntities context = new HolonetEntities())
            {
                var oggetti = (from items in context.Oggettis
                               where items.CodiceOggetto == itemCode
                               select items);
                if (oggetti.Count() > 0)
                {
                    Oggetti oggettoIdentificato = oggetti.First();
                    lblNome.Text = "<b>OGGETTO:</b> " + oggettoIdentificato.Nome;
                    lblDescrizione.Text = "<b>DESCRIZIONE:</b><br />" + oggettoIdentificato.Descrizione;
                    if (oggettoIdentificato.DataScadenza != null)
                    {
                        lblData.Text = "DATA SCADENZA: " + oggettoIdentificato.DataScadenza.ToString();
                    }
                    else
                    {
                        lblData.Text = string.Empty;
                    }

                    if (oggettoIdentificato.Cariche != null && oggettoIdentificato.Cariche > 0)
                    {
                        lblCariche.Text = "CARICHE: " + oggettoIdentificato.Cariche;
                    }
                    else
                    {
                        lblCariche.Text = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(oggettoIdentificato.Immagine))
                    {
                        imgOggetto.ImageUrl = oggettoIdentificato.Immagine.Trim();
						imgOggetto.Visible = true;
                    }
                    else
                    {
                        imgOggetto.ImageUrl = string.Empty;
						imgOggetto.Visible = false;
                    }
                    if (oggettoIdentificato.Costo != null)
                    {
                        lblCosto.Text = "VALORE IN BUONE CONDIZIONI: ";
                        if (oggettoIdentificato.Costo == 0)
                        {
                            lblCosto.Text += "praticamente nullo";
                        }
                        else
                        {
                            lblCosto.Text += oggettoIdentificato.Costo.ToString() + " crediti";
                        }
                    }
                    else
                    {
                        lblCosto.Text = "VALORE IN BUONE CONDIZIONI: non stimabile";
                    }
                }
                else
                {
                    SvuotaControlli();
                    lblDescrizione.Text = "Attenzione: l'oggetto con codice " + itemCode + " non esiste o non è presente negli archivi.";
                }
            }
        }

        public void SvuotaControlli()
        {
            imgOggetto.ImageUrl = string.Empty;
			imgOggetto.Visible = false;
            lblNome.Text = string.Empty;
            lblDescrizione.Text = string.Empty;
            lblData.Text = string.Empty;
            lblCariche.Text = string.Empty;
            lblCosto.Text = string.Empty;
        }

        protected void NewSearch(object sender, EventArgs e)
        {
            SvuotaControlli();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;

namespace Holonet3.Messaggi
{
    public partial class Rubrica : HolonetPage
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
                txtNumero.Attributes.Add("onkeypress", "return isNumberKey(event)");
                if (LoggedCharacter != null)
                {
                    carica();
                }
            }
        }

        private void carica()
        {
            txtNome.Text = string.Empty;
            txtNumero.Text = string.Empty;
            Dictionary<long, string> dictRubrica = new Dictionary<long, string>();
            Personaggio currentCharacter = (Personaggio)Session["Personaggio"];
            using (HolonetEntities context = new HolonetEntities())
            {
                var nominativi = (from nomi in context.Rubricas
                                  where nomi.NumeroPG == currentCharacter.NumeroPG
                                  orderby nomi.NomeVisualizzato
                                  select nomi);
                foreach (var elemento in nominativi)
                {
                    dictRubrica.Add(elemento.NumeroSalvato, elemento.NomeVisualizzato);
                }
            }

            rptNumeriSalvati.DataSource = dictRubrica;
            rptNumeriSalvati.DataBind();
        }

        protected void rptNumeriSalvati_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptNumeriSalvati_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                KeyValuePair<long, string> singleItem = (KeyValuePair<long, string>)e.Item.DataItem;

                Label lblNumber = (Label)(e.Item.FindControl("lblNumero"));
                Label lblName = (Label)(e.Item.FindControl("lblNome"));

                lblNumber.Text = singleItem.Key.ToString();
                lblName.Text = singleItem.Value.ToString();
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNumero.Text) && !string.IsNullOrWhiteSpace(txtNome.Text))
            {
                Personaggio currentCharacter = (Personaggio)Session["Personaggio"];
                using (HolonetEntities context = new HolonetEntities())
                {
                    DataAccessLayer.Rubrica elemento = new DataAccessLayer.Rubrica();
                    elemento.NumeroPG = currentCharacter.NumeroPG;
                    elemento.NumeroSalvato = long.Parse(txtNumero.Text.Trim());
                    elemento.NomeVisualizzato = txtNome.Text.Trim();
                    context.AddToRubricas(elemento);
                    context.SaveChanges();
                }
            }
            carica();
        }
    }
}
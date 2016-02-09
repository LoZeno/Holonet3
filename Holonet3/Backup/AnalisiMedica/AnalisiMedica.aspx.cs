using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;

namespace Holonet3.AnalisiMedica
{
    public partial class AnalisiMedica : HolonetPage
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
                    Personaggio character = (Personaggio)Session["Personaggio"];
                    IQueryable<AbilitaPersonaggio> ricerca;
                    int CanUse = 0;
                    using (HolonetEntities context = new HolonetEntities())
                    {
                        ricerca = (from abilita in context.AbilitaPersonaggios
                                       where abilita.NumeroPG == character.NumeroPG
                                       where abilita.CdAbilita == 3
                                       select abilita);
                        CanUse = ricerca.Count();
                    }
                    if (CanUse <= 0)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        Timer1.Interval = 30000;
                    }
                }
            }
        }

        protected void btnIdentifica(object sender, EventArgs e)
        {
            lblRisultato.Text = "Attendere, analisi in corso...";
            Timer1.Enabled = true;
        }

        protected void NewSearch(object sender, EventArgs e)
        {
            SvuotaControlli();
        }

        public void SvuotaControlli()
        {
            txtCodice.Text = string.Empty;
            lblRisultato.Text = string.Empty;
        }

        protected void TimerTick(object sender, EventArgs e)
        {
            string code = txtCodice.Text.Trim();
            using (HolonetEntities context = new HolonetEntities())
            {
                var enzimas = (from enzimi in context.EnzimaInfeziones
                               where enzimi.Enzima == code
                               select enzimi);
                if (enzimas.Count() > 0)
                {
                    var enzimaAnalizzato = enzimas.First();
                    if (!enzimaAnalizzato.Infezione1Reference.IsLoaded)
                    {
                        enzimaAnalizzato.Infezione1Reference.Load();
                    }
                    lblRisultato.Text = enzimaAnalizzato.Infezione1.Nome + ": " + enzimaAnalizzato.Infezione1.Descrizione;
                }
                else
                {
                    lblRisultato.Text = "Impossibile identificare l'enzima.";
                }
            }
            
            Timer1.Enabled = false;
        }


    }
}
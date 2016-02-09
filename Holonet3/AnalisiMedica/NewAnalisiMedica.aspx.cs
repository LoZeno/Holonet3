using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using CommonBusiness.Personaggi;
using DataAccessLayer;

namespace Holonet3.AnalisiMedica
{
    public partial class NewAnalisiMedica : HolonetPage
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
                    canUse = manager.HasSkill(LoggedCharacter.NumeroPG, 3);
                }
                if (canUse)
                {
                    PageViews.SetActiveView(viewIdentificazione);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        void qrReader_OnCodeDecoded(object sender, EventArgs e)
        {
            PageViews.SetActiveView(viewElaborazione);
            Timer1.Interval = 30000;
            Timer1.Enabled = true;
        }

        protected void TimerTick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            txtRisultato.Text = string.Empty;
            PageViews.SetActiveView(viewRisultato);
            Guid? uniqueCode = null;
            if (!string.IsNullOrWhiteSpace(qrReader.Code))
            {
                uniqueCode = new Guid(qrReader.Code);
            }
            PersonaggiManagerNew manager = new PersonaggiManagerNew(DatabaseContext);
            Personaggio characterFound = manager.GetCharacterByGUID(uniqueCode);
            if (characterFound != null)
            {
                if (characterFound.Infeziones.Count == 0)
                {
                    txtRisultato.Text = "Il soggetto risulta essere sano e privo di infezioni";
                }
                else
                {
                    foreach (var Infezione in characterFound.Infeziones)
                    {
                        txtRisultato.Text += Infezione.Nome + ": " + Infezione.Descrizione + "\r\n";
                    }
                }
            }
            else
            {
                txtRisultato.Text = "La sostanza analizzata non è sangue, perlomeno di nessuna specie conosciuta";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtRisultato.Text = string.Empty;
            PageViews.SetActiveView(viewIdentificazione);
        }
    }
}
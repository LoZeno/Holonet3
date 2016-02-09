using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.Messaggi
{
    public partial class SingleMessageControl : System.Web.UI.UserControl
    {
		public Personaggio refCharacter
		{
			get
			{
				object obj = ViewState["Personaggio"];
				if (obj != null)
				{
					return (Personaggio)obj;
				}
				return null;
			}
			set
			{
				ViewState["Personaggio"] = value;
			}
		}
		
		public string Mittente
        {
            get
            {
                return ViewState["Mittente"].ToString();
            }
            set
            {
                ViewState["Mittente"] = value;
            }
        }

        public string Titolo
        {
            get
            {
                return ViewState["Titolo"].ToString();
            }
            set
            {
                ViewState["Titolo"] = value;
            }
        }

        public bool? StatoLettura
        {
            get
            {
                object obj = ViewState["StatoLettura"];
                if (obj != null)
                {
                    return (bool)obj;
                }
                return false;
            }
            set
            {
                ViewState["StatoLettura"] = value;
            }
        }

        public long NumeroMissione
        {
            get
            {
                object obj = ViewState["NumeroMissione"];
                if (obj != null)
                {
                    return (long)obj;
                }
                return -1;
            }
            set
            {
                ViewState["NumeroMissione"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Carica()
        {
            lblMittente.Text = Mittente;
            lblTitolo.Text = Titolo;
            lblStatoLettura.Text = StatoLettura == true ? "Sì" : "No";
        }

        protected void lblTitolo_Click(object sender, EventArgs e)
        {
            PostaInArrivo elemento = null;
            using (HolonetEntities context = new HolonetEntities())
            {
                //Personaggio personaggioAttuale = (Personaggio)Session["Personaggio"];
				Personaggio personaggioAttuale = refCharacter;
                elemento = (from messaggio in context.PostaInArrivoes
                            where messaggio.NumeroMissione == NumeroMissione
                            where messaggio.NumeroPG == personaggioAttuale.NumeroPG
                            select messaggio).First();
                if (elemento != null)
                {
                    elemento.Letta = true;

                    if (!elemento.MissioneReference.IsLoaded)
                    {
                        elemento.MissioneReference.Load();
                        if (!elemento.Missione.PersonaggioReference.IsLoaded)
                        {
                            elemento.Missione.PersonaggioReference.Load();
                        }
                    }
                    context.SaveChanges();
                }
            }
            lblStatoLettura.Text = "Sì";
            ((IMessaggi)this.Page).MessaggioVisualizzato = elemento.Missione;
            ((IMessaggi)this.Page).IsInUscita = false;
            ((IMessaggi)this.Page).MostraMessaggio();
        }
    }
}
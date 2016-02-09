using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.Messaggi
{
    public partial class SingleSentMessageControl : System.Web.UI.UserControl
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

        public string Destinatari
        {
            get
            {
                return ViewState["Destinatari"].ToString();
            }
            set
            {
                ViewState["Destinatari"] = value;
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
            lblDestinatari.Text = Destinatari;
            lblTitolo.Text = Titolo;
        }

        protected void lblTitolo_Click(object sender, EventArgs e)
        {
            PostaInUscita elemento = null;

            using (HolonetEntities context = new HolonetEntities())
            {
                //Personaggio personaggioAttuale = (Personaggio)Session["Personaggio"];
				Personaggio personaggioAttuale = refCharacter;
                elemento = (from messaggio in context.PostaInUscitas
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

            ((IMessaggi)this.Page).MessaggioVisualizzato = elemento.Missione;
            ((IMessaggi)this.Page).IsInUscita = true;
            ((IMessaggi)this.Page).MostraMessaggioInUscita();
        }
    }
}
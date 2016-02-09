using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.CartellaPersonale
{
    public partial class SingleFile : System.Web.UI.UserControl
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

        public long Progressivo
        {
            get
            {
                object obj = ViewState["Progressivo"];
                if (obj != null)
                {
                    return (long)obj;
                }
                return -1;
            }
            set
            {
                ViewState["Progressivo"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Carica()
        {
            lblTitolo.Text = Titolo;
        }

        protected void lblTitolo_Click(object sender, EventArgs e)
        {
            MessaggioSalvato message = null;
            using (HolonetEntities context = new HolonetEntities())
            {
                //Personaggio personaggioAttuale = (Personaggio)Session["Personaggio"];
				Personaggio personaggioAttuale = refCharacter;
                var elements = (from files in context.MessaggioSalvatoes
                            where files.Progressivo == Progressivo
                            where files.NumeroPG == personaggioAttuale.NumeroPG
                            select files);
                if (elements.Count() > 0)
                {
                    message = elements.First();
                }

            }
            ((IFilePersonali)this.Page).FileDaMostrare = message;
            ((IFilePersonali)this.Page).MostraFile();
        }
    }
}
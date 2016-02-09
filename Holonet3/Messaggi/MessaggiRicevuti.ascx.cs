using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.Messaggi
{
    public partial class MessaggiRicevuti : System.Web.UI.UserControl
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

        public List<PostaInArrivo> Messaggi
        {
            get
            {
                object obj = ViewState["Messaggi"];
                if (obj != null)
                {
                    return (List<PostaInArrivo>)obj;
                }
                return new List<PostaInArrivo>();
            }
            set
            {
                ViewState["Messaggi"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Carica()
        {
            List<PostaInArrivo> content = Messaggi;
            repeatMessage.DataSource = content;
            repeatMessage.DataBind();
        }

        protected void repeatMessage_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void repeatMessage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PostaInArrivo singleMessage = (PostaInArrivo)e.Item.DataItem;

                SingleMessageControl RepeatedElement = (SingleMessageControl)(e.Item.FindControl("singleMessageView"));

				RepeatedElement.refCharacter = refCharacter;
                RepeatedElement.Mittente = singleMessage.Missione.Personaggio.Nome + " (NumeroPG: " + singleMessage.Missione.Personaggio.NumeroPG + ")";
                RepeatedElement.Titolo = singleMessage.Missione.Titolo;
                RepeatedElement.StatoLettura = singleMessage.Letta;
                RepeatedElement.NumeroMissione = singleMessage.NumeroMissione;

                RepeatedElement.Carica();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Text;

namespace Holonet3.Messaggi
{
    public partial class MessaggiInviati : System.Web.UI.UserControl
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

        public List<PostaInUscita> Messaggi
        {
            get
            {
                object obj = ViewState["Messaggi"];
                if (obj != null)
                {
                    return (List<PostaInUscita>)obj;
                }
                return new List<PostaInUscita>();
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
            List<PostaInUscita> content = Messaggi;
            repeatMessage.DataSource = content;
            repeatMessage.DataBind();
        }

        protected void repeatMessage_ItemCreated1(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void repeatMessage_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PostaInUscita singleMessage = (PostaInUscita)e.Item.DataItem;

                //Recupero l'elenco dei destinatari
                StringBuilder destinatari = new StringBuilder();
                using (HolonetEntities context = new HolonetEntities())
                {
                    var receivers = (from ricevuti in context.PostaInArrivoes
                                     where ricevuti.NumeroMissione == singleMessage.NumeroMissione
                                     select ricevuti.Personaggio);
                    foreach (var item in receivers)
                    {
						destinatari.Append(item.NumeroPG);
						destinatari.Append(" - ");
                        destinatari.Append(item.Nome);
                        destinatari.Append(", ");
                    }
                }

                SingleSentMessageControl RepeatedElement = (SingleSentMessageControl)(e.Item.FindControl("singleMessageView"));

				RepeatedElement.refCharacter = refCharacter;
                RepeatedElement.Destinatari = destinatari.ToString();
                RepeatedElement.Titolo = singleMessage.Missione.Titolo;
                RepeatedElement.NumeroMissione = singleMessage.NumeroMissione;

                RepeatedElement.Carica();
            }
        }
    }
}
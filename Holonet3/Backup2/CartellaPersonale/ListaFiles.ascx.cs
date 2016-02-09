using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.CartellaPersonale
{
    public partial class ListaFiles : System.Web.UI.UserControl
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

        public List<MessaggioSalvato> Files
        {
            get
            {
                object obj = ViewState["Files"];
                if (obj != null)
                {
                    return (List<MessaggioSalvato>)obj;
                }
                return null;
            }
            set
            {
                ViewState["Files"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

		/// <summary>
		/// Databind esplicito del controllo
		/// </summary>
        public void Carica()
        {
            List<MessaggioSalvato> files = Files;
            rptShowFile.DataSource = files;
            rptShowFile.DataBind();
        }

        protected void rptShowFile_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptShowFile_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                MessaggioSalvato singleItem = (MessaggioSalvato)e.Item.DataItem;

                SingleFile repeatedElement = (SingleFile)(e.Item.FindControl("showSingleFile"));

				repeatedElement.refCharacter = refCharacter;
                repeatedElement.Progressivo = singleItem.Progressivo;
                repeatedElement.Titolo = singleItem.Titolo;
                repeatedElement.Carica();
            }
        }
    }
}
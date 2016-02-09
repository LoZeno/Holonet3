using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;
using System.Configuration;

namespace Holonet3
{
	public partial class _Default : HolonetPage
	{
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["HolonetEntities"].ConnectionString;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                using (HolonetEntities context = new HolonetEntities(ConnectionString))
                {
                    var element = (from elm in context.Retes where elm.NumeroRete == 0 select elm).First();
                    if (element != null)
                    {
                        Page.Title = element.NomeRete;
                    }
                    if (LoggedCharacter != null)
                    {
                        lblNomePersonaggio.Text = LoggedCharacter.Nome;
                    }
                }
            }
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.Holodischi
{
	public partial class SingleHoloFile : System.Web.UI.UserControl
	{
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

		public long NumeroFile
		{
			get
			{
				object obj = ViewState["NumeroFile"];
				if (obj != null)
				{
					return (long)obj;
				}
				return -1;
			}
			set
			{
				ViewState["NumeroFile"] = value;
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
			HoloDiskFile singleFile = null;
			using (HolonetEntities context = new HolonetEntities())
			{
				singleFile = (from files in context.HoloDiskFiles
							  where files.Progressivo == Progressivo
							  where files.NumeroFile == NumeroFile
							  select files).First();
			}
			((LetturaDischi)this.Page).FileDaVisualizzare = singleFile;
			((LetturaDischi)this.Page).MostraFile();
		}
	}
}
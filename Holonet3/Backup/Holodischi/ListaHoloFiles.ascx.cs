using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace Holonet3.Holodischi
{
	public partial class ListaHoloFiles : System.Web.UI.UserControl
	{
		public List<HoloDiskFile> ListaFiles
		{
			get
			{
				object obj = ViewState["ListaFiles"];
				if (obj != null)
				{
					return (List<HoloDiskFile>)obj;
				}
				return null;
			}
			set
			{
				ViewState["ListaFiles"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void Carica()
		{
			List<HoloDiskFile> files = ListaFiles;
			rptHoloFile.DataSource = files;
			rptHoloFile.DataBind();
		}

		protected void rptHoloFile_ItemCreated(object sender, RepeaterItemEventArgs e)
		{

		}

		protected void rptHoloFile_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HoloDiskFile singleFile = (HoloDiskFile)e.Item.DataItem;

				SingleHoloFile repeatedControl = (SingleHoloFile)e.Item.FindControl("SingleFileView");

				repeatedControl.NumeroFile = singleFile.NumeroFile;
				repeatedControl.Titolo = singleFile.NomeFile;
				repeatedControl.Progressivo = singleFile.Progressivo;

				repeatedControl.Carica();
			}
		}
	}
}
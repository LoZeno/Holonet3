using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using HolonetWebControls;

namespace Holonet3.Holodischi
{
    public partial class LetturaDischi : HolonetPage
    {
		public DataAccessLayer.HoloDiskFile FileDaVisualizzare
		{
			get
			{
				object obj = ViewState["FileDaVisualizzare"];
				if (obj != null)
				{
					return (DataAccessLayer.HoloDiskFile)obj;
				}
				return null;
			}
			set
			{
				ViewState["FileDaVisualizzare"] = value;
			}
		}

		//protected void Page_PreInit(object sender, EventArgs e)
		//{
		//    if (Session["Tema"] != null)
		//    {
		//        Page.Theme = Session["Tema"].ToString();
		//    }
		//    else
		//    {
		//        Page.Theme = "TemaBlu";
		//    }
		//}

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
			lblNomeFile.Text = string.Empty;
			lblTesto.Text = string.Empty;
			string codice = txtCodiceDisco.Text.Trim();
			using (HolonetEntities context = new HolonetEntities())
			{
				var dischiIndividuati = (from dischi in context.HoloDisks
										where dischi.Codice == codice
										select dischi);
				var discoIndividuato = dischiIndividuati.First();

				if (discoIndividuato != null)
				{
					if (!discoIndividuato.HoloDiskFiles.IsLoaded)
					{
						discoIndividuato.HoloDiskFiles.Load();
					}
					listFiles.ListaFiles = discoIndividuato.HoloDiskFiles.ToList();
				}
				else
				{
					listFiles.ListaFiles = new List<HoloDiskFile>();
				}
			}

			if (listFiles.ListaFiles.Count > 0)
			{
				listFiles.Visible = true;
				listFiles.Carica();
			}
			else
			{
				listFiles.Visible = false;
			}
        }

		internal void MostraFile()
		{
			HoloDiskFile fileDaMostrare = FileDaVisualizzare;
			if (fileDaMostrare != null)
			{
				panFile.Visible = true;
				lblNomeFile.Text = fileDaMostrare.NomeFile;
				lblTesto.Text = fileDaMostrare.Contenuto;
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBusiness.HoloDischi;
using HolonetWebControls;
using DataAccessLayer;

namespace Holonet3.Holodischi
{
	public partial class NewLetturaDischi : HolonetPage
	{
		protected long ProgressivoDisco
		{
			get
			{
				object obj = ViewState["ProgressivoDisco"];
				if (obj != null)
				{
					return (long)obj;
				}
				return -1;
			}
			set
			{
				ViewState["ProgressivoDisco"] = value;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			qrReader.OnCodeDecoded += new EventHandler(qrReader_OnCodeDecoded);
			btnLista.Click += new EventHandler(btnLista_Click);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				svuotaControlli();
				PageViews.SetActiveView(viewLettore);
			}
		}

		private void svuotaControlli()
		{
			lblDescrizione.Text =
			lblNomeFile.Text =
			lblTesto.Text = string.Empty;
			grdFileList.DataSource = null;
			grdFileList.DataBind();
		}

		private void caricaFiles()
		{
			HoloDischiManager manager = new HoloDischiManager(DatabaseContext);
			grdFileList.DataSource = manager.GetFilesFromDisc(ProgressivoDisco);
			grdFileList.DataBind();
			PageViews.SetActiveView(viewElencoFiles);
		}

		private void mostraFile(long numeroFile)
		{
			HoloDischiManager manager = new HoloDischiManager(DatabaseContext);
			HoloDiskFile file = manager.GetSingleFile(this.ProgressivoDisco, numeroFile);
			lblNomeFile.Text = file.NomeFile;
			lblTesto.Text = file.Contenuto;
			PageViews.SetActiveView(viewMostraFile);
		}

		void btnLista_Click(object sender, EventArgs e)
		{
			PageViews.SetActiveView(viewElencoFiles);
		}

		protected void grdFileList_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			grdFileList.PageIndex = e.NewPageIndex;
			caricaFiles();
		}

		protected void grdFileList_RowClicked(object sender, HolonetWebControls.GridViewRowClickedEventArgs args)
		{
			string numeroFile = args.Row.Cells[0].Text;
			if (!string.IsNullOrWhiteSpace(numeroFile))
			{
				long messageNum = long.Parse(numeroFile);
				mostraFile(messageNum);
			}
		}

		void qrReader_OnCodeDecoded(object sender, EventArgs e)
		{
			string myCode = qrReader.Code;
			svuotaControlli();
			if (!string.IsNullOrWhiteSpace(myCode))
			{
				Guid uniqueCode;
				try
				{
					uniqueCode = new Guid(myCode);
				}
				catch
				{
					lblDescrizione.Text = "Cartellino non valido"; //Se il codice è un codice ad cazzum, non un GUID, è ovviamente un QR Code sbagliato
					return;
				}
				HoloDischiManager manager = new HoloDischiManager(DatabaseContext);
				HoloDisk disco = manager.GetDiskFromQRCode(uniqueCode);
				if (disco == null)
				{
					lblDescrizione.Text = "Non è un cartellino oggetto";
				}
				else
				{
					this.ProgressivoDisco = disco.Progressivo;
					caricaFiles();
				}
			}
		}
	}
}
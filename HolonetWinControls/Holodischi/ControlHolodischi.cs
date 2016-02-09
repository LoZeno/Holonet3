using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using DataAccessLayer;
using CommonBusiness.HoloDischi;
using Reports;

namespace HolonetWinControls.Holodischi
{
	public partial class ControlHolodischi : BaseManagerUserControl
	{
		#region membri privati
		private int startPage = 0;
		private short pageSize = 50;
		private HolonetEntities databaseContext;
		#endregion

		public ControlHolodischi()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		public override void LoadData()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				HoloDischiManager manager = new HoloDischiManager(databaseContext);
				var dischi = manager.GetPagedDisksList(startPage, pageSize);
				grdDischi.DataSource = dischi;
			}
		}

		private void grdDischi_SelectionChanged(object sender, EventArgs e)
		{
			if (grdDischi.SelectedRows.Count == 1)
			{
				long codiceDisco = (long)grdDischi.SelectedRows[0].Cells["Progressivo"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					HoloDischiManager manager = new HoloDischiManager(databaseContext);
					grdFiles.DataSource = manager.GetFilesFromDisc(codiceDisco);
				}
			}
			else
			{
				grdFiles.DataSource = null;
			}
		}

		private void btnStampa_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (grdDischi.SelectedRows.Count > 0)
			{
				FolderBrowserDialog selectFolder = new FolderBrowserDialog();
                var res = selectFolder.ShowDialog();
				if (res == DialogResult.OK)
				{
					string path = selectFolder.SelectedPath;
					using (databaseContext = CreateDatabaseContext())
					{
						HoloDischiManager manager = new HoloDischiManager(databaseContext);
						List<long> indexes = new List<long>();
						for (int i = 0; i < grdDischi.SelectedRows.Count; i++)
						{
							indexes.Add((long)grdDischi.SelectedRows[i].Cells["Progressivo"].Value);
						}
						List<HoloDisk> itemsToPrint = manager.GetDisksFromNumbers(indexes).ToList();
						if (itemsToPrint.Count == 1)
						{
							for (int i = 1; i < 10; i++)
							{
								itemsToPrint.Add(itemsToPrint[0]);
							}
						}
						CartelliniDatapad cartellini = new CartelliniDatapad(path + @"\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", itemsToPrint);
						cartellini.Save();
					}
					MessageBox.Show("Stampa avvenuta");
					OpenFolder(path);
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btnAddFile_Click(object sender, EventArgs e)
		{
			if (grdDischi.SelectedRows.Count == 1)
			{
				long progressivo = (long)grdDischi.SelectedRows[0].Cells["Progressivo"].Value;
				AggiungiFile newForm = new AggiungiFile(progressivo);
				newForm.ShowDialog();
				LoadData();
			}
		}

		private void btnEditFile_Click(object sender, EventArgs e)
		{
			if (grdFiles.SelectedRows.Count == 1)
			{
				long progressivo = (long)grdDischi.SelectedRows[0].Cells["Progressivo"].Value;
				long numeroFile = (long)grdFiles.SelectedRows[0].Cells["NumeroFile"].Value;
				AggiungiFile newForm = new AggiungiFile(progressivo, numeroFile);
				newForm.ShowDialog();
				LoadData();
			}
		}

		private void btnNuovoDisco_Click(object sender, EventArgs e)
		{
			CreaDatapad newForm = new CreaDatapad();
			newForm.ShowDialog();
			LoadData();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdDischi.SelectedRows.Count == 1)
			{
				long progressivo = (long)grdDischi.SelectedRows[0].Cells["Progressivo"].Value;
				CreaDatapad newForm = new CreaDatapad(progressivo);
				newForm.ShowDialog();
				LoadData();
			}
		}

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                using (databaseContext = CreateDatabaseContext())
                {
                    HoloDischiManager manager = new HoloDischiManager(databaseContext);
                    grdDischi.DataSource = manager.GetDiskByText(txtSearch.Text);
                }
            }
            else
            {
                LoadData();
            }
        }
	}
}

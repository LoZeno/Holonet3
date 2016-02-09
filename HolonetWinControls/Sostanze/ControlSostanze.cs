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
using CommonBusiness.Sostanze;
using Reports;

namespace HolonetWinControls.Sostanze
{
	public partial class ControlSostanze : BaseManagerUserControl
	{
		#region membri privati
		private int startPage = 0;
		private short pageSize = 50;
		private HolonetEntities databaseContext;
		#endregion

		public ControlSostanze()
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
                SostanzeManager manager = new SostanzeManager(databaseContext);
                cmbTipoSostanza.DataSource = manager.GetSubstancesTypes();
            }
		}

		#region metodi privati

        private void LoadSubstancesGrid()
        {
            if (cmbTipoSostanza.SelectedValue != null)
            {
                long tipoSostanze = (long)cmbTipoSostanza.SelectedValue;
                using (databaseContext = CreateDatabaseContext())
                {
                    SostanzeManager manager = new SostanzeManager(databaseContext);
                    //var sostanze = manager.GetPagedSubstancesList(startPage, pageSize);
                    var sostanze = manager.GetPagedSubstancesList(startPage, pageSize, tipoSostanze);
                    grdSostanze.DataSource = sostanze;
                }
            }
        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			InsertSostanza newForm = new InsertSostanza();
			newForm.ShowDialog();
            LoadSubstancesGrid();
		}

		private void btnClona_Click(object sender, EventArgs e)
		{
			if (grdSostanze.SelectedRows.Count == 1)
			{
				long progressivoOggetto = (long)grdSostanze.SelectedRows[0].Cells["Progressivo"].Value;
				InsertSostanza newForm = new InsertSostanza(progressivoOggetto, true);
				newForm.ShowDialog();
                LoadSubstancesGrid();
			}
		}

		private void btnStampa_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (grdSostanze.SelectedRows.Count > 0)
			{
				FolderBrowserDialog selectFolder = new FolderBrowserDialog();
				var res = selectFolder.ShowDialog();
				if (res == DialogResult.OK)
				{
					string path = selectFolder.SelectedPath;
                    long tipoSostanze = (long)cmbTipoSostanza.SelectedValue;
					using (databaseContext = CreateDatabaseContext())
					{
						SostanzeManager manager = new SostanzeManager(databaseContext);
						List<long> indexes = new List<long>();
						for (int i = 0; i < grdSostanze.SelectedRows.Count; i++)
						{
							indexes.Add((long)grdSostanze.SelectedRows[i].Cells["Progressivo"].Value);
						}
						List<NewSostanze> itemsToPrint = manager.GetSubstancesFromNumbers(indexes).ToList<NewSostanze>();
                        if (itemsToPrint.Count == 1 && chkMultiplePrint.Checked)
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                itemsToPrint.Add(itemsToPrint[0]);
                            }
                        }
                        if (tipoSostanze == 0)
                        {
                            CartelliniIngredienti cartellini = new CartelliniIngredienti(path + @"\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", itemsToPrint);
                            cartellini.Save();
                        }
                        else
                        {
                            CartelliniSostanze cartellini = new CartelliniSostanze(path + @"\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", itemsToPrint);
                            cartellini.Save();
                        }
					}
					MessageBox.Show("Stampa avvenuta");
					OpenFolder(path);
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void LoadComponentsGrid()
		{
			if (grdSostanze.SelectedRows.Count == 1)
			{
				long progressivo = (long)(grdSostanze.SelectedRows[0].Cells["Progressivo"].Value);
				using (databaseContext = CreateDatabaseContext())
				{
					SostanzeManager manager = new SostanzeManager(databaseContext);
					grdIngredienti.DataSource = manager.GetComponentsBySubstance(progressivo);
				}
			}
			else
			{
				grdIngredienti.DataSource = null;
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdSostanze.SelectedRows.Count == 1)
			{
				long progressivoOggetto = (long)grdSostanze.SelectedRows[0].Cells["Progressivo"].Value;
				InsertSostanza newForm = new InsertSostanza(progressivoOggetto);
				newForm.ShowDialog();
                LoadSubstancesGrid();
			}
		}

		private void btnAggiungiComponente_Click(object sender, EventArgs e)
		{
			if (grdSostanze.SelectedRows.Count == 1)
			{
				long progressivoOggetto = (long)grdSostanze.SelectedRows[0].Cells["Progressivo"].Value;
				AggiungiComponente newForm = new AggiungiComponente(progressivoOggetto);
				newForm.ShowDialog();
				LoadComponentsGrid();
			}
		}

		private void lnkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			startPage -= 50;
			if (startPage < 0)
			{
				startPage = 0;
			}
            LoadSubstancesGrid();
		}

		private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (databaseContext = CreateDatabaseContext())
			{
				SostanzeManager manager = new SostanzeManager(databaseContext);
				int max = manager.Count();
				startPage += 50;
				if (startPage >= max)
				{
					startPage = max - 50;
					if (startPage < 0)
					{
						startPage = 0;
					}
				}
			}
            LoadSubstancesGrid();
		}

		private void grdSostanze_SelectionChanged(object sender, EventArgs e)
		{
			LoadComponentsGrid();
		}

		private void btnEliminaComponente_Click(object sender, EventArgs e)
		{
			if (grdIngredienti.SelectedRows.Count == 1)
			{
				long progressivoOggetto = (long)grdSostanze.SelectedRows[0].Cells["Progressivo"].Value;
				long numeroIngrediente = (long)grdIngredienti.SelectedRows[0].Cells["NumeroIngrediente"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					SostanzeManager manager = new SostanzeManager(databaseContext);
					bool res = manager.RemoveComponentFromSubstance(progressivoOggetto, numeroIngrediente);
					if (res)
					{
						databaseContext.SaveChanges();
						LoadComponentsGrid();
					}
					else
					{
						MessageBox.Show("Errore durante l'eliminazione");
					}
				}
			}
		}

        private void cmbTipoSostanza_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTipoSostanza.SelectedValue != null)
            {
                startPage = 0;
                pageSize = 50;
                txtSearch.Text = string.Empty;
                LoadSubstancesGrid();
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string text = txtSearch.Text;
                long tipo = (long)cmbTipoSostanza.SelectedValue;
                using (databaseContext = CreateDatabaseContext())
                {
                    SostanzeManager manager = new SostanzeManager(databaseContext);
                    grdSostanze.DataSource = manager.GetSubstancesFromText(text, tipo);
                }
            }
            else
            {
                LoadSubstancesGrid();
            }
        }
    }
}

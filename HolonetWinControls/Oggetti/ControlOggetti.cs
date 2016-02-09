using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using CommonBusiness.OggettiManager;
using DataAccessLayer;
using Reports;

namespace HolonetWinControls.Oggetti
{
	public partial class ControlOggetti : BaseManagerUserControl
	{
		#region membri privati
		private int startPage = 0;
		private short pageSize = 50;
		private HolonetEntities databaseContext;
		#endregion


		public ControlOggetti()
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
                OggettiManager manager = new OggettiManager(databaseContext);
                //var oggetti = manager.GetPagedItemsList(startPage, pageSize);
                //grdOggetti.DataSource = oggetti;
                cmbTipoOggetto.DataSource = manager.GetItemTypes();
			}
		}

		#region metodi privati
		private void btnAdd_Click(object sender, EventArgs e)
		{
			InsertOggetto newForm = new InsertOggetto();
			newForm.ShowDialog();
            LoadItemsGrid();
		}

		private void btnAggiungiComponente_Click(object sender, EventArgs e)
		{
			if (grdOggetti.SelectedRows.Count == 1)
			{
				long progressivoOggetto = (long)grdOggetti.SelectedRows[0].Cells["Progressivo"].Value;
				AggiungiComponente newForm = new AggiungiComponente(progressivoOggetto);
				newForm.ShowDialog();
				LoadComponentsGrid();
			}
		}

		private void btnClona_Click(object sender, EventArgs e)
		{
            if (grdOggetti.SelectedRows.Count == 1)
            {
                long progressivoOggetto = (long)grdOggetti.SelectedRows[0].Cells["Progressivo"].Value;
                InsertOggetto newForm = new InsertOggetto(progressivoOggetto, true);
                newForm.ShowDialog();
                LoadItemsGrid();
            }
		}

		private void btnStampa_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
            if (grdOggetti.SelectedRows.Count > 0)
            {
                FolderBrowserDialog selectFolder = new FolderBrowserDialog();
                var res = selectFolder.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string path = selectFolder.SelectedPath;
                    using (databaseContext = CreateDatabaseContext())
                    {
                        OggettiManager manager = new OggettiManager(databaseContext);
                        List<long> indexes = new List<long>();
                        for (int i = 0; i < grdOggetti.SelectedRows.Count; i++)
                        {
                            indexes.Add((long)grdOggetti.SelectedRows[i].Cells["Progressivo"].Value);
                        }
                        List<NewOggetti> itemsToPrint = manager.GetItemsFromNumbers(indexes).ToList<NewOggetti>();
                        if (itemsToPrint.Count == 1 && chkMultiplePrint.Checked)
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                itemsToPrint.Add(itemsToPrint[0]);
                            }
                        }
                        CartelliniOggetto cartellini = new CartelliniOggetto(path + @"\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +DateTime.Now.Hour + "-" +DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", itemsToPrint);
                        cartellini.Save();
                    }
                    MessageBox.Show("Stampa avvenuta");
                    OpenFolder(path);
                }
            }
			Cursor.Current = Cursors.Default;
		}

		private void LoadComponentsGrid()
		{
			if (grdOggetti.SelectedRows.Count == 1)
			{
				long progressivo = (long)(grdOggetti.SelectedRows[0].Cells["Progressivo"].Value);
				using (databaseContext = CreateDatabaseContext())
				{
					OggettiManager manager = new OggettiManager(databaseContext);
					grdIngredienti.DataSource = manager.GetComponentsByItem(progressivo);
				}
			}
			else
			{
				grdIngredienti.DataSource = null;
			}
		}

		private void grdOggetti_SelectionChanged(object sender, EventArgs e)
		{
			LoadComponentsGrid();
		}

		private void lnkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			startPage -= 50;
			if (startPage < 0)
			{
				startPage = 0;
			}
            LoadItemsGrid();
		}

		private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (databaseContext = CreateDatabaseContext())
			{
				OggettiManager manager = new OggettiManager(databaseContext);
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
            LoadItemsGrid();
		}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdOggetti.SelectedRows.Count == 1)
            {
                long progressivoOggetto = (long)grdOggetti.SelectedRows[0].Cells["Progressivo"].Value;
                InsertOggetto newForm = new InsertOggetto(progressivoOggetto);
                newForm.ShowDialog();
                LoadItemsGrid();
            }
        }

        #endregion

		private void btnEliminaComponente_Click(object sender, EventArgs e)
		{
			if (grdIngredienti.SelectedRows.Count == 1)
			{
				long progressivoOggetto = (long)grdOggetti.SelectedRows[0].Cells["Progressivo"].Value;
				long numeroIngrediente = (long)grdIngredienti.SelectedRows[0].Cells["NumeroIngrediente"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					OggettiManager manager = new OggettiManager(databaseContext);
					bool res = manager.RemoveComponentFromItem(progressivoOggetto, numeroIngrediente);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string text = txtSearch.Text;
                using (databaseContext = CreateDatabaseContext())
                {
                    OggettiManager manager = new OggettiManager(databaseContext);
                    if (cmbTipoOggetto.SelectedValue == null || (long)cmbTipoOggetto.SelectedValue == -1)
                    {
                        grdOggetti.DataSource = manager.GetItemsFromText(text);
                    }
                    else
                    {
                        grdOggetti.DataSource = manager.GetItemsFromText(text, (long)cmbTipoOggetto.SelectedValue);
                    }
                }
            }
            else
            {
                LoadItemsGrid();
            }
        }

        private void cmbTipoOggetto_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTipoOggetto.SelectedValue != null)
            {
                startPage = 0;
                pageSize = 50;
                txtSearch.Text = string.Empty;
                LoadItemsGrid();
            }
        }

        private void LoadItemsGrid()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                OggettiManager manager = new OggettiManager(databaseContext);
                IList<NewOggetti> oggetti;
                if (cmbTipoOggetto.SelectedValue != null && (long)cmbTipoOggetto.SelectedValue != -1)
                {
                    long tipoOggetti = (long)cmbTipoOggetto.SelectedValue;
                    oggetti = manager.GetPagedItemsList(startPage, pageSize, tipoOggetti);
                }
                else
                {
                    oggetti = manager.GetPagedItemsList(startPage, pageSize);
                    
                }
                grdOggetti.DataSource = oggetti;
            }
        }
    }
}

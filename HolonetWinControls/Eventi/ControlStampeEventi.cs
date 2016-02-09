using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using CommonBusiness.Eventi;
using DataAccessLayer;
using Reports;

namespace HolonetWinControls.Eventi
{
    public partial class ControlStampeEventi : BaseManagerUserControl
    {
        #region private members
        private int startPage = 0;
        private short pageSize = 50;
        private EventiManagerNew manager = null;
        private HolonetEntities databaseContext;

        #endregion

        public ControlStampeEventi()
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
            {
                using (databaseContext = CreateDatabaseContext())
                {
                    manager = new EventiManagerNew(databaseContext);
                    var events = manager.GetPagedEventsList(startPage, pageSize);
                    grdEventi.DataSource = events;
                }
            }
        }

        private void grdEventi_SelectionChanged(object sender, EventArgs e)
        {
			loadSubGrids();
        }

        /// <summary>
        /// Carica i dati della griglia Eventi
        /// </summary>
        public override void LoadData()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                manager = new EventiManagerNew(databaseContext);
                var events = manager.GetPagedEventsList(startPage, pageSize);
                grdEventi.DataSource = events;
            }
        }

		private void loadSubGrids()
		{
			if (grdEventi.SelectedRows.Count == 1)
			{
				if (grdEventi.Columns.Contains("Numero") && grdEventi.SelectedRows[0].Cells["Numero"].Value != null)
				{
					long codEvento = long.Parse(grdEventi.SelectedRows[0].Cells["Numero"].Value.ToString());
					using (databaseContext = CreateDatabaseContext())
					{
						manager = new EventiManagerNew(databaseContext);
						grdCartellini.DataSource = manager.GetItemsToPrint(codEvento);
						grdDischi.DataSource = manager.GetDisksToPrint(codEvento);
					}
				}
			}
			else
			{
				grdCartellini.DataSource = null;
				grdDischi.DataSource = null;
			}
		}

        private void lnkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            startPage -= 50;
            if (startPage < 0)
            {
                startPage = 0;
            }
            LoadData();
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int max =0;
            using (databaseContext = CreateDatabaseContext())
            {
                manager = new EventiManagerNew(databaseContext);
                max = manager.Count();
            }
            startPage += 50;
            if (startPage >= max)
            {
                startPage = max - 50;
                if (startPage < 0)
                {
                    startPage = 0;
                }
            }
            LoadData();
		}

		private void btnStampa_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (grdEventi.SelectedRows.Count == 1)
			{
				FolderBrowserDialog selectFolder = new FolderBrowserDialog();
				var res = selectFolder.ShowDialog();
				if (res == DialogResult.OK)
				{
					string path = selectFolder.SelectedPath;
					long cdEvento = (long)grdEventi.SelectedRows[0].Cells["Numero"].Value;
					using (databaseContext = CreateDatabaseContext())
					{
						EventiManagerNew manager = new EventiManagerNew(databaseContext);
						IList<NewOggetti> allPrintableItems = manager.GetPrintableItems(cdEvento);
                        if (allPrintableItems.Count > 0)
                        {
                            CartelliniOggetto cartelliniOggetti = new CartelliniOggetto(path + @"\Oggetti-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", allPrintableItems);
                            cartelliniOggetti.Save();
                        }
						IList<NewSostanze> allPrintableSubstances = manager.GetPrintableSubstances(cdEvento);
                        if (allPrintableSubstances.Count > 0)
                        {
                            CartelliniSostanze cartelliniSostanze = new CartelliniSostanze(path + @"\Sostanze-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", allPrintableSubstances);
                            cartelliniSostanze.Save();
                        }
						IList<NewSostanze> allPrintableIngredients = manager.GetPrintableIngredients(cdEvento);
                        if (allPrintableIngredients.Count > 0)
                        {
                            CartelliniIngredienti cartelliniIngredienti = new CartelliniIngredienti(path + @"\Ingredienti-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", allPrintableIngredients);
                            cartelliniIngredienti.Save();
                        }
						IList<HoloDisk> allPrintableDatapad = manager.GetPrintableHolodisks(cdEvento);
                        if (allPrintableDatapad.Count > 0)
                        {
                            CartelliniDatapad cartelliniDatapad = new CartelliniDatapad(path + @"\Datapad-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf", allPrintableDatapad);
                            cartelliniDatapad.Save();
                        }
					}
					MessageBox.Show("Stampa avvenuta");
					OpenFolder(path);
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btnAggiungiElemento_Click(object sender, EventArgs e)
		{
			if (grdEventi.SelectedRows.Count == 1)
			{
				if (grdEventi.Columns.Contains("Numero") && grdEventi.SelectedRows[0].Cells["Numero"].Value != null)
				{
					long codEvento = long.Parse(grdEventi.SelectedRows[0].Cells["Numero"].Value.ToString());
					AggiungiElementoAEvento newForm = new AggiungiElementoAEvento(codEvento);
					newForm.ShowDialog();
					this.loadSubGrids();
				}
			}
		}

		private void btnModificaElemento_Click(object sender, EventArgs e)
		{
			if (grdCartellini.SelectedRows.Count == 1)
			{
				DialogResult confirm = MessageBox.Show("Eliminare dalla stampa l'Oggetto/Sostanza selezionato/a?", "Conferma", MessageBoxButtons.YesNo);
				if (confirm == DialogResult.Yes)
				{
					long codEvento = long.Parse(grdEventi.SelectedRows[0].Cells["Numero"].Value.ToString());
					long progElemento = long.Parse(grdCartellini.SelectedRows[0].Cells["Progressivo"].Value.ToString());
					using (databaseContext = CreateDatabaseContext())
					{
						EventiManagerNew manager = new EventiManagerNew(databaseContext);
						bool result = manager.UpdateElementsCopiesToPrint(codEvento, progElemento, 0);
						if (!result)
						{
							MessageBox.Show("Si è verificato un errore");
						}
						else
						{
							databaseContext.SaveChanges();
						}
						loadSubGrids();
					}
				}
			}
		}

		private void btnAggiungiDisco_Click(object sender, EventArgs e)
		{
			if (grdEventi.SelectedRows.Count == 1)
			{
				if (grdEventi.Columns.Contains("Numero") && grdEventi.SelectedRows[0].Cells["Numero"].Value != null)
				{
					long codEvento = long.Parse(grdEventi.SelectedRows[0].Cells["Numero"].Value.ToString());
					AggiungiDiscoAEvento newForm = new AggiungiDiscoAEvento(codEvento);
					newForm.ShowDialog();
					this.loadSubGrids();
				}
			}
		}

		private void btnModificaDisco_Click(object sender, EventArgs e)
		{
			if (grdDischi.SelectedRows.Count == 1)
			{
				DialogResult confirm = MessageBox.Show("Eliminare dalla stampa l'Holodisco/Datapad selezionato?", "Conferma", MessageBoxButtons.YesNo);
				if (confirm == DialogResult.Yes)
				{
					long codEvento = long.Parse(grdEventi.SelectedRows[0].Cells["Numero"].Value.ToString());
					long progDisco = long.Parse(grdDischi.SelectedRows[0].Cells["Progressivo"].Value.ToString());
					using (databaseContext = CreateDatabaseContext())
					{
						EventiManagerNew manager = new EventiManagerNew(databaseContext);
						bool result = manager.UpdateHolodiskCopiesToPrint(codEvento, progDisco, 0);
						if (!result)
						{
							MessageBox.Show("Si è verificato un errore");
						}
						else
						{
							databaseContext.SaveChanges();
						}
						loadSubGrids();
					}
				}
			}
		}
    }
}

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
using CommonBusiness.Personaggi;
using CommonBusiness.Infezioni;

namespace HolonetWinControls.Infezioni
{
	public partial class ControlInfezioni : BaseManagerUserControl
    {
        #region membri privati
        private HolonetEntities databaseContext;
        private int startPage = 0;
        private short pageSize = 50;
        #endregion

        public ControlInfezioni()
		{
			InitializeComponent();
		}

        public override void LoadData()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
                grdPersonaggi.DataSource = manager.GetPagedCharacters(startPage, pageSize);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                using (databaseContext = CreateDatabaseContext())
                {
                    PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
                    grdPersonaggi.DataSource = manager.GetCharactersByName(txtSearch.Text);
                }
            }
            else
            {
                LoadData();
            }
        }

        private void LoadMalattie()
        {
            if (grdPersonaggi.SelectedRows.Count == 1)
            {
                long numeroPG = (long)grdPersonaggi.SelectedRows[0].Cells["NumeroPG"].Value;
                using (databaseContext = CreateDatabaseContext())
                {
                    InfezioniManager manager = new InfezioniManager(databaseContext);
                    grdMalattie.DataSource = manager.GetInfectionsByCharacter(numeroPG);
                }
            }
            else
            {
                grdMalattie.DataSource = new List<Infezione>();
            }
        }

        private void grdPersonaggi_SelectionChanged(object sender, EventArgs e)
        {
            LoadMalattie();
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
            using (databaseContext = CreateDatabaseContext())
            {
                PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
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
            LoadData();
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            CreaInfezione newForm = new CreaInfezione();
            newForm.ShowDialog();
        }

        private void btnAggiungiInfezione_Click(object sender, EventArgs e)
        {
            if (grdPersonaggi.SelectedRows.Count == 1)
            {
                long numeroPG = (long)grdPersonaggi.SelectedRows[0].Cells["NumeroPG"].Value;
                AggiungiInfezione newForm = new AggiungiInfezione(numeroPG);
                newForm.ShowDialog();
                LoadMalattie();
            }
        }

        private void btnRimuoviInfezione_Click(object sender, EventArgs e)
        {
            if (grdMalattie.SelectedRows.Count == 1)
            {
                DialogResult res = MessageBox.Show("Vuoi rimuovere questa malattia dal personaggio?", "Sei sicuro?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    long numeroPG = (long)grdPersonaggi.SelectedRows[0].Cells["NumeroPG"].Value;
                    long progressivo = (long)grdMalattie.SelectedRows[0].Cells["Progressivo"].Value;
                    using (databaseContext = CreateDatabaseContext())
                    {
                        InfezioniManager manager = new InfezioniManager(databaseContext);
                        bool result = manager.RemoveInfectionFromCharacter(numeroPG, progressivo);
                        if (result)
                        {
                            databaseContext.SaveChanges();
                            MessageBox.Show("Infezione eliminata correttamente");
                            LoadMalattie();
                        }
                        else
                        {
                            MessageBox.Show("C'è stato un errore nel salvataggio");
                            LoadMalattie();
                        }
                    }
                }
            }
        }
	}
}

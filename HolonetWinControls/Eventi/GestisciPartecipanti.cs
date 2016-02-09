using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using DataAccessLayer;
using CommonBusiness.Eventi;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Eventi
{
    public partial class GestisciPartecipanti : ToolboxManagerForm
    {
        private HolonetEntities databaseContext;
        private long? cdEvento = null;

        public GestisciPartecipanti()
        {
            InitializeComponent();
        }

        public GestisciPartecipanti(long CdEvento)
            :this()
        {
            cdEvento = CdEvento;
            LoadData();
        }

        private void LoadData()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                EventiManagerNew manager = new EventiManagerNew(databaseContext);
                grdPartecipanti.DataSource = manager.GetPartecipation(cdEvento.Value);
            }
            calcolaIncasso();
            calcolaPunti();
        }

        private void calcolaIncasso()
        {
            float ricavoTotale = 0;
            foreach (DataGridViewRow riga in grdPartecipanti.Rows)
            {
                if ((bool)riga.Cells["Pagato"].Value)
                {
                    ricavoTotale += (float)riga.Cells["Prezzo"].Value;
                }
            }
            txtRicavo.Text = ricavoTotale.ToString();
        }

        private void calcolaPunti()
        {
            foreach (DataGridViewRow riga in grdPartecipanti.Rows)
            {
                if ((bool)riga.Cells["Partecipato"].Value)
                {
                    riga.Cells["Punti"].Value = (long)riga.Cells["PX"].Value + (long)numPxBonus.Value;
                }
                else
                {
                    riga.Cells["Punti"].Value = (long)riga.Cells["PX"].Value;
                }
            }
        }

        private void numPxBonus_ValueChanged(object sender, EventArgs e)
        {
            calcolaPunti();
        }

        private void grdPartecipanti_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow riga in grdPartecipanti.Rows)
            {
                riga.Cells["Punti"].Value = riga.Cells["PX"].Value;
            }
        }

        private void chkTuttiPagato_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow riga in grdPartecipanti.Rows)
            {
                riga.Cells["Pagato"].Value = chkTuttiPagato.Checked;
            }
        }

        private void chkTuttiPartecipato_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow riga in grdPartecipanti.Rows)
            {
                riga.Cells["Partecipato"].Value = chkTuttiPartecipato.Checked;
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salvaDatiPartecipanti(bool chiudiEvento)
        {
            DialogResult result = MessageBox.Show("ATTENZIONE! Una volta che è stato segnato che un personaggio ha partecipato ad un evento, gli vengono assegnati i PX e non sarà più possibile rimuoverli. Per togliere PX ad un personaggio, usare il tab \"Giocatori e Personaggi\". Si vuole proseguire e confermare le modifiche?", "CONFERMA SALVATAGGIO", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
				Cursor.Current = Cursors.WaitCursor;
                using (databaseContext = CreateDatabaseContext())
                {
                    EventiManagerNew manager = new EventiManagerNew(databaseContext);
                    bool res = true;
                    foreach (DataGridViewRow riga in grdPartecipanti.Rows)
                    {
                        res = manager.UpdateCharacterSubscriptionsAndPX((long)riga.Cells["NumeroPG"].Value, cdEvento.Value, (bool)riga.Cells["Pagato"].Value, DateTime.Now, (bool)riga.Cells["Partecipato"].Value, (long)riga.Cells["Punti"].Value);
                        if (!res)
                        {
                            MessageBox.Show("Errore durante il salvataggio dell'iscrizione del pg " + (long)riga.Cells["NumeroPG"].Value);
                        }
                    }
                    if (chiudiEvento)
                    {
                        calcolaIncasso();
                        float incasso = float.Parse(txtRicavo.Text.Trim());
                        res = manager.CloseEvent(cdEvento.Value, incasso);
                    }
                    if (res)
                    {
                        databaseContext.SaveChanges();
                        MessageBox.Show("Salvataggio avvenuto correttamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("E' avvenuto un errore, ricontrollare i dati");
                    }
                }
            }
			Cursor.Current = Cursors.Default;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            salvaDatiPartecipanti(false);
        }

        private void btnSalvaEChiudi_Click(object sender, EventArgs e)
        {
            salvaDatiPartecipanti(true);
        }

        private void grdPartecipanti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            calcolaIncasso();
            calcolaPunti();
        }

        private void grdPartecipanti_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calcolaIncasso();
            calcolaPunti();
        }

    }
}

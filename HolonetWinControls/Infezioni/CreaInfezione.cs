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
using CommonBusiness.Infezioni;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Infezioni
{
    public partial class CreaInfezione : ToolboxManagerForm
    {
        private HolonetEntities databaseContext;

        public CreaInfezione()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                InfezioniManager manager = new InfezioniManager(databaseContext);
                lstInfezioni.DataSource = manager.GetAllInfections();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Inserire un nome per l'infezione");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescrizioneNuovo.Text))
            {
                MessageBox.Show("Inserire una descrizione degli effetti");
                return false;
            }
            return true;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                using (databaseContext = CreateDatabaseContext())
                {
                    InfezioniManager manager = new InfezioniManager(databaseContext);
                    bool res = manager.InsertNewInfection(txtNome.Text, txtDescrizioneNuovo.Text);
                    if (res)
                    {
                        databaseContext.SaveChanges();
                        MessageBox.Show("Infezione inserita correttamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("C'è stato un errore durante il salvataggio");
                    }
                }
            }
        }

        private void lstInfezioni_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstInfezioni.SelectedValue != null)
            {
                long progressivo = (long)lstInfezioni.SelectedValue;
                using (databaseContext = CreateDatabaseContext())
                {
                    InfezioniManager manager = new InfezioniManager(databaseContext);
                    txtDescrizioneSelezionato.Text = manager.GetInfectionDescription(progressivo);
                }
            }
            else
            {
                txtDescrizioneSelezionato.Text = string.Empty;
            }
        }
    }
}

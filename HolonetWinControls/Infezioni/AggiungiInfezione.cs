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
    public partial class AggiungiInfezione : ToolboxManagerForm
    {
        private HolonetEntities databaseContext;
        private long? numeroPG;

        public AggiungiInfezione()
        {
            InitializeComponent();
            LoadData();
        }

        public AggiungiInfezione(long NumeroPG)
            : this()
        {
            numeroPG = NumeroPG;
        }

        private void LoadData()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                InfezioniManager manager = new InfezioniManager(databaseContext);
                lstInfezioni.DataSource = manager.GetAllInfections();
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
                    txtDescrizione.Text = manager.GetInfectionDescription(progressivo);
                }
            }
            else
            {
                txtDescrizione.Text = string.Empty;
            }
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (lstInfezioni.SelectedItems.Count == 1 && numeroPG.HasValue)
            {
                DialogResult res = MessageBox.Show("Vuoi aggiungere questa malattia al personaggio " + numeroPG.Value.ToString() + "?", "Sei sicuro?", MessageBoxButtons.YesNo);
                long progressivo = (long)lstInfezioni.SelectedValue;
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    using (databaseContext = CreateDatabaseContext())
                    {
                        InfezioniManager manager = new InfezioniManager(databaseContext);
                        bool result = manager.AddInfectionToCharacter(numeroPG.Value, progressivo);
                        if (result)
                        {
                            databaseContext.SaveChanges();
                            MessageBox.Show("Infezione aggiunta al personaggio");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("C'è stato un problema durante il salvataggio");
                        }
                    }
                }
            }
        }
    }
}

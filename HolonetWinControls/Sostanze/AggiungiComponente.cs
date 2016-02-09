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
using CommonBusiness.Sostanze;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Sostanze
{
    public partial class AggiungiComponente : ToolboxManagerForm
	{
		private long progressivoOggettoPadre;
		private HolonetEntities context = null;
		
		public AggiungiComponente(long progressivoOggetto)
			: this()
		{
			progressivoOggettoPadre = progressivoOggetto;
		}

		public AggiungiComponente()
		{
			InitializeComponent();
			PopulateCombo();
		}

        private void PopulateList()
        {
            if (cmbTipoSostanza.SelectedValue != null)
            {
                long tipoSostanza = (long)cmbTipoSostanza.SelectedValue;
                using (context = CreateDatabaseContext())
                {
                    SostanzeManager manager = new SostanzeManager(context);
                    lstComponenti.ValueMember = "Progressivo";
                    lstComponenti.DisplayMember = "Nome";
                    lstComponenti.DataSource = manager.GetSubstancesForCombo(tipoSostanza);
                }
            }
        }

		private void PopulateCombo()
		{
            using (context = CreateDatabaseContext())
            {
                SostanzeManager manager = new SostanzeManager(context);
                cmbTipoSostanza.DataSource = manager.GetSubstancesTypes();
            }
		}

		private void lstComponenti_SelectedValueChanged(object sender, EventArgs e)
		{
			if (lstComponenti.SelectedItems.Count > 0)
			{
				long progressivoOggetto = (long)lstComponenti.SelectedValue;
				using (context = CreateDatabaseContext())
				{
					SostanzeManager manager = new SostanzeManager(context);
					txtEffetto.Text = manager.GetEffectOfSubstance(progressivoOggetto) + "\n Valore di efficacia: " + manager.GetEffectValueOfSubstance(progressivoOggetto);
				}
			}
		}

		private void btnAggiungi_Click(object sender, EventArgs e)
		{
			if (lstComponenti.SelectedItems.Count > 0)
			{
				DialogResult res = MessageBox.Show("Vuoi aggiungere questo elemento alla lista degli ingredienti?", "Sei sicuro?", MessageBoxButtons.YesNo);
				if (res == System.Windows.Forms.DialogResult.Yes)
				{
					using (context = CreateDatabaseContext())
					{
						long progressivoOggetto = (long)lstComponenti.SelectedValue;
						SostanzeManager manager = new SostanzeManager(context);
						bool res2 = manager.AddComponentToSubstance(progressivoOggettoPadre, progressivoOggetto);
						if (res2)
						{
							context.SaveChanges();
							this.Close();
						}
						else
						{
							MessageBox.Show("C'è stato un errore, chiedi allo Zeno");
						}
					}
				}
			}
		}

        private void cmbTipoSostanza_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateList();
        }
	}
}

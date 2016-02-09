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
using CommonBusiness.OggettiManager;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Oggetti
{
    public partial class AggiungiComponente : ToolboxManagerForm
	{
		private long progressivoOggettoPadre;
		private HolonetEntities context	 = null;

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
            if (cmbTipoOggetto.SelectedValue != null)
            {
                long tipoOggetto = (long)cmbTipoOggetto.SelectedValue;
                using (context = CreateDatabaseContext())
                {
                    OggettiManager manager = new OggettiManager(context);
                    lstComponenti.ValueMember = "Progressivo";
                    lstComponenti.DisplayMember = "Nome";
                    if (tipoOggetto != -1)
                    {
                        lstComponenti.DataSource = manager.GetItemsForCombo(tipoOggetto);
                    }
                    else
                    {
                        lstComponenti.DataSource = manager.GetItemsForCombo();
                    }
                }
            }
        }

		private void PopulateCombo()
		{
            using (context = CreateDatabaseContext())
            {
                OggettiManager manager = new OggettiManager(context);
                cmbTipoOggetto.DataSource = manager.GetItemTypes();
            }
		}

		private void lstComponenti_SelectedValueChanged(object sender, EventArgs e)
		{
			if (lstComponenti.SelectedItems.Count > 0)
			{
				long progressivoOggetto = (long)lstComponenti.SelectedValue;
				using (context = CreateDatabaseContext())
				{
					OggettiManager manager = new OggettiManager(context);
					txtEffetto.Text = manager.GetEffectOfItem(progressivoOggetto);
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
						OggettiManager manager = new OggettiManager(context);
						bool res2 = manager.AddComponentToItem(progressivoOggettoPadre, progressivoOggetto);
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

        private void cmbTipoOggetto_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateList();
        }
	}
}

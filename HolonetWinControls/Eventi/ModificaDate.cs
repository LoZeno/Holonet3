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
    public partial class ModificaDate : ToolboxManagerForm
	{
		private long cdEvento;
		private HolonetEntities databaseContext;

		public ModificaDate()
		{
			InitializeComponent();
		}

		public ModificaDate(long CdEvento)
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
				Evento myEvent = manager.GetEventFromNumber(cdEvento);
				txtNomeEvento.Text = myEvent.TitoloEvento;
				grdGiorni.DataSource = myEvent.EventoGiornis;
			}
		}

		private void grdGiorni_SelectionChanged(object sender, EventArgs e)
		{
			if (grdGiorni.SelectedRows.Count == 1)
			{
				DateTime data = (DateTime)grdGiorni.SelectedRows[0].Cells["DataGiorno"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					EventiManagerNew manager = new EventiManagerNew(databaseContext);
					EventoGiorni singleDay = manager.GetSingleDay(cdEvento, data);
					txtCosto.Text = singleDay.CostoGiorno.ToString();
					mstxPunti.Text = singleDay.PuntiAssegnati.ToString();
					dtOraInGioco.Value = singleDay.OraInGioco;
					dtOraFg.Value = singleDay.OraFuoriGioco;
					EnableControls(true);
				}
			}
			else
			{
				txtCosto.Text = string.Empty;
				mstxPunti.Text = string.Empty;
				dtOraInGioco.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
				dtOraFg.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
				EnableControls(false);
			}
		}

		private void EnableControls(bool enable)
		{
			txtCosto.Enabled =
			mstxPunti.Enabled =
			dtOraInGioco.Enabled =
			dtOraFg.Enabled =
			btnCancella.Enabled =
			btnSalva.Enabled = enable;
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private bool ValidateForm()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    float.Parse(txtCosto.Text.Trim());
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Inserire un NUMERO nel campo \"Costo\" o lasciarlo vuoto.");
                return false;
            }
        }

		private void btnSalva_Click(object sender, EventArgs e)
		{
            if (ValidateForm())
            {
                DialogResult confirm = MessageBox.Show("Sei sicuro di voler apportare questi cambiamenti?", "Conferma salvataggio", MessageBoxButtons.YesNo);
                if (confirm == System.Windows.Forms.DialogResult.Yes)
                {
                    long? punti = null;
                    float? costo = null;
                    if (!string.IsNullOrWhiteSpace(mstxPunti.Text))
                    {
                        punti = long.Parse(mstxPunti.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(txtCosto.Text))
                    {
                        costo = float.Parse(txtCosto.Text.Trim());
                    }
                    DateTime data = (DateTime)grdGiorni.SelectedRows[0].Cells["DataGiorno"].Value;
                    using (databaseContext = CreateDatabaseContext())
                    {
                        EventiManagerNew manager = new EventiManagerNew(databaseContext);
                        bool res = manager.SaveSingleDay(cdEvento, data, punti, dtOraInGioco.Value, dtOraFg.Value, costo);
                        if (res)
                        {
                            databaseContext.SaveChanges();
                            MessageBox.Show("Dati salvati correttamente");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Si è verificato un errore durante il salvataggio");
                        }
                    }
                }
            }
		}

		private void btnCancella_Click(object sender, EventArgs e)
		{
			DialogResult confirm = MessageBox.Show("SEI SICURO DI VOLER ELIMINARE QUESTO GIORNO?", "Conferma eliminazione", MessageBoxButtons.YesNo);
			if (confirm == System.Windows.Forms.DialogResult.Yes)
			{ 
				DateTime data = (DateTime)grdGiorni.SelectedRows[0].Cells["DataGiorno"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					EventiManagerNew manager = new EventiManagerNew(databaseContext);
					bool res = manager.DeleteSingleDay(cdEvento, data);
					if (res)
					{
						databaseContext.SaveChanges();
						MessageBox.Show("Eliminazione avvenuta");
						this.Close();
					}
					else
					{
						MessageBox.Show("Si è verificato un errore durante il salvataggio");
					}
				}
			}
		}
	}
}

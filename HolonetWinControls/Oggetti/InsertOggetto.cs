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
    public partial class InsertOggetto : ToolboxManagerForm
	{
        private bool IsCloning = false;
        private long? originalItem = null;

		private HolonetEntities databaseContext = null;

		public InsertOggetto()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

        public InsertOggetto(long itemToEdit)
            :this()
        {
            originalItem = itemToEdit;
            using (databaseContext = CreateDatabaseContext())
            {
                OggettiManager manager = new OggettiManager(databaseContext);
                NewOggetti original = manager.GetItemFromNumber(itemToEdit);
                txtNome.Text = original.Nome;
                txtDescrizione.Text = original.Descrizione;
                txtEffetto.Text = original.Effetto;
                mstxCosto.Text = original.Costo.ToString();
                if (original.NumeroCariche.HasValue)
                {
                    mstxCariche.Text = original.NumeroCariche.ToString();
                }
                cmbDisponibilita.SelectedValue = original.Disponibilita;
                cmbTipo.SelectedValue = original.Tipo;
                calScadenza.SelectionStart = calScadenza.SelectionEnd = original.DataScadenza.HasValue ? original.DataScadenza.Value : DateTime.Today;
            }
        }

        public InsertOggetto(long originalItem, bool cloning)
            :this(originalItem)
        {
            IsCloning = cloning;
            lblCloneWarning.Visible = true;
        }

		private bool validateForm()
		{
			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("Nome dell'oggetto obbligatorio");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtDescrizione.Text))
			{
				MessageBox.Show("Descrizione dell'oggetto obbligatoria");
				return false;
			}
			if (string.IsNullOrWhiteSpace(mstxCosto.Text))
			{
				MessageBox.Show("Costo dell'oggetto obbligatorio. Per oggetti inestimabili inserire 0");
				return false;
			}
            if (cmbTipo.SelectedIndex < 0 || cmbTipo.SelectedValue == null)
            {
                MessageBox.Show("Selezionare un tipo oggetto");
                return false;
            }
            if (cmbDisponibilita.SelectedIndex < 0 || cmbDisponibilita.SelectedValue == null)
            {
                MessageBox.Show("Selezionare un valore di disponibilità");
                return false;
            }
			return true;
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (validateForm())
			{
				using (databaseContext = CreateDatabaseContext())
				{
					OggettiManager manager = new OggettiManager(databaseContext);
					float costo = float.Parse(mstxCosto.Text);
					int? cariche = null;
					if (!string.IsNullOrWhiteSpace(mstxCariche.Text))
					{
						cariche = int.Parse(mstxCariche.Text);
					}
					DateTime? selectedDate = null;
					if (calScadenza.SelectionStart > DateTime.Today)
					{
						selectedDate = calScadenza.SelectionStart;
					}

                    bool res = false;
                    if (IsCloning)
                    {
                        res = manager.CloneItem(originalItem.Value, txtNome.Text.Trim(), txtDescrizione.Text.Trim(), txtEffetto.Text.Trim(), null, costo, (long)cmbDisponibilita.SelectedValue, selectedDate, cariche, (long)cmbTipo.SelectedValue);
                    }
                    else
                    {
                        res = manager.SaveItem(originalItem, txtNome.Text.Trim(), txtDescrizione.Text.Trim(), txtEffetto.Text.Trim(), null, costo, (long)cmbDisponibilita.SelectedValue, selectedDate, cariche, (long)cmbTipo.SelectedValue);
                    }
					if (res)
					{
						databaseContext.SaveChanges();
						this.Close();
					}
					else
					{
						MessageBox.Show("Errore durante il salvataggio, ricontrollare i dati inseriti");
					}
				}
			}
		}

		private void LoadData()
		{
			List<NewElementiDisponibilita> datasource = new List<NewElementiDisponibilita>();
			using (databaseContext = CreateDatabaseContext())
			{
				var listDisponibilita = from disp in databaseContext.NewElementiDisponibilitas
										orderby disp.Progressivo
										select disp;
				cmbDisponibilita.ValueMember = "Progressivo";
				cmbDisponibilita.DisplayMember = "Descrizione";
				cmbDisponibilita.DataSource = listDisponibilita;
				//datasource = listDisponibilita.ToList();

                var listTipi = from tipi in databaseContext.TipoOggettis
                               orderby tipi.Descrizione
                               select tipi;
                cmbTipo.ValueMember = "Progressivo";
                cmbTipo.DisplayMember = "Descrizione";
                cmbTipo.DataSource = listTipi;
			}
			//cmbDisponibilita.DataSource = datasource;
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCreateType_Click(object sender, EventArgs e)
		{
			CreaTipo newForm = new CreaTipo();
			newForm.ShowDialog();
			using (databaseContext = CreateDatabaseContext())
			{
				var listTipi = from tipi in databaseContext.TipoOggettis
							   orderby tipi.Descrizione
							   select tipi;
				cmbTipo.ValueMember = "Progressivo";
				cmbTipo.DisplayMember = "Descrizione";
				cmbTipo.DataSource = listTipi;
			}
		}

	}
}

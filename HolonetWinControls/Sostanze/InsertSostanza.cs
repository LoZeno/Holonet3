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
    public partial class InsertSostanza : ToolboxManagerForm
	{
		private bool IsCloning = false;
		private long? originalItem = null;

		private HolonetEntities databaseContext = null;

		public InsertSostanza()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		public InsertSostanza(long itemToEdit)
            :this()
        {
            originalItem = itemToEdit;
            using (databaseContext = CreateDatabaseContext())
            {
				SostanzeManager manager = new SostanzeManager(databaseContext);
                NewSostanze original = manager.GetSubstanceFromNumber(itemToEdit);
                txtNome.Text = original.Nome;
                txtDescrizione.Text = original.Descrizione;
                txtEffetto.Text = original.Effetto;
                mstxCosto.Text = original.Costo.ToString();
                mstxEfficacia.Text = original.ValoreEfficacia.ToString();
                cmbDisponibilita.SelectedValue = original.Disponibilita;
                cmbTipo.SelectedValue = original.Tipo;
				cmbModoUso.SelectedItem = original.ModoUso;
                calScadenza.SelectionStart = calScadenza.SelectionEnd = original.DataScadenza.HasValue ? original.DataScadenza.Value : DateTime.Today;
            }
        }

		public InsertSostanza(long originalItem, bool cloning)
            :this(originalItem)
        {
            IsCloning = cloning;
            lblCloneWarning.Visible = true;
        }

		private bool validateForm()
		{
			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("Nome della sostanza obbligatorio");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtDescrizione.Text))
			{
				MessageBox.Show("Descrizione della sostanza obbligatoria");
				return false;
			}
			if (string.IsNullOrWhiteSpace(mstxCosto.Text))
			{
				MessageBox.Show("Costo dell'oggetto obbligatorio. Per oggetti inestimabili inserire 0");
				return false;
			}
			if (cmbTipo.SelectedIndex < 0 || cmbTipo.SelectedValue == null)
			{
				MessageBox.Show("Selezionare un tipo sostanza");
				return false;
			}
			if (cmbDisponibilita.SelectedIndex < 0 || cmbDisponibilita.SelectedValue == null)
			{
				MessageBox.Show("Selezionare un valore di disponibilità");
				return false;
			}
			if (string.IsNullOrWhiteSpace(mstxEfficacia.Text))
			{
				MessageBox.Show("Valore di efficacia obbligatorio");
				return false;
			}
			if (cmbModoUso.SelectedIndex < 0 || cmbModoUso.SelectedValue == null)
			{
				MessageBox.Show("Selezionare un modo d'uso");
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
					SostanzeManager manager = new SostanzeManager(databaseContext);
					float costo = float.Parse(mstxCosto.Text);
					int efficacia = 0;
					if (!string.IsNullOrWhiteSpace(mstxEfficacia.Text))
					{
						efficacia = int.Parse(mstxEfficacia.Text);
					}
					DateTime? selectedDate = null;
					if (calScadenza.SelectionStart > DateTime.Today)
					{
						selectedDate = calScadenza.SelectionStart;
					}

					bool res = false;
					if (IsCloning)
					{
						res = manager.CloneItem(originalItem.Value, txtNome.Text.Trim(), txtDescrizione.Text.Trim(), txtEffetto.Text.Trim(), null, costo, (long)cmbDisponibilita.SelectedValue, selectedDate, cmbModoUso.SelectedValue.ToString(), (long)cmbTipo.SelectedValue, efficacia);
					}
					else
					{
						res = manager.SaveSubstance(originalItem, txtNome.Text.Trim(), txtDescrizione.Text.Trim(), txtEffetto.Text.Trim(), null, costo, (long)cmbDisponibilita.SelectedValue, selectedDate, cmbModoUso.SelectedValue.ToString(), (long)cmbTipo.SelectedValue, efficacia);
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

				var listTipi = from tipi in databaseContext.TipoSostanzes
							   orderby tipi.Progressivo
							   select tipi;
				cmbTipo.ValueMember = "Progressivo";
				cmbTipo.DisplayMember = "Descrizione";
				cmbTipo.DataSource = listTipi;

				cmbModoUso.DataSource = ModiUso.Lista();
			}
			//cmbDisponibilita.DataSource = datasource;
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetWinControls.BaseClasses;
using DataAccessLayer;
using CommonBusiness.OggettiManager;
using CommonBusiness.Sostanze;
using CommonBusiness.ElementiBase;
using CommonBusiness.Eventi;

namespace HolonetWinControls.Eventi
{
	public partial class AggiungiElementoAEvento : ToolboxManagerForm
	{
		private long? codEvento = null;
		private int startPage = 0;
		private int pageSize = 50;
		HolonetEntities context;

		public AggiungiElementoAEvento()
		{
			InitializeComponent();
		}

		public AggiungiElementoAEvento(long codEvento)
			:this()
		{
			this.codEvento = codEvento;
			LoadSelectedType();
		}

		private void LoadSelectedType()
		{
			if (radItem.Checked)
			{
				using (context = CreateDatabaseContext())
				{
					OggettiManager manager = new OggettiManager(context);
					cmbTipo.DisplayMember = "Descrizione";
					cmbTipo.ValueMember = "Progressivo";
					cmbTipo.DataSource = manager.GetItemTypes();
				}
			}
			else
			{
				using (context = CreateDatabaseContext())
				{
					SostanzeManager manager = new SostanzeManager(context);
					cmbTipo.DisplayMember = "Descrizione";
					cmbTipo.ValueMember = "Progressivo";
					cmbTipo.DataSource = manager.GetSubstancesTypes();
				}
			}
		}

		private void radItem_CheckedChanged(object sender, EventArgs e)
		{
			LoadSelectedType();
		}

		private void cmbTipo_SelectedValueChanged(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			if (cmbTipo.SelectedValue != null)
			{
				long tipoSelezionato = (long)cmbTipo.SelectedValue;
				using (context = CreateDatabaseContext())
				{
					ElementiBaseManager manager = new ElementiBaseManager(context);
					var elementsToShow = manager.GetItemsForCombo();
					if (radItem.Checked)
					{
						IQueryable<NewOggetti> filteredList = elementsToShow.OfType<NewOggetti>();
						if (tipoSelezionato != -1)
						{
							filteredList = filteredList.Where(p => p.Tipo == tipoSelezionato);
						}
						grdElementi.DataSource = (from oggetti in filteredList
												  select new { oggetti.Progressivo, oggetti.Nome, oggetti.Effetto, oggetti.Descrizione }).ToList();
					}
					else
					{
						IQueryable<NewSostanze> filteredList = elementsToShow.OfType<NewSostanze>();
						filteredList = filteredList.Where(p => p.Tipo == tipoSelezionato);
						grdElementi.DataSource = (from sostanze in filteredList
												  select new { sostanze.Progressivo, sostanze.Nome, sostanze.ValoreEfficacia, sostanze.Effetto }).ToList();
					}

				}
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void grdElementi_SelectionChanged(object sender, EventArgs e)
		{
			if (grdElementi.SelectedRows.Count == 1)
			{
				long progressivo = (long)grdElementi.SelectedRows[0].Cells["Progressivo"].Value;
				using (context = CreateDatabaseContext())
				{
					EventiManagerNew manager = new EventiManagerNew(context);
					numCopie.Value = manager.GetCopiesOfItemsToPrint(codEvento.Value, progressivo);
				}
			}
			else
			{
				numCopie.Value = 0;
			}
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (grdElementi.SelectedRows.Count == 1)
			{
				using (context = CreateDatabaseContext())
				{
					long progressivo = (long)grdElementi.SelectedRows[0].Cells["Progressivo"].Value;
					decimal copie = numCopie.Value;
					EventiManagerNew eventManager = new EventiManagerNew(context);
					if (eventManager.UpdateElementsCopiesToPrint(codEvento.Value, progressivo, (int)copie))
					{
						context.SaveChanges();
						MessageBox.Show("Salvato numero di copie da stampare: " + (int)copie);
						this.Close();
					}
					else
					{
						MessageBox.Show("Si è verificato un errore");
					}
				}
			}
			else
			{
				MessageBox.Show("Occorre selezionare un oggetto/sostanza e stabilirne il numero di copie");
			}
		}
	}
}

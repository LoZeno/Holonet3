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
using CommonBusiness.HoloDischi;
using CommonBusiness.Eventi;

namespace HolonetWinControls.Eventi
{
	public partial class AggiungiDiscoAEvento : ToolboxManagerForm
	{
		long? codEvento = null;
		private int startPage = 0;
		private int pageSize = 50;
		HolonetEntities context = null;

		public AggiungiDiscoAEvento()
		{
			InitializeComponent();
		}

		public AggiungiDiscoAEvento(long codiceEvento)
			: this()
		{
			codEvento = codiceEvento;
			LoadData();
		}

		private void LoadData()
		{
			if (codEvento != null)
			{
				using (context = CreateDatabaseContext())
				{
					HoloDischiManager manager = new HoloDischiManager(context);
					grdHoloDisk.DataSource = manager.GetPagedDisksList(startPage, pageSize);
				}
			}
		}

		private void grdHoloDisk_SelectionChanged(object sender, EventArgs e)
		{
			if (grdHoloDisk.SelectedRows.Count == 1)
			{
				using (context = CreateDatabaseContext())
				{
					long progressivo = (long)grdHoloDisk.SelectedRows[0].Cells["Progressivo"].Value;

					EventiManagerNew eventManager = new EventiManagerNew(context);
					numCopie.Value = eventManager.GetCopiesOfDiskToPrint(codEvento.Value, progressivo);
				}
			}
			else
			{
				numCopie.Value = 0;
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
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
			int max = 0;
			using (context = CreateDatabaseContext())
			{
				HoloDischiManager manager = new HoloDischiManager(context);
				max = manager.Count();
			}
			startPage += 50;
			if (startPage >= max)
			{
				startPage = max - 50;
				if (startPage < 0)
				{
					startPage = 0;
				}
			}
			LoadData();
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (grdHoloDisk.SelectedRows.Count == 1)
			{
				using (context = CreateDatabaseContext())
				{
					long progressivo = (long)grdHoloDisk.SelectedRows[0].Cells["Progressivo"].Value;
					decimal copie = numCopie.Value;
					EventiManagerNew eventManager = new EventiManagerNew(context);
					if (eventManager.UpdateHolodiskCopiesToPrint(codEvento.Value, progressivo, (int)copie))
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
				MessageBox.Show("Occorre selezionare un datapad/holodisco e stabilirne il numero di copie");
			}
		}
	}
}

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
using CommonBusiness.HoloDischi;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Holodischi
{
    public partial class CreaDatapad : ToolboxManagerForm
	{
		private long? originalDisk = null;

		private HolonetEntities databaseContext = null;

		public CreaDatapad()
		{
			InitializeComponent();
		}

		public CreaDatapad(long OriginalDisk)
			: this()
		{
			originalDisk = OriginalDisk;
			using (databaseContext = CreateDatabaseContext())
            {
				HoloDischiManager manager = new HoloDischiManager(databaseContext);
				HoloDisk disco = manager.GetDiskFromNumber(originalDisk.Value);
				txtCodice.Text = disco.Codice;
				txtContenuto.Text = disco.Contenuto;
				numHacking.Value = disco.Hacking;
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtCodice.Text))
			{
				MessageBox.Show("Il campo 'Nome del Datapad' è obbligatorio");
				return;
			}
			using (databaseContext = CreateDatabaseContext())
			{
				HoloDischiManager manager = new HoloDischiManager(databaseContext);
				bool res = false;
				if (originalDisk.HasValue)
				{
					res = manager.UpdateDisk(originalDisk.Value, txtCodice.Text, txtContenuto.Text, (long)numHacking.Value);
				}
				else
				{
					res = manager.InsertNewDisk(txtCodice.Text, txtContenuto.Text, (long)numHacking.Value);
				}
				if (res)
				{
					databaseContext.SaveChanges();
					MessageBox.Show("Salvataggio avvenuto correttamente");
					this.Close();
				}
				else
				{
					MessageBox.Show("Si è verificato un errore durante il salvataggio, verificare che non esista già un datapad con lo stesso nome");
				}
			}
		}
	}
}

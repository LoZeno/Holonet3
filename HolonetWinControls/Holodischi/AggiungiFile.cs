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
    public partial class AggiungiFile : ToolboxManagerForm
	{
		public long progressivoDisco;
		public long? numeroFile = null;

		private HolonetEntities databaseContext = null;

		public AggiungiFile()
		{
			InitializeComponent();
		}

		public AggiungiFile(long ProgressivoDisco)
			: this()
		{
			progressivoDisco = ProgressivoDisco;
		}

		public AggiungiFile(long ProgressivoDisco, long NumeroFile)
			: this(ProgressivoDisco)
		{
			numeroFile = NumeroFile;
			using (databaseContext = CreateDatabaseContext())
			{
				HoloDischiManager manager = new HoloDischiManager(databaseContext);
				HoloDiskFile file = manager.GetSingleFile(progressivoDisco, numeroFile.Value);
				txtNomeFile.Text = file.NomeFile;
				txtContenuto.Text = file.Contenuto;
				numCrypt.Value = file.LivelloCrypt.HasValue ? file.LivelloCrypt.Value : 0;
			}
		}

		private bool ValidateForm()
		{
			if (string.IsNullOrWhiteSpace(txtNomeFile.Text))
			{
				MessageBox.Show("Il campo 'Nome del file' è obbligatorio");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtContenuto.Text))
			{
				MessageBox.Show("Il campo 'Contenuto del file' è obbligatorio");
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
					HoloDischiManager manager = new HoloDischiManager(databaseContext);
					bool res = false;
					if (numeroFile.HasValue)
					{
						res = manager.UpdateFile(progressivoDisco, numeroFile.Value, txtNomeFile.Text, txtContenuto.Text, (long)numCrypt.Value);
					}
					else
					{
						res = manager.InsertNewFile(progressivoDisco, txtNomeFile.Text, txtContenuto.Text, (long)numCrypt.Value);
					}
					if (res)
					{
						databaseContext.SaveChanges();
						MessageBox.Show("Salvataggio avvenuto correttamente");
						this.Close();
					}
					else
					{
						MessageBox.Show("Si è verificato un errore durante il salvataggio, verificare che non esista già nel datapad un file con lo stesso nome");
					}
				}
			}
		}
	}
}

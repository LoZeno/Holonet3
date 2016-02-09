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
using CommonBusiness.Personaggi;
using System.Collections;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Personaggi
{
    public partial class InsertSpecie : ToolboxManagerForm
	{
		private HolonetEntities context;

		public InsertSpecie()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			using (context = CreateDatabaseContext())
			{
				PersonaggiManagerNew manager = new PersonaggiManagerNew(context);
				List<string> species = manager.GetSpeciesNames();
				lstSpecie.DataSource = species;
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtNuovaSpecie.Text))
			{
				using (context = CreateDatabaseContext())
				{
					bool result = false;
					PersonaggiManagerNew manager = new PersonaggiManagerNew(context);
					result = manager.SaveNewSpecies(txtNuovaSpecie.Text.Trim(), txtDescrizione.Text.Trim());
					if (result)
					{
						context.SaveChanges();
					}
					else
					{
						MessageBox.Show("Errore durante la creazione della nuova specie, verificare che il campo 'Nuova Specie' sia compilato e che la specie non sia già presente");
					}
				}
				this.Close();
			}
		}
	}
}

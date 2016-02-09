using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using CommonBusiness.OggettiManager;
using DataAccessLayer;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Oggetti
{
    public partial class CreaTipo : ToolboxManagerForm
	{
		private HolonetEntities context;

		public CreaTipo()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			using (context = CreateDatabaseContext())
			{
				OggettiManager manager = new OggettiManager(context);
				List<string> types = manager.GetTypesList().ToList();
				lstTipi.DataSource = types;
			}
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtNuovoTipo.Text))
			{
				using (context = CreateDatabaseContext())
				{
					bool result = false;
					OggettiManager manager = new OggettiManager(context);
					result = manager.SaveNewType(txtNuovoTipo.Text.Trim());
					if (result)
					{
						context.SaveChanges();
					}
					else
					{
						MessageBox.Show("Errore durante la creazione del nuovo tipo, verificare che il campo sia compilato e che il nuovo tipo non sia già presente");
					}
				}
				this.Close();
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

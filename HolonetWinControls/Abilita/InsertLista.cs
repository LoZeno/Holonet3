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
using CommonBusiness.Abilita;
using DataAccessLayer.Enum;
using System.ComponentModel;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Abilita
{
	public partial class InsertLista : ToolboxManagerForm
	{
		string cdAttitudine;
		private HolonetEntities databaseContext;

		public InsertLista()
		{
			InitializeComponent();
            LoadCombo();
		}

		public InsertLista(string CdAttitudine)
			: this()
		{
			cdAttitudine = CdAttitudine;
			LoadGroup();
		}

		public bool ValidateForm()
		{
			if (string.IsNullOrWhiteSpace(txtCodice.Text))
			{
				MessageBox.Show("Codice della lista obbligatorio!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("Nome della lista obbligatorio!");
				return false;
			}
			return true;
		}

        private void LoadCombo()
        {
            TipoAttitudine[] tipi = Enum.GetValues(typeof(TipoAttitudine))
                        .Cast<TipoAttitudine>()
                        .ToArray();
            cmbTipoLista.DataSource = tipi;
        }

		private void LoadGroup()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				AbilitaManager manager = new AbilitaManager(databaseContext);
				Attitudine group = manager.GetSkillGroup(cdAttitudine);
				txtCodice.Text = group.CdAttitudine;
				txtCodice.Enabled = false;
				txtNome.Text = group.Nome;
				txtDescr.Text = group.Descrizione;
                cmbTipoLista.SelectedItem = group.TipoAttitudine;
			}
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				using (databaseContext = CreateDatabaseContext())
				{
					AbilitaManager manager = new AbilitaManager(databaseContext);
					bool res = false;
					if (string.IsNullOrWhiteSpace(cdAttitudine))
					{
                        res = manager.InsertNewSkillgroup(txtCodice.Text.Trim().ToUpper(), txtNome.Text.Trim(), txtDescr.Text, (TipoAttitudine)cmbTipoLista.SelectedItem);
					}
					else
					{
                        res = manager.EditSkillGroup(cdAttitudine, txtNome.Text.Trim(), txtDescr.Text, (TipoAttitudine)cmbTipoLista.SelectedItem);
					}
					if (res)
					{
						databaseContext.SaveChanges();
						this.Close();
					}
					else
					{
						MessageBox.Show("Errore nel salvataggio, assicurarsi che il nome della lista non sia già in uso");
					}
				}
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void cmbTipoLista_Format(object sender, ListControlConvertEventArgs e)
        {
            TipoAttitudine attitudine = (TipoAttitudine)e.ListItem;
            e.Value = EnumUtilities.GetEnumDescription(attitudine);
        }
	}
}

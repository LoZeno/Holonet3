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
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Abilita
{
	public partial class InsertAbilita : ToolboxManagerForm
	{
		string cdAttitudine;
		long? cdAbilita = null;
		private HolonetEntities databaseContext;

		public InsertAbilita()
		{
			InitializeComponent();
		}

		public InsertAbilita(string CdAttitudine)
			:this()
		{
			cdAttitudine = CdAttitudine;
		}

		public InsertAbilita(long CdAbilita, string CdAttitudine)
			: this(CdAttitudine)
		{
			cdAbilita = CdAbilita;
			LoadSkill();
		}

		private void LoadSkill()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				AbilitaManager manager = new AbilitaManager(databaseContext);
				DataAccessLayer.Abilita skill = manager.GetSkill(cdAbilita.Value);
				txtNome.Text = skill.Nome;
				txtDescr.Text = skill.Descrizione;
				mstxCosto.Text = skill.Costo.ToString();
				chkAvanzato.Checked = skill.BaseAvanzato == 0 ? false : true;
				chkMultiAcquisto.Checked = skill.Multiacquisto == 0 ? false : true;
			}
		}

		public bool ValidateForm()
		{
			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("Nome della lista obbligatorio!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(mstxCosto.Text))
			{
				MessageBox.Show("Costo in punti esperienza obbligatorio!");
				return false;
			}
			return true;
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				using (databaseContext = CreateDatabaseContext())
				{
					AbilitaManager manager = new AbilitaManager(databaseContext);
					long costo = long.Parse(mstxCosto.Text);
					bool res = false;
					if (!cdAbilita.HasValue)
					{
						res = manager.InsertSkillToGroup(cdAttitudine, txtNome.Text.Trim(), txtDescr.Text, chkMultiAcquisto.Checked, costo, chkAvanzato.Checked);
					}
					else
					{
						res = manager.EditSkill(cdAbilita.Value, txtNome.Text.Trim(), txtDescr.Text, chkMultiAcquisto.Checked, costo, chkAvanzato.Checked); ;
					}
					if (res)
					{
						databaseContext.SaveChanges();
						this.Close();
					}
					else
					{
						MessageBox.Show("Errore nel salvataggio, assicurarsi che la lista non contenga un'abilità con lo stesso nome se la si sta inserendo nuova");
					}
				}
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}


	}
}

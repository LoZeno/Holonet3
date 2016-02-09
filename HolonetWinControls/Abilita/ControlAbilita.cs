using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using DataAccessLayer;
using CommonBusiness.Abilita;

namespace HolonetWinControls.Abilita
{
	public partial class ControlAbilita : BaseManagerUserControl
	{
		#region membri privati
		private HolonetEntities databaseContext;
		#endregion

		public ControlAbilita()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		public override void LoadData()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				AbilitaManager manager = new AbilitaManager(databaseContext);
				var attitudini = manager.GetAllSkillgroups();
				grdListe.DataSource = attitudini;
			}
		}

		private void LoadSkillGrid()
		{
			if (grdListe.SelectedRows.Count == 1)
			{
				string cdAttitudine = grdListe.SelectedRows[0].Cells["CdAttitudine"].Value.ToString();
				using (databaseContext = CreateDatabaseContext())
				{
					AbilitaManager manager = new AbilitaManager(databaseContext);
					var abilita = manager.GetSkillsFromGroup(cdAttitudine);
					grdAbilita.DataSource = abilita;
				}
			}
			else
			{
				grdAbilita.DataSource = null;
			}
		}

		private void grdListe_SelectionChanged(object sender, EventArgs e)
		{
			LoadSkillGrid();
		}

		private void btnNuovaLista_Click(object sender, EventArgs e)
		{
			InsertLista newForm = new InsertLista();
			newForm.ShowDialog();
			LoadData();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdListe.SelectedRows.Count == 1)
			{
				string attitudine = grdListe.SelectedRows[0].Cells["CdAttitudine"].Value.ToString();
				InsertLista newForm = new InsertLista(attitudine);
				newForm.ShowDialog();
				LoadData();
			}
		}

		private void btnNuovaAbilita_Click(object sender, EventArgs e)
		{
			if (grdListe.SelectedRows.Count == 1)
			{
				string attitudine = grdListe.SelectedRows[0].Cells["CdAttitudine"].Value.ToString();
				InsertAbilita newForm = new InsertAbilita(attitudine);
				newForm.ShowDialog();
				LoadSkillGrid();
			}
		}

		private void btnModificaAbilita_Click(object sender, EventArgs e)
		{
			if (grdAbilita.SelectedRows.Count == 1)
			{
				string attitudine = grdListe.SelectedRows[0].Cells["CdAttitudine"].Value.ToString();
				long cdAbilita = (long)grdAbilita.SelectedRows[0].Cells["CdAbilita"].Value;
				InsertAbilita newForm = new InsertAbilita(cdAbilita, attitudine);
				newForm.ShowDialog();
				LoadSkillGrid();
			}
		}
	}
}

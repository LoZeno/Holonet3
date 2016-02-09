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
using CommonBusiness.Abilita;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Personaggi
{
    public partial class AggiungiAbilita : ToolboxManagerForm
	{
		long numeroPg;
		private HolonetEntities context;

		long freePoints = 0;

		public AggiungiAbilita()
		{
			InitializeComponent();
		}

		public AggiungiAbilita(long NumeroPg)
			:this()
		{
			numeroPg = NumeroPg;
			LoadData();
		}

		private void LoadData()
		{
			using (context = CreateDatabaseContext())
			{
				PersonaggiManagerNew manager = new PersonaggiManagerNew(context);
				Personaggio character = manager.GetCharacterByNumber(numeroPg);
                List<Attitudine> cmbSource = new List<Attitudine>();
				IEnumerable<Attitudine> skillgroups = character.Attitudines;
                foreach (var lista in skillgroups)
                {
                    cmbSource.Add(lista);
                }
                AbilitaManager skillManager = new AbilitaManager(context);
                IEnumerable<Attitudine> expansionGroups;
                if (character.Tipo == 0)
                {
                    expansionGroups = skillManager.GetSkillGroupFromType(DataAccessLayer.Enum.TipoAttitudine.Innesti);
                }
                else
                {
                    expansionGroups = skillManager.GetSkillGroupFromType(DataAccessLayer.Enum.TipoAttitudine.InnestiDroide);
                }
                foreach (var lista in expansionGroups)
                {
                    cmbSource.Add(lista);
                }
				cmbAttitudine.ValueMember = "CdAttitudine";
				cmbAttitudine.DisplayMember = "Nome";
				cmbAttitudine.DataSource = cmbSource;

				freePoints = manager.GetFreeSkillpoints(numeroPg);
				txtFreePoints.Text = freePoints.ToString();
			}
		}

		private void cmbAttitudine_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cmbAttitudine.SelectedValue != null)
			{
				string cdAttitudine = cmbAttitudine.SelectedValue.ToString();
				using (context = CreateDatabaseContext())
				{
					AbilitaManager skillmanager = new AbilitaManager(context);
					grdAbilita.DataSource = skillmanager.GetSkillsFromGroup(cdAttitudine);
				}
			}
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Vuoi acquistare questa abilità?", "Sei sicuro?", MessageBoxButtons.YesNo);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				string cdAttitudine = cmbAttitudine.SelectedValue.ToString();
				long cdAbilita = (long)grdAbilita.SelectedRows[0].Cells["CdAbilita"].Value;
				long? numAcquisti = null;
				if (numVolte.Enabled)
				{
					numAcquisti = (long)numVolte.Value;
				}
				using (context = CreateDatabaseContext())
				{
					PersonaggiManagerNew characterManager = new PersonaggiManagerNew(context);
					bool res = characterManager.AddSkillToCharacter(numeroPg, cdAbilita, numAcquisti, cdAttitudine, txtSpecifiche.Text.Trim());
					if (res)
					{
						context.SaveChanges();
						MessageBox.Show("Abilità acquistata");
						this.Close();
					}
					else
					{
						MessageBox.Show("Errore durante il salvataggio");
					}
				}
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void grdAbilita_SelectionChanged(object sender, EventArgs e)
		{
			txtSpecifiche.Text = null;
			if (grdAbilita.SelectedRows.Count > 0)
			{
				txtSpecifiche.Enabled = true;
				long cdAbilita = (long)grdAbilita.SelectedRows[0].Cells["CdAbilita"].Value;
				using (context = CreateDatabaseContext())
				{
					AbilitaManager skillmanager = new AbilitaManager(context);
					PersonaggiManagerNew manager = new PersonaggiManagerNew(context);
					Personaggio character = manager.GetCharacterByNumber(numeroPg);
					DataAccessLayer.Abilita skill = skillmanager.GetSkill(cdAbilita);
					bool isBought = false;
					long minimum = 1;
					if (character.PossiedeAbilita(cdAbilita))
					{
						isBought = true;
						AbilitaPersonaggio skillBought = (from comprate in character.AbilitaPersonaggios
														  where comprate.CdAbilita == cdAbilita
														  select comprate).FirstOrDefault();
						if (skillBought.NumeroAcquisti.HasValue)
						{
							minimum = skillBought.NumeroAcquisti.Value;
						}
					}
					numVolte.Minimum = minimum;
					if (skill.Costo > freePoints)
					{
						btnSalva.Enabled = false;
					}
					else
					{
						if (skill.Multiacquisto == 0)
						{
							if (isBought)
							{
								btnSalva.Enabled = false;
							}
							else
							{
								btnSalva.Enabled = true;
							}
						}
						else
						{
							numVolte.Enabled = true;
							numVolte.Maximum = minimum + (skill.Costo / freePoints);
							btnSalva.Enabled = true;
						}
					}
				}
			}
			else
			{
				txtSpecifiche.Enabled = false;
				btnSalva.Enabled = false;
			}
		}
	}
}

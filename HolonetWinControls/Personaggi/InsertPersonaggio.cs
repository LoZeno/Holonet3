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
using DataAccessLayer.Enum;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Personaggi
{
    public partial class InsertPersonaggio : ToolboxManagerForm
	{
		private long? numeroSW = null;
		private long? numeroPg = null;

		private HolonetEntities databaseContext;

		private List<string> attitudes;

		public struct TipoPersonaggio
		{
			public TipoPersonaggio(int chiave, string nome)
			{
				Key = chiave;
				Desc = nome;
			}
			public int Key;
			public string Desc;
		}

		/// <summary>
		/// Da usare per MODIFICARE un personaggio già creato
		/// </summary>
		/// <param name="NumeroPG"></param>
		public InsertPersonaggio(long NumeroSW, long NumeroPG)
			: this(NumeroSW)
		{
			numeroPg = NumeroPG;
			mstxNumeroPg.Enabled = false;
			chkVivo.Enabled = true;
			cmbTipo.Enabled = false;
			cmbSpecie.Enabled = false;
			btnCompraAbilita.Enabled = true;
			LoadOriginalCharacter();
		}

		private void LoadOriginalCharacter()
		{
			if (numeroPg.HasValue)
			{
				using (databaseContext = CreateDatabaseContext())
				{
					PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
					Personaggio character = manager.GetCharacterByNumber(numeroPg.Value);
                    cmbTipo.SelectedValue = character.Tipo;
					txtNome.Text = character.Nome;
					txtPassword.Text = character.PasswordHolonet;
					txtTitolo.Text = character.Titolo;
					mstxLatoOscuro.Text = character.LatoOscuro.ToString();
					mstxNumeroPg.Text = character.NumeroPG.ToString();
					mstxPunti.Text = character.Punti.ToString();
					int numberLists = character.AttitudiniScelte.Count();
					switch (numberLists)
					{
						case 5:
							cmbAttitudine5.Enabled = false;
                            cmbAttitudine5.SelectedValue = character.AttitudiniScelte.Skip(4).First().CdAttitudine;
							goto case 4;
						case 4:
							cmbAttitudine4.Enabled = false;
                            cmbAttitudine4.SelectedValue = character.AttitudiniScelte.Skip(3).First().CdAttitudine;
							goto case 3;
						case 3:
							cmbAttitudine3.Enabled = false;
                            cmbAttitudine3.SelectedValue = character.AttitudiniScelte.Skip(2).First().CdAttitudine;
							goto case 2;
						case 2:
							cmbAttitudine2.Enabled = false;
                            cmbAttitudine2.SelectedValue = character.AttitudiniScelte.Skip(1).First().CdAttitudine;
							goto case 1;
						case 1:
							cmbAttitudine1.Enabled = false;
                            cmbAttitudine1.SelectedValue = character.AttitudiniScelte.Skip(0).First().CdAttitudine;
							break;
						default:
							break;
					}

                    int extraLists = character.AttitudiniExtraDroidi.Count();
                    switch (extraLists)
                    {
                        case 3:
                            cmbBiologica3.Enabled = false;
                            cmbBiologica3.SelectedValue = character.AttitudiniExtraDroidi.Skip(2).First().CdAttitudine;
                            goto case 2;
                        case 2:
                            cmbBiologica2.Enabled = false;
                            cmbBiologica2.SelectedValue = character.AttitudiniExtraDroidi.Skip(1).First().CdAttitudine;
                            goto case 1;
                        case 1:
                            cmbBiologica1.Enabled = false;
                            cmbBiologica1.SelectedValue = character.AttitudiniExtraDroidi.Skip(0).First().CdAttitudine;
                            break;
                    }

                    if (character.Tipo == 1)
                    {
                        if (character.ClasseDroide != null && !string.IsNullOrWhiteSpace(character.ClasseDroide.CdAttitudine))
                        {
                            cmbClasseDroide.SelectedValue = character.ClasseDroide.CdAttitudine;
                        }
                        cmbClasseDroide.Enabled = false;
                        AbilitaPersonaggio euristico = (from abilita in character.AbilitaPersonaggios
                                                        where abilita.Abilita.Nome.Trim() == "CERVELLO EURISTICO"
                                                        select abilita).FirstOrDefault();
                        if (euristico != null)
                        {
                            switch (euristico.NumeroAcquisti)
                            {
                                case null:
                                    break;
                                case 3:
                                    cmbAttitudine5.Visible = lblAtt5.Visible = true;
                                    goto case 2;
                                case 2:
                                    cmbAttitudine4.Visible = lblAtt4.Visible = true;
                                    goto case 1;
                                case 1:
                                    cmbAttitudine3.Visible = lblAtt3.Visible = true;
                                    break;
                            }
                        }
                        AbilitaPersonaggio apprendiBio = (from abilita in character.AbilitaPersonaggios
                                                          where abilita.Abilita.Nome.Trim() == "APPRENDIMENTO BIOLOGICO"
                                                          select abilita).FirstOrDefault();
                        if (apprendiBio != null)
                        {
                            switch (apprendiBio.NumeroAcquisti)
                            {
                                case null:
                                    break;
                                case 3:
                                    cmbBiologica3.Visible = lblAttBio3.Visible = true;
                                    goto case 2;
                                case 2:
                                    cmbBiologica2.Visible = lblAttBio2.Visible = true;
                                    goto case 1;
                                case 1:
                                    cmbBiologica1.Visible = lblAttBio1.Visible = true;
                                    break;
                            }
                        }
                    }

					cmbFazione.SelectedValue = character.Fazione;
					cmbSesso.SelectedItem = character.Sesso;
					cmbSpecie.SelectedValue = character.Specie;
					txtPuntiLiberi.Text = manager.GetFreeSkillpoints(numeroPg.Value).ToString();
				}
				LoadSkills();
			}
		}

		/// <summary>
		/// Da usare per aggiungere un nuovo personaggio ad un giocatore già esistente
		/// </summary>
		/// <param name="NumeroSW"></param>
		public InsertPersonaggio(long NumeroSW)
			:this()
		{
			numeroSW = NumeroSW;
		}

		/// <summary>
		/// Da usare per aggiungere un personaggio nuovo specificandone anche il proprietario
		/// </summary>
		public InsertPersonaggio()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		private void LoadData()
		{
            LoadAttitudini();
			using (databaseContext = CreateDatabaseContext())
			{
                //AbilitaManager skillManager = new AbilitaManager(databaseContext);
                //cmbAttitudine1.DataSource = skillManager.GetSkillgroupsForCombo();
                //cmbAttitudine2.DataSource = skillManager.GetSkillgroupsForCombo();
                //cmbAttitudine3.DataSource = skillManager.GetSkillgroupsForCombo();
                //cmbAttitudine4.DataSource = skillManager.GetSkillgroupsForCombo();
                //cmbAttitudine5.DataSource = skillManager.GetSkillgroupsForCombo();
				PersonaggiManagerNew characterManager = new PersonaggiManagerNew(databaseContext);
				cmbFazione.DataSource = characterManager.GetFactions();
				cmbSpecie.DataSource = characterManager.GetSpecies();
				DataTable types = new DataTable();
				types.Columns.Add("Key");
				types.Columns.Add("Desc");
				types.Rows.Add((long)0, "Biologico");
				types.Rows.Add((long)1, "Droide");
				cmbTipo.DataSource = types;
			}
		}

		private void LoadSkills()
		{
			txtAbilita.Text = null;
			using (databaseContext = CreateDatabaseContext())
			{
				PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
				Personaggio character = manager.GetCharacterByNumber(numeroPg.Value);
				foreach (var attitudine in character.Attitudines)
				{
					txtAbilita.Text += attitudine.Nome + ":\r\n";
					var theseSkills = from abilitaComprate in character.AbilitaPersonaggios
									  where abilitaComprate.CdAttitudine == attitudine.CdAttitudine
									  select new { Nome = abilitaComprate.Abilita.Nome, Volte = abilitaComprate.NumeroAcquisti, Specifiche = abilitaComprate.Specifiche };
					foreach (var item in theseSkills)
					{
						txtAbilita.Text += item.Nome + (item.Volte.HasValue ? "x" + item.Volte.Value : null);
                        if (!string.IsNullOrWhiteSpace(item.Specifiche))
                        {
                            txtAbilita.Text += " [" + item.Specifiche + "]";
                        }
                        txtAbilita.Text += "\r\n";
					}
					txtAbilita.Text += "\r\n";
				}
                TipoAttitudine tipoInnesti = TipoAttitudine.Innesti;
                if (character.Tipo == 1)
                {
                    tipoInnesti = TipoAttitudine.InnestiDroide;
                }
                //Inserimento abilità degli innesti
                var innesti = from abilitacomprate in character.AbilitaPersonaggios
                              where abilitacomprate.Attitudine.TipoAttitudine == tipoInnesti
                              select new { Nome = abilitacomprate.Abilita.Nome, Volte = abilitacomprate.NumeroAcquisti, Specifiche = abilitacomprate.Specifiche };
                if (innesti.Count() > 0)
                {
                    txtAbilita.Text += "ABILITA' AGGIUNTIVE (INNESTI O POTENZIAMENTI):\r\n";
                    foreach (var item in innesti)
                    {
                        txtAbilita.Text += item.Nome + (item.Volte.HasValue ? "x" + item.Volte.Value : null);
                        if (!string.IsNullOrWhiteSpace(item.Specifiche))
                        {
                            txtAbilita.Text += " [" + item.Specifiche + "]";
                        }
                        txtAbilita.Text += "\r\n";
                    }
                    txtAbilita.Text += "\r\n";
                }
			}
		}

		private bool validateForm()
		{
			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("Nome obbligatorio");
				return false;
			}
			if (cmbSpecie.SelectedValue == null)
			{
				MessageBox.Show("Selezionare una specie");
				return false;
			}
			if (cmbTipo.SelectedValue == null)
			{
				MessageBox.Show("Selezionare un tipo (Biologico o Droide)");
				return false;
			}
			if (cmbSesso.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSesso.SelectedItem.ToString()))
			{
				MessageBox.Show("Selezionare il sesso");
				return false;
			}
			if (cmbFazione.SelectedValue == null)
			{
				MessageBox.Show("Selezionare una fazione");
				return false;
			}
			if (!ValidateSkillgroups())
			{
				MessageBox.Show("Non possono esserci due o più liste di attitudini uguali");
				return false;
			}
			return true;
		}

        private void LoadAttitudini()
        {
            using (databaseContext = CreateDatabaseContext())
            {
                AbilitaManager skillManager = new AbilitaManager(databaseContext);
                if (cmbTipo.SelectedValue == null || cmbTipo.SelectedValue.ToString() == "0")
                {
                    lblFirstGroup.Text = "Attitudine 1";
                    cmbAttitudine1.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbAttitudine2.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbAttitudine3.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbAttitudine4.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbAttitudine5.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbClasseDroide.Visible = false;
                    lblClasseDroide.Visible = false;

                    lblSpecie.Visible = true;
                    cmbSpecie.Visible = true;
                    btnCreaSpecie.Visible = true;
                    lblAtt3.Visible = cmbAttitudine3.Visible = true;
                    lblAtt4.Visible = cmbAttitudine4.Visible = true;
                    lblAtt5.Visible = cmbAttitudine5.Visible = true;

                    lblAttBio1.Visible = cmbBiologica1.Visible = false;
                    lblAttBio2.Visible = cmbBiologica2.Visible = false;
                    lblAttBio3.Visible = cmbBiologica3.Visible = false;
                }
                else
                {
                    cmbAttitudine1.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Droide);
                    cmbAttitudine2.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Droide);
                    cmbAttitudine3.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Droide);
                    cmbAttitudine4.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Droide);
                    cmbAttitudine5.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Droide);
                    cmbClasseDroide.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.ClasseDroide);
                    cmbClasseDroide.Visible = true;
                    lblClasseDroide.Visible = true;

                    cmbBiologica1.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbBiologica2.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);
                    cmbBiologica3.DataSource = skillManager.GetSkillgroupsForCombo(TipoAttitudine.Biologico);

                    lblSpecie.Visible = false;
                    cmbSpecie.Visible = false;
                    btnCreaSpecie.Visible = false;
                    lblAtt3.Visible = cmbAttitudine3.Visible = false;
                    lblAtt4.Visible = cmbAttitudine4.Visible = false;
                    lblAtt5.Visible = cmbAttitudine5.Visible = false;

                    lblAttBio1.Visible = cmbBiologica1.Visible = false;
                    lblAttBio2.Visible = cmbBiologica2.Visible = false;
                    lblAttBio3.Visible = cmbBiologica3.Visible = false;
                }
            }
        }

		private bool ValidateSkillgroups()
		{
			attitudes = new List<string>();

            if (cmbTipo.SelectedValue.ToString() == "1")
            {
                string droidclass = cmbClasseDroide.SelectedValue.ToString();
                attitudes.Add(droidclass);
            }
			string att1 = cmbAttitudine1.SelectedValue.ToString();
			attitudes.Add(att1);
			string att2 = cmbAttitudine2.SelectedValue.ToString();
			if (attitudes.Contains(att2))
			{
				return false;
			}
			attitudes.Add(att2);
            if (cmbAttitudine3.Visible)
            {
                string att3 = cmbAttitudine3.SelectedValue.ToString();
                if (attitudes.Contains(att3))
                {
                    return false;
                }
                attitudes.Add(att3);
                if (cmbAttitudine4.Visible)
                {
                    string att4 = cmbAttitudine4.SelectedValue.ToString();
                    if (attitudes.Contains(att4))
                    {
                        return false;
                    }
                    attitudes.Add(att4);
                    if (cmbAttitudine5.Visible)
                    {
                        string att5 = cmbAttitudine5.SelectedValue.ToString();
                        if (attitudes.Contains(att5))
                        {
                            return false;
                        }
                        attitudes.Add(att5);
                    }
                }
            }
            if (cmbBiologica1.Visible)
            {
                string attBio1 = cmbBiologica1.SelectedValue.ToString();
                if (attitudes.Contains(attBio1))
                {
                    return false;
                }
                attitudes.Add(attBio1);
                if (cmbBiologica2.Visible)
                {
                    string attBio2 = cmbBiologica2.SelectedValue.ToString();
                    if (attitudes.Contains(attBio2))
                    {
                        return false;
                    }
                    attitudes.Add(attBio2);
                    if (cmbBiologica3.Visible)
                    {
                        string attBio3 = cmbBiologica3.SelectedValue.ToString();
                        if (attitudes.Contains(attBio3))
                        {
                            return false;
                        }
                        attitudes.Add(attBio3);
                    }
                }
            }
			return true;
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (validateForm())
			{
				using (databaseContext = CreateDatabaseContext())
				{
					PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
					bool res = false;
					string nome = txtNome.Text.Trim();
                    long specie = 0;
                    if (cmbSpecie.SelectedValue != null)
                    {
                        specie = (long)cmbSpecie.SelectedValue;
                    }					
					long tipo = long.Parse(cmbTipo.SelectedValue.ToString());
					long punti = long.Parse(mstxPunti.Text.Trim());
					string sesso = cmbSesso.SelectedItem.ToString();
					long LatoOscuro = long.Parse(mstxLatoOscuro.Text.Trim());
					DateTime dataCreazione = dtCreazione.Value.Date;
					long vivo = chkVivo.Checked ? 1 : 0;
					DateTime? dataMorte = null;
					string password = txtPassword.Text.Trim();
					long fazione = (long)cmbFazione.SelectedValue;
					string titolo = txtTitolo.Text.Trim();
					if (!chkVivo.Checked)
					{
						dataMorte = dtMorte.Value.Date;
					}
					if (numeroPg.HasValue)
					{
						res = manager.SaveCharacter(numeroPg.Value, nome, specie, tipo, punti, sesso, LatoOscuro, dataCreazione, vivo, dataMorte, password, fazione, titolo, attitudes);
					}
					else
					{
						long? newNumPg = null;
						if (!string.IsNullOrWhiteSpace(mstxNumeroPg.Text.Trim()))
						{
							newNumPg = long.Parse(mstxNumeroPg.Text.Trim());
						}
						res = manager.CreateNewCharacter(newNumPg, numeroSW.Value, nome, specie, tipo, punti, sesso, LatoOscuro, dataCreazione, vivo, dataMorte, password, fazione, titolo, attitudes);
					}
					if (res)
					{
						databaseContext.SaveChanges();
						this.Close();
					}
					else
					{
						MessageBox.Show("Errore durante il salvataggio, ricontrollare i dati inseriti");
					}
				}
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chkVivo_CheckedChanged(object sender, EventArgs e)
		{
			if (chkVivo.Checked)
			{
				dtMorte.Enabled = false;
			}
			else
			{
				dtMorte.Enabled = true;
			}
		}

		private void cmbTipo_SelectedValueChanged(object sender, EventArgs e)
		{
            //if (cmbTipo.SelectedValue.ToString() == "0")
            //{
            //    cmbSpecie.Visible = true;
            //    btnCreaSpecie.Visible = true;
            //    cmbAttitudine4.Visible = true;
            //    cmbAttitudine5.Visible = true;
            //}
            //else
            //{
            //    cmbSpecie.Visible = false;
            //    btnCreaSpecie.Visible = false;
            //    cmbAttitudine4.Visible = false;
            //    cmbAttitudine5.Visible = false;
            //}

            LoadAttitudini();
		}

		private void btnCreaSpecie_Click(object sender, EventArgs e)
		{
			InsertSpecie newForm = new InsertSpecie();
			newForm.ShowDialog();
			LoadData();
			LoadOriginalCharacter();
		}

		private void btnCompraAbilita_Click(object sender, EventArgs e)
		{
			AggiungiAbilita newForm = new AggiungiAbilita(numeroPg.Value);
			newForm.ShowDialog();
			using (databaseContext = CreateDatabaseContext())
			{
				PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
				txtPuntiLiberi.Text = manager.GetFreeSkillpoints(numeroPg.Value).ToString();
			}
			LoadSkills();
		}
	}
}

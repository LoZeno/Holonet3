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
using CommonBusiness.Notizie;
using CommonBusiness.Personaggi;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Notizie
{
    public partial class CreaNotizia : ToolboxManagerForm
	{
		private HolonetEntities databaseContext;

		private long? numeroNotizia = null;

		public CreaNotizia()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		public CreaNotizia(long ProgressivoNotizia)
			:this()
		{
			numeroNotizia = ProgressivoNotizia;
			LoadSingleNews();
		}

		private void LoadSingleNews()
		{
			if (numeroNotizia != null)
			{
				using (databaseContext = CreateDatabaseContext())
				{
					NotizieManager newsManager = new NotizieManager(databaseContext);
					Notizia newsToEdit = newsManager.GetSingleNewsItem(numeroNotizia.Value);
					txtOggetto.Text = newsToEdit.Titolo;
					cmbAutore.SelectedValue = newsToEdit.Autore;
					cmbFazione.SelectedValue = newsToEdit.Rete;
					txtTesto.Text = newsToEdit.Testo.Replace("<br />", "\r\n");
					dtCreazione.Value = newsToEdit.DataCreazione;
					dtFine.Value = newsToEdit.DataFine;
					numHacking.Value = newsToEdit.LivelloHacking;
				}
			}
		}

		private void LoadData()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				PersonaggiManagerNew characterManager = new PersonaggiManagerNew(databaseContext);
				cmbAutore.DataSource = characterManager.GetAllCharacters();
				cmbFazione.DataSource = characterManager.GetFactions();
				dtFine.Value = dtCreazione.Value.AddDays(1);
			}
		}

		private bool ValidateForm()
		{
			if (string.IsNullOrWhiteSpace(txtOggetto.Text))
			{
				MessageBox.Show("Inserire un titolo");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtTesto.Text))
			{
				MessageBox.Show("Inserire un testo");
				return false;
			}
			if (cmbAutore.SelectedValue == null)
			{
				MessageBox.Show("Selezionare un autore");
				return false;
			}
			if (cmbFazione.SelectedValue == null)
			{
				MessageBox.Show("Selezionare una rete");
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
				DialogResult res = MessageBox.Show("Stai per inviare la notizia: sei sicuro?", "Conferma invio", MessageBoxButtons.YesNo);
				if (res == System.Windows.Forms.DialogResult.Yes)
				{
					long autore = (long)cmbAutore.SelectedValue;
					long rete = (long)cmbFazione.SelectedValue;
					DateTime inizio = dtCreazione.Value;
					DateTime fine = dtFine.Value;
					long hacking = (long)numHacking.Value;
					using (databaseContext = CreateDatabaseContext())
					{
						NotizieManager manager = new NotizieManager(databaseContext);
						bool result = false;
						if (numeroNotizia == null)
						{
							result = manager.SendNews(txtOggetto.Text.Trim(), txtTesto.Text.Trim(), inizio, fine, rete, autore, hacking);
						}
						else
						{
							result = manager.UpdateNews(numeroNotizia.Value, txtOggetto.Text.Trim(), txtTesto.Text.Trim(), inizio, fine, rete, autore, hacking);
						}
						if (result)
						{
							databaseContext.SaveChanges();
							MessageBox.Show("Notizia inviata correttamente");
							this.Close();
						}
						else
						{
							MessageBox.Show("C'è stato un errore durante il salvataggio");
						}
					}
				}
			}
		}
	}
}

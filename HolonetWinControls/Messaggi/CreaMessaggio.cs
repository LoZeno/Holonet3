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
using CommonBusiness.Messaggi;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Messaggi
{
    public partial class CreaMessaggio : ToolboxManagerForm
	{
		private long? originalMessage = null;
		private HolonetEntities databaseContext;

		public CreaMessaggio()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		public CreaMessaggio(long MessaggioOriginale)
		{
			InitializeComponent();
			originalMessage = MessaggioOriginale;
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		private void LoadData()
		{
			dtInvio.Value = DateTime.Now;
			using (databaseContext = CreateDatabaseContext())
			{
				PersonaggiManagerNew characterManager = new PersonaggiManagerNew(databaseContext);
				lstDestinatari.DataSource = characterManager.GetAllCharacters();
                lstDestinatari.SelectedItem = null;
				if (!originalMessage.HasValue)
				{
					cmbMittente.DataSource = characterManager.GetAllCharacters();
					lstDestinatari.SelectedItem = null;
				}
				else
				{
					MessaggiManager messageManager = new MessaggiManager(databaseContext);
					Missione messaggio = messageManager.GetSingleMessage(originalMessage.Value);
					var mittentiPossibili = (from destinatari in messaggio.PostaInArrivoes
											 orderby destinatari.Personaggio.Nome
											 select destinatari.Personaggio).ToList();
					cmbMittente.DataSource = mittentiPossibili;
					lstDestinatari.SelectedValue = messaggio.Personaggio.NumeroPG;
					txtOggetto.Text = "Re: " + messaggio.Titolo;
					txtMessaggio.Text = "\r\n ---------- \r\n" + "Da: " + messaggio.Personaggio.Nome + "\r\nData: " + messaggio.DataCreazione + "\r\n" + messaggio.Testo.Replace("<br />", "\r\n").Replace("<br>", "\r\n");
				}
				
			}
		}

		private bool ValidateForm()
		{
			if (cmbMittente.SelectedValue == null)
			{
				MessageBox.Show("Selezionare un mittente");
				return false;
			}
			if (lstDestinatari.SelectedValue == null)
			{
				MessageBox.Show("Selezionare almeno un destinatario");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtOggetto.Text))
			{
				MessageBox.Show("Inserire un titolo");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtMessaggio.Text))
			{
				MessageBox.Show("Inserire un messaggio");
				return false;
			}
			return true;
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnInvia_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				long mittente = (long)cmbMittente.SelectedValue;
				List<long> destinatari = new List<long>();
				DateTime dataInvio = DateTime.Now;
				if (dtInvio.Value > DateTime.Now)
				{
					dataInvio = dtInvio.Value;
				}
				foreach (var item in lstDestinatari.SelectedItems)
				{
					destinatari.Add(((Personaggio)item).NumeroPG);
				}
				using (databaseContext = CreateDatabaseContext())
				{

					MessaggiManager manager = new MessaggiManager(databaseContext);
					bool res = manager.SendMessage(mittente, destinatari, txtOggetto.Text.Trim(), txtMessaggio.Text.Trim(), (long)numCrypt.Value, dataInvio);
					if (res)
					{
						databaseContext.SaveChanges();
						MessageBox.Show("Messaggio inviato");
						this.Close();
					}
					else
					{
						MessageBox.Show("C'è stato un errore durante l'invio");
					}
				}
			}
		}
	}
}

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
using CommonBusiness.Eventi;
using CommonBusiness.Giocatori;
using CommonBusiness.Personaggi;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Eventi
{
    public partial class IscriviGiocatore : ToolboxManagerForm
	{
		private long cdEvento;
		private HolonetEntities databaseContext;

		public IscriviGiocatore()
		{
			InitializeComponent();
		}

		public IscriviGiocatore(long CdEvento)
			:this()
		{
			cdEvento = CdEvento;
			LoadData();
		}

		private void LoadData()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				EventiManagerNew eventManager = new EventiManagerNew(databaseContext);
				Evento myEvent = eventManager.GetEventFromNumber(cdEvento);
				txtNomeEvento.Text = myEvent.TitoloEvento;

				grdGiorni.DataSource = myEvent.EventoGiornis;

				GiocatoriManager manager = new GiocatoriManager(databaseContext);
				IList<Giocatore> source = manager.GetAllPlayers();
				cmbGiocatore.DataSource = source;
			}
		}

		private void cmbGiocatore_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cmbGiocatore.SelectedValue != null)
			{
				long NumeroSW = (long)cmbGiocatore.SelectedValue;
				using (databaseContext = CreateDatabaseContext())
				{
					PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
					cmbPersonaggio.ValueMember = "NumeroPG";
					cmbPersonaggio.DisplayMember = "NumeroENomeCombo";
					cmbPersonaggio.DataSource = manager.GetCharactersByPlayer(NumeroSW);
					btnSalva.Enabled = true;
				}
			}
			else
			{
				cmbPersonaggio.DataSource = null;
				btnSalva.Enabled = false;
			}
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			if (cmbPersonaggio.SelectedValue != null)
			{
				long numeroPg = (long)cmbPersonaggio.SelectedValue;
				if (grdGiorni.SelectedRows.Count > 0)
				{
					List<DateTime> giorni = new List<DateTime>();
					StringBuilder confirmationMessage = new StringBuilder();
					confirmationMessage.Append("Stai per iscrivere il personaggio ");
					confirmationMessage.Append(numeroPg);
					confirmationMessage.Append(" ai giorni: ");
					for (int i = 0; i < grdGiorni.SelectedRows.Count; i++)
					{
						DateTime data = (DateTime)grdGiorni.SelectedRows[i].Cells["DataGiorno"].Value;
						giorni.Add(data);
						confirmationMessage.Append(data.Date.ToString("dd/MM/yyyy") + " ");
					}
					confirmationMessage.AppendLine();
					confirmationMessage.Append("Sei sicuro? Questa iscrizione sovrascriverà la precedente (se presente)");

					DialogResult confirmation = MessageBox.Show(confirmationMessage.ToString(), "CONFERMA ISCRIZIONE", MessageBoxButtons.YesNo);

					if (confirmation == System.Windows.Forms.DialogResult.Yes)
					{
						using (databaseContext = CreateDatabaseContext())
						{
							EventiManagerNew eventManager = new EventiManagerNew(databaseContext);
							bool res = eventManager.SubscribePlayerCharacter(cdEvento, giorni, numeroPg);
							if (res)
							{
								databaseContext.SaveChanges();
								MessageBox.Show("Iscrizione completata");
								this.Close();
							}
							else
							{
								MessageBox.Show("Errore durante la transazione");
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Selezionare almeno un giorno");
				}
			}
			else
			{
				MessageBox.Show("Selezionare un personaggio");
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

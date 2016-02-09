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
using CommonBusiness.Messaggi;
using CommonBusiness.Personaggi;
using System.Collections;

namespace HolonetWinControls.Messaggi
{
	public partial class ControlMessaggi : BaseManagerUserControl
	{
		#region membri privati
		private int startPage = 0;
		private short pageSize = 50;
		private HolonetEntities databaseContext;
		#endregion


		public ControlMessaggi()
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
				MessaggiManager manager = new MessaggiManager(databaseContext);
				IList<Missione> messaggi = manager.GetPagedMessagesList(startPage, pageSize);
				grdMessaggi.DataSource = messaggi;
				svuotaControlli();
			}

		}

		private void svuotaControlli()
		{
			txtDestinatari.Text = null;
			txtTesto.Text = null;
		}

		private void cmbSelezionaDestinatario_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cmbSelezionaDestinatario.SelectedValue != null)
			{
				long numeroPg = (long)cmbSelezionaDestinatario.SelectedValue;
				IList<Missione> elenco = null;
				using (databaseContext = CreateDatabaseContext())
				{
					MessaggiManager manager = new MessaggiManager(databaseContext);
					elenco = manager.GetLatestIncomingMessageByCharacter(numeroPg).ToList<Missione>();
				}
				grdMessaggi.DataSource = elenco;
			}
		}

		private void grdMessaggi_SelectionChanged(object sender, EventArgs e)
		{
			svuotaControlli();
			if (grdMessaggi.SelectedRows.Count == 1)
			{
				long numeroMissione = (long)grdMessaggi.SelectedRows[0].Cells["NumeroMissione"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					MessaggiManager manager = new MessaggiManager(databaseContext);
					Missione messaggio = manager.GetSingleMessage(numeroMissione);
					txtTesto.Text = string.IsNullOrWhiteSpace(messaggio.Testo) ? null : messaggio.Testo.Replace("<br />", "\r\n");
					foreach (var destinatario in messaggio.PostaInArrivoes)
					{
						txtDestinatari.Text += destinatario.Personaggio.NumeroENomeCombo + "\r\n";
					}
				}
			}
		}

		private void lnkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			startPage -= 50;
			if (startPage < 0)
			{
				startPage = 0;
			}
			LoadData();
		}

		private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (databaseContext = CreateDatabaseContext())
			{
				MessaggiManager manager = new MessaggiManager(databaseContext);
				int max = manager.Count();
				startPage += 50;
				if (startPage >= max)
				{
					startPage = max - 50;
					if (startPage < 0)
					{
						startPage = 0;
					}
				}
			}
			LoadData();
		}

		private void chkShowAll_CheckedChanged(object sender, EventArgs e)
		{
			if (chkShowAll.Checked)
			{
				cmbSelezionaDestinatario.Enabled = false;
				cmbSelezionaDestinatario.DataSource = new List<Personaggio>();
				svuotaControlli();
				LoadData();
			}
			else
			{
				using (databaseContext = CreateDatabaseContext())
				{
					PersonaggiManagerNew characterManager = new PersonaggiManagerNew(databaseContext);
					cmbSelezionaDestinatario.DataSource = characterManager.GetAllCharacters();
				}
				cmbSelezionaDestinatario.Enabled = true;
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (chkShowAll.Checked)
			{
				LoadData();
			}
			else
			{
				if (cmbSelezionaDestinatario.SelectedValue != null)
				{
					long numeroPg = (long)cmbSelezionaDestinatario.SelectedValue;
					IList<Missione> elenco = null;
					using (databaseContext = CreateDatabaseContext())
					{
						MessaggiManager manager = new MessaggiManager(databaseContext);
						elenco = manager.GetLatestIncomingMessageByCharacter(numeroPg).ToList<Missione>();
					}
					grdMessaggi.DataSource = elenco;
				}
			}
		}

		private void btnNuovo_Click(object sender, EventArgs e)
		{
			CreaMessaggio newForm = new CreaMessaggio();
			newForm.ShowDialog();
			LoadData();
		}

		private void btnRispondi_Click(object sender, EventArgs e)
		{
			if (grdMessaggi.SelectedRows.Count == 1)
			{
				long numeroMissione = (long)grdMessaggi.SelectedRows[0].Cells["NumeroMissione"].Value;
				CreaMessaggio newForm = new CreaMessaggio(numeroMissione);
				newForm.ShowDialog();
				LoadData();
			}
		}
	}
}

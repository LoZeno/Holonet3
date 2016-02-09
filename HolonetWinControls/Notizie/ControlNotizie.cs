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
using CommonBusiness.Personaggi;
using CommonBusiness.Notizie;

namespace HolonetWinControls.Notizie
{
	public partial class ControlNotizie : BaseManagerUserControl
	{
		#region membri privati
		private int startPage = 0;
		private short pageSize = 50;
		private HolonetEntities databaseContext;
		#endregion

		public ControlNotizie()
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
			{
				LoadData();
			}
		}

		public override void LoadData()
		{
			dtVisualizzazione.Value = DateTime.Now;
			using (databaseContext = CreateDatabaseContext())
			{
				PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
				cmbFazione.DataSource = manager.GetFactions();
			}
			LoadNews();
		}

		private void LoadNews()
		{
			txtTesto.Text = string.Empty;
			if (cmbFazione.SelectedValue != null)
			{
				long rete = (long)cmbFazione.SelectedValue;
				DateTime data = dtVisualizzazione.Value;
				using (databaseContext = CreateDatabaseContext())
				{
					NotizieManager manager = new NotizieManager(databaseContext);
					IList<Notizia> notizie;
					if (chkAll.Checked)
					{
						notizie = manager.GetNews(rete);
					}
					else
					{
						notizie = manager.GetNews(rete, data);
					}
					grdNotizie.DataSource = notizie;
				}
			}
		}

		private void btnNuovaNotizia_Click(object sender, EventArgs e)
		{
			CreaNotizia newForm = new CreaNotizia();
			newForm.ShowDialog();
			LoadData();
		}

		private void cmbFazione_SelectedValueChanged(object sender, EventArgs e)
		{
			LoadNews();
		}

		private void grdNotizie_SelectionChanged(object sender, EventArgs e)
		{
			if (grdNotizie.SelectedRows.Count == 1)
			{
				long numeroMissione = (long)grdNotizie.SelectedRows[0].Cells["NumeroNotizia"].Value;
				using (databaseContext = CreateDatabaseContext())
				{
					NotizieManager manager = new NotizieManager(databaseContext);
                    PersonaggiManagerNew charManager = new PersonaggiManagerNew(databaseContext);
					Notizia singleNew = manager.GetSingleNewsItem(numeroMissione);
                    Personaggio autore = charManager.GetCharacterByNumber(singleNew.Autore.Value);
                    txtTesto.Text = "AUTORE: " + autore.Nome + "\r\n \r\n";
					txtTesto.Text += singleNew.Testo.Replace("<br />", "\r\n");
				}
			}
		}

		private void dtVisualizzazione_ValueChanged(object sender, EventArgs e)
		{
			LoadNews();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (grdNotizie.SelectedRows.Count == 1)
			{
				long numeroMissione = (long)grdNotizie.SelectedRows[0].Cells["NumeroNotizia"].Value;
				CreaNotizia newForm = new CreaNotizia(numeroMissione);
				newForm.ShowDialog();
				LoadData();
			}
		}

		private void chkAll_CheckedChanged(object sender, EventArgs e)
		{
			dtVisualizzazione.Enabled = !chkAll.Checked;
			LoadNews();
		}
	}
}

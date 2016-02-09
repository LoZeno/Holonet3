//-----------------------------------------------------------------------

// <copyright file="ControlEventi.cs" company="SWLive.it">

// Copyright (c) SWLive.it. All rights reserved.

// <author>Luca "Lo Zeno" Zenari</author>

// <date>Wednesday, January 23, 2013 8:59:05 AM</date>

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using HolonetManager.BaseClasses;
using CommonBusiness.Eventi;
using System.Collections;
using Reports;
using HolonetWinControls.Eventi;

namespace HolonetManager.Eventi
{
    public partial class ControlEventi : BaseManagerUserControl
	{
		#region private members
		private int startPage = 0;
        private short pageSize = 50;
        private EventiManager manager = null;
		private HolonetEntities databaseContext;
        
		#endregion

		public ControlEventi()
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
            {
                manager = new EventiManager(HolonetConnectionString);
                var events = manager.GetPagedEventsList(startPage, pageSize);
                grdEventi.DataSource = events;
            }
        }

        /// <summary>
        /// Carica i dati della griglia Eventi
        /// </summary>
        public override void LoadData()
        {
            CheckManager();
            if (manager != null)
            {
                var events = manager.GetPagedEventsList(startPage, pageSize);
				//BindingList<Evento> lista = new BindingList<Evento>(events);
                grdEventi.DataSource = events;
				//grdEventi.DataSource = lista;
            }
        }

        #region metodi privati

        /// <summary>
        /// Controlla che la classe di gestione per i dati degli Eventi sia inizializzata
        /// </summary>
        private void CheckManager()
        {
            if (manager == null)
            {
                if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
                {
                    manager = new EventiManager(HolonetConnectionString);
                }
            }
        }

        private void grdEventi_SelectionChanged(object sender, EventArgs e)
        {
            CheckManager();
            if (grdEventi.SelectedRows.Count > 0)
            {
                if (grdEventi.Columns.Contains("Numero") && grdEventi.SelectedRows[0].Cells["Numero"].Value != null)
                {
                    long codEvento = long.Parse(grdEventi.SelectedRows[0].Cells["Numero"].Value.ToString());
                    var giorniEvento = manager.GetDaysList(codEvento);
                    grdGiorni.DataSource = giorniEvento;
					grdPersonaggi.DataSource = null;
                }
            }
            else
            {
                grdGiorni.DataSource = null;
				grdPersonaggi.DataSource = null;
            }
        }

        private void grdGiorni_SelectionChanged(object sender, EventArgs e)
        {
			LoadSubscribers();
        }

		private void LoadSubscribers()
		{
			long currentCdEvento = 0;
			List<DateTime> elencoGiorni = new List<DateTime>();
			foreach (DataGridViewRow selectedRow in grdGiorni.SelectedRows)
			{
				currentCdEvento = long.Parse(selectedRow.Cells["CdEvento"].Value.ToString());
				elencoGiorni.Add(((DateTime)selectedRow.Cells["DataGiorno"].Value).Date);
			}
			if (currentCdEvento != 0 && elencoGiorni.Count > 0)
			{
				IList elencoRaggruppato = null;

				if (elencoGiorni.Count == grdGiorni.RowCount)
				{
					elencoRaggruppato = manager.GetPlayingCharacters(currentCdEvento, elencoGiorni);
				}
				else if (elencoGiorni.Count == 1)
				{
					elencoRaggruppato = manager.GetPlayingCharactersForDay(currentCdEvento, elencoGiorni[0]);
				}

				grdPersonaggi.DataSource = elencoRaggruppato;
			}
		}
        #endregion

		private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			startPage -= 50;
			if (startPage < 0)
			{
				startPage = 0;
			}
			LoadData();
		}

		private void lnkForward_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
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
			LoadData();
		}

		private void grdEventi_DataSourceChanged(object sender, EventArgs e)
		{
			if (grdEventi.RowCount > 0)
			{
				grdEventi.Rows[0].Selected = true;
			}
		}

		private void grdGiorni_DataSourceChanged(object sender, EventArgs e)
		{
			if (grdGiorni.RowCount > 0)
			{
				grdEventi.Rows[0].Selected = true;
			}
		}

		private void btnNewEvent_Click(object sender, EventArgs e)
		{
			InsertEvent insertForm = new InsertEvent();
			insertForm.ShowDialog();
			LoadData();
		}

        private void btnStampaIscritti_Click(object sender, EventArgs e)
        {
			Cursor.Current = Cursors.WaitCursor;
			if (grdEventi.SelectedRows.Count == 1)
			{
				FolderBrowserDialog selectFolder = new FolderBrowserDialog();
				var res = selectFolder.ShowDialog();
				if (res == DialogResult.OK)
				{
					string path = selectFolder.SelectedPath;
					long cdEvento = (long)grdEventi.SelectedRows[0].Cells["Numero"].Value;
					string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
					using (databaseContext = CreateDatabaseContext())
					{
						EventiManagerNew manager = new EventiManagerNew(databaseContext);
						List<Personaggio> listaPersonaggi = manager.GetPlayingCharacters(cdEvento).ToList();
						CartelliniPersonaggio cartellini = new CartelliniPersonaggio(path + @"\Personaggio-" + date, listaPersonaggi, cdEvento);
						cartellini.Save();
						List<Personaggio> personaggiAbilitaAvanzate = new List<Personaggio>();
						foreach (var personaggio in listaPersonaggi)
						{
							var abilitaAvanzate = from abilita in personaggio.AbilitaPersonaggios
											  where abilita.Abilita.BaseAvanzato == 1
											  orderby abilita.Abilita.Nome ascending
											  select abilita;
							if (abilitaAvanzate.Count() > 0)
							{
								personaggiAbilitaAvanzate.Add(personaggio);
							}
						}
						if (personaggiAbilitaAvanzate.Count > 0)
						{
							CartelliniAbilitaAvanzate sintesiAbilita = new CartelliniAbilitaAvanzate(path + @"\Abilita-" + date, personaggiAbilitaAvanzate);
							sintesiAbilita.Save();
						}
					}
					MessageBox.Show("Stampa avvenuta");
					OpenFolder(path);
				}
			}
			Cursor.Current = Cursors.Default;
        }

		private void btnIscrivi_Click(object sender, EventArgs e)
		{
			if (grdEventi.SelectedRows.Count == 1)
			{
                if (!(bool)grdEventi.SelectedRows[0].Cells["Chiuso"].Value)
                {
                    long cdEvento = (long)grdEventi.SelectedRows[0].Cells["Numero"].Value;
                    IscriviGiocatore newForm = new IscriviGiocatore(cdEvento);
                    newForm.ShowDialog();
                    LoadSubscribers();
                }
                else
                {
                    MessageBox.Show("L'evento � chiuso");
                }
			}
		}

		private void btnDate_Click(object sender, EventArgs e)
		{
			if (grdEventi.SelectedRows.Count == 1)
			{
                if (!(bool)grdEventi.SelectedRows[0].Cells["Chiuso"].Value)
                {
                    long cdEvento = (long)grdEventi.SelectedRows[0].Cells["Numero"].Value;
                    ModificaDate newForm = new ModificaDate(cdEvento);
                    newForm.ShowDialog();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("L'evento � chiuso");
                }
			}
		}

		private void btnAggiungiGiorno_Click(object sender, EventArgs e)
		{
			if (grdEventi.SelectedRows.Count == 1)
			{
                if (!(bool)grdEventi.SelectedRows[0].Cells["Chiuso"].Value)
                {
                    long cdEvento = (long)grdEventi.SelectedRows[0].Cells["Numero"].Value;
                    AggiungiGiorno newForm = new AggiungiGiorno(cdEvento);
                    newForm.ShowDialog();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("L'evento � chiuso");
                }
			}
		}

        private void btnGestionePunti_Click(object sender, EventArgs e)
        {
            if (grdEventi.SelectedRows.Count == 1)
            {
                if (!(bool)grdEventi.SelectedRows[0].Cells["Chiuso"].Value)
                {
                    long cdEvento = (long)grdEventi.SelectedRows[0].Cells["Numero"].Value;
                    GestisciPartecipanti newForm = new GestisciPartecipanti(cdEvento);
                    newForm.ShowDialog();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("L'evento � gi� stato chiuso. Per modificare i PX dei personaggi usare il tab Giocatori e Personaggi");
                }
            }
        }
    }
}

//-----------------------------------------------------------------------

// <copyright file="ControlPersonaggi.cs" company="SWLive.it">

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
using CommonBusiness.Personaggi;
using HolonetManager.BaseClasses;
using Reports;
using DataAccessLayer;
using CommonBusiness.Giocatori;

namespace HolonetWinControls.Personaggi
{
	public partial class ControlPersonaggi : BaseManagerUserControl
	{
		PersonaggiManager manager;
        private HolonetEntities databaseContext;
        private int startPage = 0;
        private short pageSize = 50;

		public ControlPersonaggi()
		{
			InitializeComponent();
            if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
            {
                LoadData();
            }
		}

		public override void LoadData()
		{
			CheckManager();
            using (databaseContext = CreateDatabaseContext())
            {
                GiocatoriManager playerManager = new GiocatoriManager(databaseContext);
                grdGiocatori.DataSource = playerManager.GetPagedPlayers(startPage, pageSize);

            }
		}

		/// <summary>
		/// Controlla che la classe di gestione per i dati degli Eventi sia inizializzata
		/// </summary>
		private void CheckManager()
		{
			if (manager == null)
			{
				if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
				{
					manager = new PersonaggiManager(HolonetConnectionString);
				}
			}
		}

		private void btnVerifyGuid_Click(object sender, EventArgs e)
		{
			CheckManager();
			manager.CheckAllGuid();
		}

		private void btnNuovoGiocatore_Click(object sender, EventArgs e)
		{
			InsertGiocatore insertPlayerForm = new InsertGiocatore();
			insertPlayerForm.ShowDialog();
			LoadData();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			object selectedValue = grdGiocatori.SelectedRows[0].Cells["NumeroSW"].Value;
			if (selectedValue != null)
			{
				InsertGiocatore editPlayerForm = new InsertGiocatore((long)selectedValue);
				editPlayerForm.ShowDialog();
				LoadData();
			}
		}

		private void btnPersonaggio_Click(object sender, EventArgs e)
		{
			
			if (grdGiocatori.SelectedRows.Count > 0)
			{
				long numSw = (long)grdGiocatori.SelectedRows[0].Cells["NumeroSW"].Value;
				InsertPersonaggio newForm = new InsertPersonaggio(numSw);
				newForm.ShowDialog();
				LoadCharactersGrid();
			}
		}

        private void btnStampaPers_Click(object sender, EventArgs e)
        {
			Cursor.Current = Cursors.WaitCursor;
			if (grdPersonaggi.SelectedRows.Count > 0)
            {
                FolderBrowserDialog selectFolder = new FolderBrowserDialog();
                var res = selectFolder.ShowDialog();
                if (res == DialogResult.OK)
                {
					string path = selectFolder.SelectedPath;
					long numeroPg = (long)grdPersonaggi.SelectedRows[0].Cells["NumeroPG"].Value;
					string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
					using (databaseContext = CreateDatabaseContext())
					{
						PersonaggiManagerNew manager = new PersonaggiManagerNew(databaseContext);
						List<Personaggio> itemsToPrint = new List<Personaggio>();
						itemsToPrint.Add(manager.GetCharacterByNumber(numeroPg));
						CartelliniPersonaggio cartellino = new CartelliniPersonaggio(path+@"\Personaggio-"+date, itemsToPrint);
						cartellino.Save();
						List<Personaggio> personaggiAbilitaAvanzate = new List<Personaggio>();
						foreach (var personaggio in itemsToPrint)
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
							CartelliniAbilitaAvanzate descrizioniAbilita = new CartelliniAbilitaAvanzate(path + @"\Abilita-" + date, personaggiAbilitaAvanzate);
							descrizioniAbilita.Save();
						}
					}
					MessageBox.Show("Stampa avvenuta");
					OpenFolder(path);
				}
			}
			Cursor.Current = Cursors.Default;
        }

        private void grdGiocatori_SelectionChanged(object sender, EventArgs e)
        {
            LoadCharactersGrid();
        }

        private void LoadCharactersGrid()
        {
            if (grdGiocatori.SelectedRows.Count == 1)
            {
                long numeroSW = (long)grdGiocatori.SelectedRows[0].Cells["NumeroSW"].Value;
                using (databaseContext = CreateDatabaseContext())
                {
                    PersonaggiManagerNew characterManager = new PersonaggiManagerNew(databaseContext);
                    grdPersonaggi.DataSource = characterManager.GetCharactersByPlayer(numeroSW);
                }
            }
            else
            {
                grdPersonaggi.DataSource = null;
            }
        }

        private void btnEditPers_Click(object sender, EventArgs e)
        {
			if (grdPersonaggi.SelectedRows.Count == 1)
			{
                long numeroSw = (long)grdPersonaggi.SelectedRows[0].Cells["NumeroSW_Character"].Value;
				long numeroPg = (long)grdPersonaggi.SelectedRows[0].Cells["NumeroPG"].Value;
				InsertPersonaggio newForm = new InsertPersonaggio(numeroSw, numeroPg);
				newForm.ShowDialog();
				LoadCharactersGrid();
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
                GiocatoriManager manager = new GiocatoriManager(databaseContext);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                long? numberToSearch = null;
                try
                {
                    numberToSearch = long.Parse(txtSearch.Text.Trim());
                }
                catch
                {
                    numberToSearch = null;
                }

                using (databaseContext = CreateDatabaseContext())
                {
                    GiocatoriManager playerManager = new GiocatoriManager(databaseContext);
                    PersonaggiManagerNew characterManager = new PersonaggiManagerNew(databaseContext);

                    if (numberToSearch.HasValue)
                    {
                        List<Giocatore> firstSource = new List<Giocatore>();
                        List<Personaggio> secondSource = new List<Personaggio>();
                        firstSource.Add(playerManager.GetPlayerFromNumberSW(numberToSearch.Value));
                        secondSource.Add(characterManager.GetCharacterByNumber(numberToSearch.Value));
                        grdGiocatori.DataSource = firstSource;
                        grdPersonaggi.DataSource = secondSource;
                    }
                    else
                    {
                        grdGiocatori.DataSource = playerManager.GetPlayerByName(txtSearch.Text.Trim());
                        grdPersonaggi.DataSource = characterManager.GetCharactersByName(txtSearch.Text.Trim());
                    }
                }
            }
            else
            {
                LoadData();
            }
        }
	}
}

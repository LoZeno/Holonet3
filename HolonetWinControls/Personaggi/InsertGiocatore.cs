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
using CommonBusiness.Giocatori;
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Personaggi
{
    public partial class InsertGiocatore : ToolboxManagerForm
	{
		private long? originalPlayer = null;
        private HolonetEntities databaseContext = null;

		public InsertGiocatore(long NumeroSW)
			: this()
		{
			originalPlayer = NumeroSW;
            using (databaseContext = CreateDatabaseContext())
            {
                GiocatoriManager manager = new GiocatoriManager(databaseContext);
                Giocatore giocatore = manager.GetPlayerFromNumberSW(originalPlayer.Value);
                txtCAP.Text = giocatore.CAP;
                txtCitta.Text = giocatore.Citta;
                txtCognome.Text = giocatore.Cognome;
                txtEmail.Text = giocatore.Email;
                txtIndirizzo.Text = giocatore.Indirizzo;
                txtNome.Text = giocatore.Nome;
                txtPassword.Text = giocatore.Password;
                txtProvincia.Text = giocatore.Provincia;
                txtTelefono.Text = giocatore.Telefono;
                dtIscrizione.Value = giocatore.DataIscrizione;
                dtNascita.Value = giocatore.DataNascita;
                cmbSesso.SelectedValue = giocatore.Sesso;
                cmbTipoGiocatore.SelectedValue = giocatore.TipoGiocatore;
            }
		}

		public InsertGiocatore()
		{
			InitializeComponent();
            if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
            {
                LoadData();
            }
		}

        private void LoadData()
        {
        }

        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome obbligatorio");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCognome.Text))
            {
                MessageBox.Show("Cognome obbligatorio");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbSesso.Text))
            {
                MessageBox.Show("Selezionare un sesso");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbTipoGiocatore.SelectedItem.ToString()))
            {
                MessageBox.Show("Selezionare un tipo di giocatore");
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
            if (validateForm())
            {
                using (databaseContext = CreateDatabaseContext())
                {
                    GiocatoriManager manager = new GiocatoriManager(databaseContext);
                    DateTime dataIscrizione = dtIscrizione.Value.Date;
                    DateTime dataNascita = dtNascita.Value.Date;

                    bool res = manager.SavePlayer(originalPlayer, txtCognome.Text.Trim(), txtNome.Text.Trim(), dataNascita, txtIndirizzo.Text.Trim(), txtCitta.Text.Trim(), txtProvincia.Text.Trim(), txtCAP.Text.Trim(), txtTelefono.Text.Trim(), dataIscrizione, cmbSesso.SelectedItem.ToString(), cmbTipoGiocatore.SelectedItem.ToString(), txtEmail.Text.Trim(), txtPassword.Text.Trim());

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
	}
}

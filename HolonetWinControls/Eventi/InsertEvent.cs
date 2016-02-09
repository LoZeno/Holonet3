using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolonetManager.BaseClasses;
using CommonBusiness.Eventi;
using DataAccessLayer;
using HolonetWinControls.BaseClasses;

namespace HolonetManager.Eventi
{
    public partial class InsertEvent : ToolboxManagerForm
	{
		private List<DateTime> eventDates = new List<DateTime>();
        private HolonetEntities databaseContext;

		public InsertEvent()
		{
			InitializeComponent();
			lblWarningMessage.Text = string.Empty;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
                using (databaseContext = CreateDatabaseContext())
                {
                    EventiManagerNew manager = new EventiManagerNew(databaseContext);
                    bool res = manager.InsertNewEventComplete(txtTitolo.Text.Trim(), txtDescription.Text.Trim(), double.Parse(txtCosto.Text.Trim()), int.Parse(txtPX.Text.Trim()), eventDates, timepickInGioco.Value, timepickFuoriGioco.Value, timepickStandardIg.Value, timepickStandardFg.Value);
                    if (res)
                    {
                        databaseContext.SaveChanges();
                        MessageBox.Show("Evento salvato");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ricontrollare i dati: salvataggio non possibile");
                    }
                }
			}
		}

		private bool ValidateForm()
		{
			lblWarningMessage.Text = string.Empty;
			bool res = true;
			if (string.IsNullOrWhiteSpace(txtTitolo.Text))
			{
				lblWarningMessage.Text += "Il titolo è obbligatorio. ";
				res = false;
			}
			if (calendarGiorni.SelectionRange.Start == null || calendarGiorni.SelectionRange.End == null)
			{
                lblWarningMessage.Text += "Inserire un giorno di inizio e uno di fine. ";
				res = false;
			}
			if (calendarGiorni.SelectionStart != null)
			{
				eventDates = new List<DateTime>();
				TimeSpan difference = calendarGiorni.SelectionEnd.Date.Subtract(calendarGiorni.SelectionStart.Date);
				int length = difference.Days;
				for (int i = 0; i <= length; i++)
				{
					eventDates.Add(calendarGiorni.SelectionStart.Date.AddDays(i));
				}
				EventiManager manager = new EventiManager(HolonetConnectionString);
				if (manager.DatesAlreadyInUse(eventDates))
				{
                    lblWarningMessage.Text += "Le date sono occupate da un altro evento. ";
					res = false;
				}
			}
            try
            {
                double test = double.Parse(txtCosto.Text.Trim());
            }
            catch
            {
                lblWarningMessage.Text += "Il costo in euro del live deve essere un numero. ";
                res = false;
            }
            try
            {
                int test1 = int.Parse(txtPX.Text.Trim());
            }
            catch
            {
                lblWarningMessage.Text += "Il campo PX deve contenere un numero intero. ";
                res = false;
            }

			
			return res;
		}
	}
}

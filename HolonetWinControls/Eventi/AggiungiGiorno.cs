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
using HolonetWinControls.BaseClasses;

namespace HolonetWinControls.Eventi
{
	public partial class AggiungiGiorno : ToolboxManagerForm
	{
		private long cdEvento;
		private HolonetEntities databaseContext;

		public AggiungiGiorno()
		{
			InitializeComponent();
		}

		public AggiungiGiorno(long CdEvento)
			:this()
		{
			cdEvento = CdEvento;
		}

		private void LoadData()
		{
			using (databaseContext = CreateDatabaseContext())
			{
				EventiManagerNew manager = new EventiManagerNew(databaseContext);
				Evento myEvent = manager.GetEventFromNumber(cdEvento);
				calGiorno.MinDate = myEvent.DataEvento;
			}
		}

		private void btnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSalva_Click(object sender, EventArgs e)
		{
			DateTime selectedDate = calGiorno.SelectionStart;
			using (databaseContext = CreateDatabaseContext())
			{
				EventiManagerNew manager = new EventiManagerNew(databaseContext);
				Evento myEvent = manager.GetEventFromNumber(cdEvento);
				bool CanAdd = true;
				foreach (var giorno in myEvent.EventoGiornis)
				{
					if (giorno.DataGiorno.Date == selectedDate.Date)
					{
						CanAdd = false;
						break;
					}
				}
				if (CanAdd)
				{
					bool success = manager.AddDayToEvent(cdEvento, selectedDate.Date);
					if (success)
					{
						databaseContext.SaveChanges();
						this.Close();
					}
					else
					{
						MessageBox.Show("Si è verificato un errore durante il salvataggio");
					}
				}
				else
				{
					MessageBox.Show("Giorno già presente");
				}
			}
		}
	}
}

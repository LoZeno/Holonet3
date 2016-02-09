using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using CommonBusiness.Personaggi;
using CommonBusiness.Sostanze;
using DataAccessLayer;

namespace Holonet3.LaboratorioBiochimico
{
	public partial class NewLaboratorioBiochimico : HolonetPage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			qrReader.OnCodeDecoded += new EventHandler(qrReader_OnCodeDecoded);
			Timer1.Tick += new EventHandler<EventArgs>(Timer1_Tick);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				bool canUse = false;
				if (LoggedCharacter != null)
				{
					PersonaggiManagerNew manager = new PersonaggiManagerNew(DatabaseContext);
					canUse = manager.HasSkill(LoggedCharacter.NumeroPG, 2);
				}
				if (canUse)
				{
					resetFields();
				}
				else
				{
					Response.Redirect("~/Default.aspx");
				}
			}
		}

		protected void btnReset_Click(object sender, EventArgs e)
		{
			resetResults();
			resetFields();
		}

		protected void btnCrea_Click(object sender, EventArgs e)
		{
			Timer1.Interval = 45000;
			Timer1.Enabled = true;
			ElaborazioneViews.SetActiveView(viewElaborazione);
		}

		private void resetFields()
		{
			hidField.Value = null;
			lblDescrizione.Text = "Inserire ingredienti";
			txtElencoIngredienti.Text = string.Empty;
			btnCrea.Enabled = false;
			ElaborazioneViews.SetActiveView(viewAttesa);
		}

		private void resetResults()
		{
			lblNome.Text =
			lblEffetto.Text =
			lblDescrizione.Text =
			lblData.Text =
			lblCosto.Text =
			lblEfficacia.Text =
			lblTipo.Text =
			lblModoUso.Text = string.Empty;
			imgOggetto.ImageUrl = string.Empty;
			imgOggetto.Visible = false;
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			Timer1.Enabled = false;
			string[] ingredientiLetti = hidField.Value.Split(';');
			List<long?> progressiviIngredienti = new List<long?>();
			for (int i = 0; i < ingredientiLetti.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(ingredientiLetti[i]))
				{
					long progressivo = long.Parse(ingredientiLetti[i]);
					progressiviIngredienti.Add(progressivo);
				}
			}
			SostanzeManager manager = new SostanzeManager(DatabaseContext);
			NewSostanze sostanza = manager.GetSubstanceFromListOfComponents(progressiviIngredienti);
			ElaborazioneViews.SetActiveView(viewRisultato);
			if (sostanza != null)
			{
				if (sostanza.Tipo == 0 || sostanza.Tipo == 2 || sostanza.Tipo == 3)
				{
					lblNome.Text = sostanza.Nome;
					if (!string.IsNullOrWhiteSpace(sostanza.Descrizione))
					{
						lblDescrizione.Text = sostanza.Descrizione.Replace("\r", "<br />");
					}
					if (!string.IsNullOrWhiteSpace(sostanza.Effetto))
					{
						lblEffetto.Text = sostanza.Effetto.Replace("\r", "<br />");
					}
					lblData.Text = sostanza.DataScadenza.HasValue ? sostanza.DataScadenza.Value.ToString("dd/MM/yyyy") : string.Empty;
					lblCosto.Text = sostanza.Costo.ToString();
					lblEfficacia.Text = sostanza.ValoreEfficacia.ToString();
					lblTipo.Text = sostanza.TipoSostanze.Descrizione;
					lblModoUso.Text = sostanza.ModoUso;
					if (!string.IsNullOrWhiteSpace(sostanza.Immagine))
					{
						imgOggetto.Visible = true;
						imgOggetto.ImageUrl = sostanza.Immagine;
					}
					btnCrea.Enabled = false;
				}
				else
				{
					resetResults();
					ElaborazioneViews.SetActiveView(viewAttesa);
					lblDescrizione.Text = "Gli ingredienti inseriti non hanno dato un risultato";
				}
			}
			else
			{
				resetResults();
				ElaborazioneViews.SetActiveView(viewAttesa);
				lblDescrizione.Text = "Gli ingredienti inseriti non hanno dato un risultato";
			}
		}


		private void qrReader_OnCodeDecoded(object sender, EventArgs e)
		{
			string myCode = qrReader.Code;
			if (!string.IsNullOrEmpty(myCode))
			{
				Guid uniqueCode;
				try
				{
					lblDescrizione.Text = string.Empty;
					uniqueCode = new Guid(myCode);
				}
				catch
				{
					lblDescrizione.Text = "Cartellino non valido"; //Se il codice è un codice ad cazzum, non un GUID, è ovviamente un QR Code sbagliato
					return;
				}
				SostanzeManager manager = new SostanzeManager(DatabaseContext);
				NewSostanze sostanza = manager.GetSubstanceFromQRCode(uniqueCode);
				if (sostanza == null)
				{
					lblDescrizione.Text = "Non è un cartellino sostanza";
				}
				else
				{
					txtElencoIngredienti.Text += sostanza.Nome + "\r\n";
					hidField.Value += sostanza.Progressivo + ";";
					lblDescrizione.Text = "Ingrediente inserito";
					btnCrea.Enabled = true;
				}
			}
		}
	}
}
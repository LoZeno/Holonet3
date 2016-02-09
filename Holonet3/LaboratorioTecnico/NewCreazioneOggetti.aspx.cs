using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using CommonBusiness.Personaggi;
using CommonBusiness.OggettiManager;
using DataAccessLayer;

namespace Holonet3.LaboratorioTecnico
{
	public partial class NewCreazioneOggetti : HolonetPage
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
					canUse = (manager.HasSkill(LoggedCharacter.NumeroPG, 13) || manager.HasSkill(LoggedCharacter.NumeroPG, 66) || manager.HasSkill(LoggedCharacter.NumeroPG, 132));
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
			lblCariche.Text =
			lblCosto.Text =
			lblDescrizione.Text =
			lblTipo.Text = string.Empty;
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
			OggettiManager manager = new OggettiManager(DatabaseContext);
			NewOggetti oggetto = manager.GetItemFromListOfComponents(progressiviIngredienti);
			ElaborazioneViews.SetActiveView(viewRisultato);
			if (oggetto != null)
			{
				lblNome.Text = oggetto.Nome;
				if (!string.IsNullOrWhiteSpace(oggetto.Descrizione))
				{
					lblDescrizione.Text = oggetto.Descrizione.Replace("\r", "<br />");
				}
				if (!string.IsNullOrWhiteSpace(oggetto.Effetto))
				{
					lblEffetto.Text = oggetto.Effetto.Replace("\r", "<br />");
				}

				lblCosto.Text = oggetto.Costo.ToString();
				lblCariche.Text = oggetto.NumeroCariche.HasValue ? oggetto.NumeroCariche.ToString() : string.Empty;
				lblDescrizione.Text = string.IsNullOrWhiteSpace(oggetto.Descrizione) ? string.Empty : oggetto.Descrizione.Replace("\r", "<br />");
				lblTipo.Text = oggetto.TipoOggetti.Descrizione;
				if (!string.IsNullOrWhiteSpace(oggetto.Immagine))
				{
					imgOggetto.Visible = true;
					imgOggetto.ImageUrl = oggetto.Immagine;
				}
				btnCrea.Enabled = false;
			}
			else
			{
				resetResults();
				ElaborazioneViews.SetActiveView(viewAttesa);
				lblDescrizione.Text = "I componenti inseriti non possono essere assemblati tra loro";
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
				OggettiManager manager = new OggettiManager(DatabaseContext);
				NewOggetti sostanza = manager.GetItemFromQRCode(uniqueCode);
				if (sostanza == null)
				{
					lblDescrizione.Text = "Non è un cartellino oggetto";
				}
				else
				{
					txtElencoIngredienti.Text += sostanza.Nome + "\r\n";
					hidField.Value += sostanza.Progressivo + ";";
					lblDescrizione.Text = "Componente inserito";
					btnCrea.Enabled = true;
				}
			}
		}
	}
}
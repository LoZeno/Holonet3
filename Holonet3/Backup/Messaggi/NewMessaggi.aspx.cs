using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using CommonBusiness.Messaggi;
using HolonetWebControls;
using CommonBusiness.Rubrica;
using CommonBusiness.TestiSalvati;
using CommonBusiness.Personaggi;
using Holonet3.Utilities;
using System.Text;

namespace Holonet3.Messaggi
{
    public partial class NewMessaggi : HolonetPage, ICryptable
    {
        private bool isInArrivo
        {
            get
            {
                object obj = ViewState["IsIncoming"];
                if (obj != null)
                {
                    return (bool)obj;
                }
                return true;
            }
            set
            {
                ViewState["IsIncoming"] = value;
            }
        }

		private long? numeroMittente
		{
			get
			{
				object obj = ViewState["MittenteVisualizzato"];
				if (obj != null)
				{
					return (long)obj;
				}
				return null;
			}
			set
			{
				ViewState["MittenteVisualizzato"] = value;
			}
		}

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
			grdMessaggi.DataBinding += new EventHandler(grdMessaggi_DataBinding);
            grdMessaggi.RowDataBound += new GridViewRowEventHandler(grdMessaggi_RowDataBound);
			ucCrypt.OnCancelOperation += new EventHandler(ucCrypt_OnCancelOperation);

			//Eventi dei bottoni:
			btnIndietro.Click += new EventHandler(btnIndietro_Click);
			btnRispondi.Click += new EventHandler(btnRispondi_Click);
			btnSalva.Click += new EventHandler(btnSalva_Click);
			btnCancella.Click += new EventHandler(btnCancella_Click);
			btnSalvaMittente.Click += new EventHandler(btnSalvaMittente_Click);
			txtDestinatari.TextChanged += new EventHandler(txtDestinatari_TextChanged);
        }
		/// <summary>
		/// Per far tornare all'editor dei messaggi quando si preme "Meglio di no" nel controllo di criptazione.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucCrypt_OnCancelOperation(object sender, EventArgs e)
		{
			PageViews.SetActiveView(createMessage);
		}
		/// <summary>
		/// Viene eseguito quando viene modificato il testo presente nel textbox dei destinatari
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void txtDestinatari_TextChanged(object sender, EventArgs e)
		{
			string[] destinparts = txtDestinatari.Text.Split(';');
			if (destinparts.Length > 0)
			{
				PersonaggiManagerNew characterManager = new PersonaggiManagerNew(DatabaseContext);
				txtDestinatari.Text = string.Empty;
				
				for (int i = 0; i < destinparts.Length; i++)
				{
					try
					{
						//Qui dentro controllo se è stato aggiunto un NUMERO nella lista
						long numPg = long.Parse(destinparts[i]);
						string nameToShow = characterManager.GetCharacterNameByNumber(numPg);
						destinparts[i] = nameToShow;
						if (!string.IsNullOrWhiteSpace(nameToShow))
						{
							hidReceivers.Value += numPg + ";";
							txtDestinatari.Text += nameToShow + "; ";
						}
					}
					catch
					{
						if (!string.IsNullOrWhiteSpace(destinparts[i]))
						{
							//long? verifyContact = characterManager.GetCharacterNumberByName(destinparts[i]);
							//if (verifyContact != null)
							//{
							//    txtDestinatari.Text += destinparts[i].Trim() + "; ";
							//}
							Personaggio verifyContact = characterManager.GetCharacterByName(destinparts[i]);
							if (verifyContact != null)
							{
								if (!hidReceivers.Value.Split(';').Contains(verifyContact.NumeroPG.ToString()))
								{
									hidReceivers.Value += verifyContact.NumeroPG + ";";
								}
								txtDestinatari.Text += verifyContact.Nome + "; ";
							}
						}
					}
				}
				//Ora controllo se sono stati ELIMINATI dei nomi, e quindi se devo toglierli dall'hiddenfield
				string[] numPgs = hidReceivers.Value.Split(';');
				List<long> contactsRemained = characterManager.GetCharacterNumbersByNames(txtDestinatari.Text.Split(';')).ToList();
				hidReceivers.Value = string.Empty;
				for (int i = 0; i < numPgs.Length; i++)
				{
					if (!string.IsNullOrWhiteSpace(numPgs[i]) && contactsRemained.Contains(long.Parse(numPgs[i])))
					{
						hidReceivers.Value += numPgs[i].Trim() + ";";
					}
				}
				
			}
		}

		void grdMessaggi_DataBinding(object sender, EventArgs e)
		{
			if (!isInArrivo)
			{
				grdMessaggi.Columns[1].Visible = false;
				grdMessaggi.Columns[2].Visible = true;
			}
			else
			{
				grdMessaggi.Columns[1].Visible = true;
				grdMessaggi.Columns[2].Visible = false;
			}
		}

		void btnSalvaMittente_Click(object sender, EventArgs e)
		{
			if (numeroMittente != null)
			{
				RubricaManager nomiManager = new RubricaManager(DatabaseContext);
				nomiManager.AddNewContact(LoggedCharacter.NumeroPG, (long)numeroMittente, lblMittente.Text);
				DatabaseContext.SaveChanges();
				statusMessage.Text = "Mittente Salvato in Rubrica";
				btnSalvaMittente.Visible = false;
			}
		}

		void btnCancella_Click(object sender, EventArgs e)
		{
			long numeroMessaggio = long.Parse(hidMessageId.Value);
			MessaggiManager messageManager = new MessaggiManager(DatabaseContext);
			bool res = false;
			if (isInArrivo)
			{
				res = messageManager.SetIncomingMessageDeleted(this.LoggedCharacter.NumeroPG, numeroMessaggio);
			}
			else
			{
				res = messageManager.SetOutgoingMessageDeleted(this.LoggedCharacter.NumeroPG, numeroMessaggio);
			}
			if (res)
			{
				DatabaseContext.SaveChanges();
				caricaMessaggi();
			}
			else
			{
				statusMessage.Text = "Errore durante la cancellazione";
			}
		}

		void btnSalva_Click(object sender, EventArgs e)
		{
			long numeroMessaggio = long.Parse(hidMessageId.Value);
			MessaggiManager messageManager = new MessaggiManager(DatabaseContext);
			Missione messaggio = messageManager.GetSingleMessage(numeroMessaggio);
			FileSalvatiManager filesManager = new FileSalvatiManager(DatabaseContext);
			bool res = false;
			if (isInArrivo)
			{
				res = filesManager.SaveIncomingMessage(this.LoggedCharacter.NumeroPG, messaggio);
			}
			else
			{
				res = filesManager.SaveOutgoingMessage(this.LoggedCharacter.NumeroPG, messaggio);
			}
			if (res)
			{
				DatabaseContext.SaveChanges();
				statusMessage.Text = "Messaggio salvato nella cartella personale";
			}
			else
			{
				statusMessage.Text = "Errore durante il salvataggio.";
			}
		}

		void btnRispondi_Click(object sender, EventArgs e)
		{
			preparaEditor();
			long messageId = long.Parse(hidMessageId.Value);
			MessaggiManager messageManager = new MessaggiManager(DatabaseContext);
			Missione messaggio = messageManager.GetSingleMessage(messageId);
			hidReceivers.Value = messaggio.Personaggio.NumeroPG.ToString();
			txtDestinatari.Text = messaggio.Personaggio.Nome + "; ";
			txtOggetto.Text = "Re: " + messaggio.Titolo;
			txtTesto.Text = "\r\n ---------- \r\n" + "Da: " + messaggio.Personaggio.Nome + "\r\nData: " + messaggio.DataCreazione + "\r\n" + messaggio.Testo.Replace("<br />", "\r\n").Replace("<br>", "\r\n");
			PageViews.SetActiveView(createMessage);
		}

		void btnIndietro_Click(object sender, EventArgs e)
		{
			caricaMessaggi();
		}

        void grdMessaggi_RowDataBound(object sender, GridViewRowEventArgs e)
        {
			if (e.Row.Cells.Count >= 6)
			{
				if ("True" == e.Row.Cells[5].Text)
				{
					e.Row.Font.Bold = false;
				}
				else
				{
					e.Row.Font.Bold = true;
				}
			}
			if (!isInArrivo)
			{
				Label labelNames = null;
				long numeroMissione;
				try
				{
					labelNames = (Label)(e.Row.Cells[2].FindControl("lblDestinatari"));
					numeroMissione = long.Parse(e.Row.Cells[0].Text);
					MessaggiManager manager = new MessaggiManager(DatabaseContext);
					foreach (string nome in manager.GetRecipients(numeroMissione))
					{
						labelNames.Text += nome + " ";
					}
				}
				catch (Exception)
				{
					if (labelNames != null)
					{
						labelNames.Text = "Errore durante recupero nomi";
					}
				}

			}
        }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//Il pezzo seguente è necessario per far funzionare jScrollPane con gli update panels
			StringBuilder str = new StringBuilder();
			str.Append(@"var myheight = $(window).height();");
			str.Append(@"myheight = (myheight * 70) / 100;");
			str.Append(@"myheight = parseInt(myheight);");
			str.Append(@"$('.scroll-pane').css('height', myheight + 'px');");
			str.Append(@"$('.scroll-pane').jScrollPane({ showArrows: true });");
			ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "testingloader", str.ToString(), true);

		}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoggedCharacter != null)
                {
                    caricaMessaggi();
                }
            }
        }

        protected void grdMessaggi_RowClicked(object sender, HolonetWebControls.GridViewRowClickedEventArgs args)
        {
            string messageId = args.Row.Cells[0].Text;
            if (!string.IsNullOrWhiteSpace(messageId))
            {
                long messageNum = long.Parse(messageId);
                caricaMessaggio(messageNum);
            }
        }

		private void caricaMessaggi()
		{
			if (isInArrivo)
			{
				caricaMessaggiInArrivo();
			}
			else
			{
				caricaMessaggiInUscita();
			}
		}

        private void caricaMessaggiInArrivo()
        {
            Personaggio currentCharacter = this.LoggedCharacter;
            MessaggiManager manager = new MessaggiManager(DatabaseContext);
            var IncomingMessages = manager.GetIncomingMessagesByCharacter(currentCharacter.NumeroPG);
            grdMessaggi.DataSource = IncomingMessages;
            grdMessaggi.DataBind();
			lblPageTitle.Text = "Posta in Arrivo";
			PageViews.SetActiveView(viewMessageList);
        }

        private void caricaMessaggiInUscita()
        {
            Personaggio currentCharacter = this.LoggedCharacter;
            MessaggiManager manager = new MessaggiManager(DatabaseContext);
            var OutgoingMessages = manager.GetOutgoingMessagesByCharacter(currentCharacter.NumeroPG);
            grdMessaggi.DataSource = OutgoingMessages;
            grdMessaggi.DataBind();
			lblPageTitle.Text = "Posta in Uscita";
			PageViews.SetActiveView(viewMessageList);
        }

        private void caricaMessaggio(long numeroMessaggio)
        {
			hidMessageId.Value = numeroMessaggio.ToString();
			statusMessage.Text = string.Empty;
            MessaggiManager messageManager = new MessaggiManager(DatabaseContext);
			Missione messaggio = messageManager.GetSingleMessage(numeroMessaggio);
            lblMittente.Text = messaggio.Personaggio.Nome;
            lblTitolo.Text = messaggio.Titolo;
            lblTesto.Text = string.IsNullOrWhiteSpace(messaggio.Testo) ? string.Empty : messaggio.Testo.Replace("\r", "<br />");
            lblData.Text = messaggio.DataCreazione.ToString();
			if (isInArrivo)
			{
				numeroMittente = messaggio.Mandante;
				RubricaManager namesManager = new RubricaManager(DatabaseContext);
				btnSalvaMittente.Visible = !namesManager.HasContact(LoggedCharacter.NumeroPG, messaggio.Mandante);
				rowDestinatari.Visible = false;
				messageManager.SetIncomingMessageRead(this.LoggedCharacter.NumeroPG, numeroMessaggio);
			}
			else
			{
				numeroMittente = null;
				btnSalvaMittente.Visible = false;
				rowDestinatari.Visible = true;
				foreach (string nome in messageManager.GetRecipients(numeroMessaggio))
				{
					lblDestinatari.Text += nome + " ";
				}
				messageManager.SetOutgoingMessageRead(this.LoggedCharacter.NumeroPG, numeroMessaggio);
			}
			DatabaseContext.SaveChanges();
			if (isInArrivo)
			{
				btnRispondi.Visible = true;
			}
			else
			{
				btnRispondi.Visible = false;
			}
			PageViews.SetActiveView(readMessage);
        }

		private void preparaEditor()
		{
			hidReceivers.Value = string.Empty;
			txtDestinatari.Text = string.Empty;
			txtOggetto.Text = string.Empty;
			txtTesto.Text = string.Empty;
			lblPageTitle.Text = "Componi Messaggio";
			RubricaManager namesManager = new RubricaManager(DatabaseContext);
			cmbNomiSalvati.DataValueField = "NumeroSalvato";
			cmbNomiSalvati.DataTextField = "NomeVisualizzato";
			cmbNomiSalvati.DataSource = namesManager.GetContactsByCharacter(this.LoggedCharacter.NumeroPG);
			cmbNomiSalvati.DataBind();
		}

        protected void lnkEditor_Click(object sender, EventArgs e)
        {
			preparaEditor();
			PageViews.SetActiveView(createMessage);
        }

        protected void lnkInArrivo_Click(object sender, EventArgs e)
        {
            isInArrivo = true;
            caricaMessaggiInArrivo();
        }

        protected void lnkInviati_Click(object sender, EventArgs e)
        {
            isInArrivo = false;
            caricaMessaggiInUscita();
        }

        protected void grdMessaggi_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMessaggi.PageIndex = e.NewPageIndex;
			caricaMessaggi();
        }

		protected void btnAggiungi_Click(object sender, EventArgs e)
		{
			if (!hidReceivers.Value.Split(';').Contains(cmbNomiSalvati.SelectedValue))
			{
				PersonaggiManagerNew characterManager = new PersonaggiManagerNew(DatabaseContext);
				hidReceivers.Value += cmbNomiSalvati.SelectedValue + ";";
				long numPg = long.Parse(cmbNomiSalvati.SelectedValue);
				txtDestinatari.Text += characterManager.GetCharacterNameByNumber(numPg) + "; ";
			}
		}

		protected void btnInvia_Click(object sender, EventArgs e)
		{
			eseguiInvio(0);
		}

		private void eseguiInvio(long criptazione)
		{
			MessaggiManager messageManager = new MessaggiManager(DatabaseContext);
			string[] receivers = hidReceivers.Value.Split(';');
			List<long> receiverIds = new List<long>();
			for (int i = 0; i < receivers.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(receivers[i]))
				{
					receiverIds.Add(long.Parse(receivers[i].Trim()));
				}
			}
			bool res = messageManager.SendMessage(this.LoggedCharacter.NumeroPG, receiverIds, txtOggetto.Text.Trim(), txtTesto.Text.Trim(), criptazione);
			if (res)
			{
				DatabaseContext.SaveChanges();
				isInArrivo = false;
				caricaMessaggi();
			}
			else
			{
				statusInvio.Text = "Errore nell'invio del messaggio, ricontrollare i campi";
				statusInvio.Visible = true;
			}
		}

		protected void btnCrypt_Click(object sender, EventArgs e)
		{
			ucCrypt.Carica();
			PageViews.SetActiveView(encryptMessage);
		}

		#region ICryptable Membri di

		public long Crypted
		{
			get
			{
				object obj = ViewState["Crypted"];
				if (obj != null)
				{
					return (long)obj;
				}
				return 0;
			}
			set
			{
				ViewState["Crypted"] = value;
			}
		}

		public void OnCrypting(long crypterLevel)
		{
			PageViews.SetActiveView(createMessage);
			eseguiInvio(crypterLevel);
		}

		public void OnDecryptSuccess(long crypterAccount)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
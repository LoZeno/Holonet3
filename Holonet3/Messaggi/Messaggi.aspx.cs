using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Data;
using HolonetWebControls;
using Holonet3.Utilities;

namespace Holonet3.Messaggi
{
    public partial class Messaggi : HolonetPage, Holonet3.Messaggi.IMessaggi, ICryptable
    {
        public Missione MessaggioVisualizzato
        {
            get
            {
                object obj = ViewState["MessaggioVisualizzato"];
                if (obj != null)
                {
                    return (Missione)obj;
                }
                return null;
            }
            set
            {
                ViewState["MessaggioVisualizzato"] = value;
                //MostraMessaggio();
            }
        }

        public bool IsInUscita
        {
            get
            {
                object obj = ViewState["IsInUscita"];
                if (obj != null)
                {
                    return (bool)obj;
                }
                return false;
            }
            set
            {
                ViewState["IsInUscita"] = value;
            }
        }

		//protected void Page_PreInit(object sender, EventArgs e)
		//{
		//    if (Session["Tema"] != null)
		//    {
		//        Page.Theme = Session["Tema"].ToString();
		//    }
		//    else
		//    {
		//        Page.Theme = "TemaBlu";
		//    }
		//}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoggedCharacter != null)
                {
                    Personaggio currentCharacter = (Personaggio)Session["Personaggio"];
                    Dictionary<long, string> elenco = new Dictionary<long, string>();
                    using (HolonetEntities context = new HolonetEntities())
                    {
                        var elencoRubrica = (from nominativi in context.Rubricas
                                             where nominativi.NumeroPG == currentCharacter.NumeroPG
                                             select nominativi);

                        foreach (var item in elencoRubrica)
                        {
                            elenco.Add(item.NumeroSalvato, item.NomeVisualizzato);
                        }
                    }
                    cmbNomiSalvati.DataValueField = "Key";
                    cmbNomiSalvati.DataTextField = "Value";
                    cmbNomiSalvati.DataSource = elenco;
                    cmbNomiSalvati.DataBind();
                }
            }
        }

        public void MostraMessaggio()
        {
            Missione messaggioDaMostrare = MessaggioVisualizzato;
            if (messaggioDaMostrare != null)
            {
                //procedere a mostrare il tutto
                panSendMessage.Visible = false;
                panMessage.Visible = true;
                panCancellato.Visible = false;
                panSalvato.Visible = false;
                lblMittente.Visible = true;
                lblMittente.Text = "Mittente: " + messaggioDaMostrare.Personaggio.Nome + " (NumeroPG: " + messaggioDaMostrare.Personaggio.NumeroPG + ")";
                lblTitolo.Text = messaggioDaMostrare.Titolo;
                lblTesto.Text = messaggioDaMostrare.Testo;
            }
        }

        public void MostraMessaggioInUscita()
        {
            Missione messaggioDaMostrare = MessaggioVisualizzato;
            if (messaggioDaMostrare != null)
            {
                panSendMessage.Visible = false;
                panMessage.Visible = true;
                panCancellato.Visible = false;
                panSalvato.Visible = false;
                lblMittente.Visible = false;
                lblTitolo.Text = messaggioDaMostrare.Titolo;
                lblTesto.Text = messaggioDaMostrare.Testo;
            }
        }

        private void caricaMessaggiInArrivo()
        {
			listaMessaggiRicevuti.refCharacter = (Personaggio)Session["Personaggio"];
            listaMessaggiRicevuti.Visible = true;
            listaMessaggiInviati.Visible = false;

            Personaggio character = (Personaggio)Session["Personaggio"];
            List<PostaInArrivo> elenco;
            using (HolonetEntities context = new HolonetEntities())
            {
                var messaggiInArrivo = (from messages in context.PostaInArrivoes
                                    where messages.NumeroPG == character.NumeroPG
                                    where messages.Cancellata == false
                                    select messages).OrderByDescending(mexs => mexs.NumeroMissione);

                foreach (var messaggio in messaggiInArrivo)
                {
                    if (!messaggio.MissioneReference.IsLoaded)
                    {
                        messaggio.MissioneReference.Load();
                        if (!messaggio.Missione.PersonaggioReference.IsLoaded)
                        {
                            messaggio.Missione.PersonaggioReference.Load();
                        }
                    }
                }
                elenco = messaggiInArrivo.ToList();
            }
            panMessage.Visible = false;
            panCancellato.Visible = false;
            panSalvato.Visible = false;
            
            //Passo l'elenco dei messaggi al controllo che creerà la lista visibile, e invoco il databind esplicito
            listaMessaggiRicevuti.Messaggi = elenco;
            listaMessaggiRicevuti.Carica();
        }

        private void CaricaMessaggiInUscita()
        {
			listaMessaggiInviati.refCharacter = (Personaggio)Session["Personaggio"];
            listaMessaggiRicevuti.Visible = false;
            listaMessaggiInviati.Visible = true;

            Personaggio character = (Personaggio)Session["Personaggio"];
            List<PostaInUscita> elenco;
            using (HolonetEntities context = new HolonetEntities())
            {
                var messaggiInUscita = (from messages in context.PostaInUscitas
                                        where messages.NumeroPG == character.NumeroPG
                                        where messages.Cancellata == false
                                        select messages).OrderByDescending(mexs => mexs.NumeroMissione);
                foreach (var messaggio in messaggiInUscita)
                {
                    if (!messaggio.MissioneReference.IsLoaded)
                    {
                        messaggio.MissioneReference.Load();
                    }
                }
                elenco = messaggiInUscita.ToList();
            }
            panMessage.Visible = false;
            panCancellato.Visible = false;
            panSalvato.Visible = false;

            //Passo l'elenco dei messaggi al controllo che creerà la lista visibile, e invoco il databind esplicito
            listaMessaggiInviati.Messaggi = elenco;
            listaMessaggiInviati.Carica();
        }

        protected void lnkInArrivo_Click(object sender, EventArgs e)
        {
            caricaMessaggiInArrivo();
        }

        protected void lnkInviati_Click(object sender, EventArgs e)
        {
            CaricaMessaggiInUscita();
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            //copiare in MessaggioSalvato
            using (HolonetEntities context = new HolonetEntities())
            {
                MessaggioSalvato toSave = new MessaggioSalvato();
                toSave.Contenuto = MessaggioVisualizzato.Testo;
                toSave.Hacking = MessaggioVisualizzato.LivelloHacking;
                toSave.NumeroPG = ((Personaggio)Session["Personaggio"]).NumeroPG;
                toSave.Provenienza = "Messaggi";
                toSave.Titolo = MessaggioVisualizzato.Titolo;

                lblTitoloSalvato.Text = toSave.Titolo;

                context.AddToMessaggioSalvatoes(toSave);
                context.SaveChanges();
            }

            panCancellato.Visible = false;
            panMessage.Visible = false;
            panSalvato.Visible = true;
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            //eliminare il messaggio e ricaricare l'elenco
            string titoloCancellato = MessaggioVisualizzato.Titolo;
            using (HolonetEntities context = new HolonetEntities())
            {
                long numeroPG = ((Personaggio)Session["Personaggio"]).NumeroPG;
                if (IsInUscita)
                {
                    var messaggioDaCancellare = (from message in context.PostaInUscitas
                                                 where message.NumeroPG == numeroPG
                                                 where message.NumeroMissione == MessaggioVisualizzato.NumeroMissione
                                                 select message);
                    if (messaggioDaCancellare.Count() > 0)
                    {
                        messaggioDaCancellare.First().Cancellata = true;
                    }
                }
                else
                {
                    var messaggioDaCancellare = (from message in context.PostaInArrivoes
                                                 where message.NumeroPG == numeroPG
                                                 where message.NumeroMissione == MessaggioVisualizzato.NumeroMissione
                                                 select message);
                    if (messaggioDaCancellare.Count() > 0)
                    {
                        messaggioDaCancellare.First().Cancellata = true;
                    }
                }
                context.SaveChanges();
            }

            panCancellato.Visible = true;
            panMessage.Visible = false;
            panSalvato.Visible = false;

            listaMessaggiRicevuti.Visible = false;
            listaMessaggiInviati.Visible = false;

            lblTitoloCancellato.Text = titoloCancellato;
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            string elencoDestinatari = txtDestinatari.Text.Trim();
            string[] arrayDestinatari = elencoDestinatari.Split(',');

            List<long> numeriDestinatari = new List<long>();
            foreach (string item in arrayDestinatari)
            {
                try
                {
                    long num = long.Parse(item);
                    numeriDestinatari.Add(num);
                }
                catch
                {
                }
            }
            Personaggio currentCharacter = (Personaggio)Session["Personaggio"];
            using (HolonetEntities context = new HolonetEntities())
            {
                long lastMission = (from missioni in context.Missiones
                                    select missioni.NumeroMissione).Max();

                Missione newMessage = new Missione();
                newMessage.NumeroMissione = lastMission + 1;
                newMessage.Attiva = 1;
                newMessage.Mandante = currentCharacter.NumeroPG;
                newMessage.Testo = txtTesto.Text.Replace("\n", "<br />");
                newMessage.Titolo = txtOggetto.Text.Trim();

				//Livello di crittazione
				newMessage.LivelloCrittazione = Crypted;

                //Per il mittente
                newMessage.PostaInUscitas.Add(new PostaInUscita() { NumeroPG = currentCharacter.NumeroPG, Cancellata = false, Letta = false });
                //per i destinatari
                foreach (long dest in numeriDestinatari)
                {
                    newMessage.PostaInArrivoes.Add(new PostaInArrivo() { NumeroPG = dest, Cancellata = false, Letta = false });
                }
                context.AddToMissiones(newMessage);
                context.SaveChanges();
            }
            panSendMessage.Visible = false;
            CaricaMessaggiInUscita();
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            txtDestinatari.Text += cmbNomiSalvati.SelectedValue + ",";
        }

        protected void lnkEditor_Click(object sender, EventArgs e)
        {
            panMessage.Visible = false;
            listaMessaggiInviati.Visible = false;
            listaMessaggiRicevuti.Visible = false;
            panSendMessage.Visible = true;
            txtDestinatari.Text = string.Empty;
            txtOggetto.Text = string.Empty;
            txtTesto.Text = string.Empty;
			ucCriptazione.Carica();
        }

		#region ICryptable Members

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
			Crypted = crypterLevel;
		}

		public void OnDecryptSuccess(long crypterAccount)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
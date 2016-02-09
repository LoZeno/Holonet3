using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;
using CommonBusiness.Personaggi;

namespace CommonBusiness.Messaggi
{
    public class MessaggiManager : BaseDataManager
    {
        public MessaggiManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public int Count()
		{
			return (from oggetti in context.Missiones
					select oggetti).Count();
		}

		public IList<Missione> GetLatestIncomingMessageByCharacter(long numeroPg)
		{
			DateTime dateToCompare = DateTime.Now;
			var elencoNumeri = (from received in context.PostaInArrivoes
									where received.NumeroPG == numeroPg && received.Missione.DataCreazione <= dateToCompare
									orderby received.NumeroMissione descending
									select received.Missione.NumeroMissione).Take(50).ToList();

			var lista = (from messages in context.Missiones.Include("Personaggio")
						 where elencoNumeri.Contains(messages.NumeroMissione)
						 orderby messages.NumeroMissione descending
						 select messages);

			return lista.ToList();
		}

        public IEnumerable GetIncomingMessagesByCharacter(long numeroPg)
        {
			DateTime dateToCompare = DateTime.Now;
            var messaggiInArrivo = from Messages in context.PostaInArrivoes
                                   where Messages.NumeroPG == numeroPg && Messages.Cancellata == false && Messages.Missione.DataCreazione <= dateToCompare
                                   orderby Messages.Missione.DataCreazione descending
                                   select new {Numero = Messages.NumeroMissione, Mittente = Messages.Missione.Personaggio.Nome, Oggetto = Messages.Missione.Titolo, Letta = Messages.Letta, Data = Messages.Missione.DataCreazione };
            return messaggiInArrivo;
        }

        public IEnumerable GetOutgoingMessagesByCharacter(long numeroPg)
        {
			DateTime dateToCompare = DateTime.Now;
            var messaggiInUscita = from Messages in context.PostaInUscitas
                                   where Messages.NumeroPG == numeroPg && Messages.Cancellata == false && Messages.Missione.DataCreazione <= dateToCompare
                                   orderby Messages.Missione.DataCreazione descending
                                   select new {Numero = Messages.NumeroMissione, Mittente = Messages.Missione.Personaggio.Nome, Oggetto = Messages.Missione.Titolo, Letta = Messages.Letta, Data = Messages.Missione.DataCreazione };
            return messaggiInUscita;
        }

		public IList<Missione> GetPagedMessagesList(int startPage, int pageSize)
		{
			var messaggi = (from items in context.Missiones.Include("Personaggio")
								 orderby items.NumeroMissione descending
								 select items).Skip(startPage).Take(pageSize);
			return messaggi.ToList();
		}

		public IEnumerable<string> GetRecipients(long numeroMissione)
		{
			return from Messages in context.PostaInArrivoes
						where Messages.NumeroMissione == numeroMissione
						orderby Messages.NumeroPG
						select Messages.Personaggio.Nome;
		}

        public Missione GetSingleMessage(long numeroMissione)
        {
            var singleMessage = from messages in context.Missiones
                                where messages.NumeroMissione == numeroMissione
                                select messages;
            return singleMessage.FirstOrDefault();
        }

		public bool SetIncomingMessageRead(long numeroPg, long numeroMissione)
		{
			var messageInbox = (from messages in context.PostaInArrivoes
								where messages.NumeroPG == numeroPg && messages.NumeroMissione == numeroMissione
								select messages).FirstOrDefault();
			if (messageInbox != null)
			{
				messageInbox.Letta = true;
				return true;
			}
			return false;
		}

		public bool SetOutgoingMessageRead(long numeroPg, long numeroMissione)
		{
			var messageOutbox = (from messages in context.PostaInUscitas
								where messages.NumeroPG == numeroPg && messages.NumeroMissione == numeroMissione
								select messages).FirstOrDefault();
			if (messageOutbox != null)
			{
				messageOutbox.Letta = true;
				return true;
			}
			return false;
		}

		public bool SetIncomingMessageDeleted(long numeroPg, long numeroMissione)
		{
			var messageToDelete = (from messages in context.PostaInArrivoes
								   where messages.NumeroPG == numeroPg && messages.NumeroMissione == numeroMissione
								   select messages).FirstOrDefault();
			if (messageToDelete != null)
			{
				messageToDelete.Cancellata = true;
				return true;
			}
			return false;
		}

		public bool SetOutgoingMessageDeleted(long numeroPg, long numeroMissione)
		{
			var messageToDelete = (from messages in context.PostaInUscitas
								   where messages.NumeroPG == numeroPg && messages.NumeroMissione == numeroMissione
								   select messages).FirstOrDefault();
			if (messageToDelete != null)
			{
				messageToDelete.Cancellata = true;
				return true;
			}
			return false;
		}

		public bool SendMessage(long mittente, List<long> destinatari, string oggetto, string messaggio, long crypt)
		{
			return SendMessage(mittente, destinatari, oggetto, messaggio, crypt, DateTime.Now);
			//try
			//{
			//    Missione messageToSend = new Missione();
			//    messageToSend.DataCreazione = DateTime.Now;
			//    messageToSend.LivelloCrittazione = crypt;
			//    messageToSend.Titolo = oggetto;
			//    messageToSend.Testo = messaggio.Replace("\n", "<br />");
			//    messageToSend.Mandante = mittente;
			//    PostaInUscita outMail = new PostaInUscita();
			//    outMail.NumeroPG = mittente;
			//    outMail.Letta = false;
			//    outMail.Cancellata = false;
			//    messageToSend.PostaInUscitas.Add(outMail);

			//    foreach (long numPg in destinatari)
			//    {
			//        PostaInArrivo inMail = new PostaInArrivo();
			//        inMail.NumeroPG = numPg;
			//        inMail.Letta = false;
			//        inMail.Cancellata = false;
			//        messageToSend.PostaInArrivoes.Add(inMail);
			//    }
			//    context.AddToMissiones(messageToSend);
			//    return true;
			//}
			//catch
			//{
			//    return false;
			//}
		}

		public bool SendMessage(long mittente, List<long> destinatari, string oggetto, string messaggio, long crypt, DateTime dataInvio)
		{
			try
			{
				Missione messageToSend = new Missione();
				messageToSend.LivelloCrittazione = crypt;
				messageToSend.Titolo = oggetto;
				messageToSend.Testo = messaggio.Replace("\r\n", "<br />").Replace("\n", "<br />");
				messageToSend.Mandante = mittente;
				messageToSend.DataCreazione = dataInvio;
				PostaInUscita outMail = new PostaInUscita();
				outMail.NumeroPG = mittente;
				outMail.Letta = false;
				outMail.Cancellata = false;
				messageToSend.PostaInUscitas.Add(outMail);

				foreach (long numPg in destinatari)
				{
					PostaInArrivo inMail = new PostaInArrivo();
					inMail.NumeroPG = numPg;
					inMail.Letta = false;
					inMail.Cancellata = false;
					messageToSend.PostaInArrivoes.Add(inMail);
				}
				context.AddToMissiones(messageToSend);
				return true;
			}
			catch
			{
				return false;
			}
		}
    }
}

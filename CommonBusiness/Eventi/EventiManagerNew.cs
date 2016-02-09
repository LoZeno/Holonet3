using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using CommonBusiness.Personaggi;
using System.Collections;

namespace CommonBusiness.Eventi
{
	public class EventiManagerNew : BaseDataManager
	{
		public EventiManagerNew(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public string GetEventName(long eventNumber)
		{
			return (from evento in context.Eventoes
					where evento.CdEvento == eventNumber
					select evento.TitoloEvento).FirstOrDefault();
		}

        /// <summary>
        /// Restituisce l'elenco di eventi (con Codice, Titolo, Data inizio, Costo e Descrizione) paginata secondo i parametri passati
        /// </summary>
        /// <param name="startPage">Numero del record di inizio paginazione</param>
        /// <param name="pageSize">Dimensione della paginazione</param>
        /// <returns></returns>
        public IList<Evento> GetPagedEventsList(int startPage, int pageSize)
        {
            var events = (from elencoEventi in context.Eventoes
                            orderby elencoEventi.DataEvento descending
                            select elencoEventi).Skip(startPage).Take(pageSize);
            return events.ToList();
        }

        public int Count()
        {
            return (from eventi in context.Eventoes
                   select eventi.CdEvento).Count();
        }

		public EventoGiorni GetSingleDay(long eventNumber, DateTime giorno)
		{
			return (from giorni in context.EventoGiornis
					where giorni.CdEvento == eventNumber
					&& giorni.DataGiorno == giorno
					select giorni).FirstOrDefault();
		}

		public bool AddDayToEvent(long eventNumber, DateTime giorno)
		{
			try
			{
				Evento myEvent = GetEventFromNumber(eventNumber);
				EventoGiorni newDay = new EventoGiorni();
				newDay.DataGiorno = giorno;
				newDay.OraInGioco = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 0, 0);
				newDay.OraFuoriGioco = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 2, 0, 0);
				myEvent.EventoGiornis.Add(newDay);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool DeleteSingleDay(long eventNumber, DateTime giorno)
		{
			try
			{

				EventoGiorni myDay = GetSingleDay(eventNumber, giorno);				
				context.EventoGiornis.DeleteObject(myDay);
				var subscriptions = from iscrizioni in context.EventoGiorniPersonaggios
									where iscrizioni.CdEvento == eventNumber
									&& iscrizioni.DataGiorno == giorno
									select iscrizioni;
				foreach (var item in subscriptions)
				{
					context.EventoGiorniPersonaggios.DeleteObject(item);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveSingleDay(long eventNumber, DateTime giorno, long? punti, DateTime inGioco, DateTime fuoriGioco, float? costo)
		{
			try
			{
				EventoGiorni myDay = GetSingleDay(eventNumber, giorno);
				myDay.PuntiAssegnati = punti;
				myDay.OraInGioco = inGioco;
				myDay.CostoGiorno = costo;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Evento GetEventFromNumber(long eventNumber)
		{
			return (from evento in context.Eventoes
					where evento.CdEvento == eventNumber
					select evento).FirstOrDefault();
		}

		public IEnumerable<Personaggio> GetPlayingCharacters(long eventNumber)
		{
			return (from eventi in context.EventoGiorniPersonaggios
							  where eventi.CdEvento == eventNumber
							  orderby eventi.Personaggio.NumeroPG
							  select eventi.Personaggio).Distinct();
		}

		public bool SubscribePlayerCharacter(long eventNumber, List<DateTime> giorni, long numeroPG)
		{
			try
			{
				var iscrizioni = from subscriptions in context.EventoGiorniPersonaggios
								 where subscriptions.NumeroPg == numeroPG
								 && subscriptions.CdEvento == eventNumber
								 orderby subscriptions.DataGiorno ascending
								 select subscriptions;
				//Prima cosa elimino le date già presenti
				foreach (var iscrizione in iscrizioni)
				{
					context.EventoGiorniPersonaggios.DeleteObject(iscrizione);
				}
				//Ora rifaccio le iscrizioni

				Personaggio character = (from personaggi in context.Personaggios
										 where personaggi.NumeroPG == numeroPG
										 select personaggi).FirstOrDefault();
				foreach (DateTime data in giorni)
				{
					EventoGiorniPersonaggio iscrizione = new EventoGiorniPersonaggio();
					iscrizione.CdEvento = eventNumber;
					iscrizione.DataGiorno = data;
					iscrizione.NumeroPg = numeroPG;
					iscrizione.Pagato = false;
					iscrizione.Partecipato = false;
					character.EventoGiorniPersonaggios.Add(iscrizione);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

        public IList<Partecipazione> GetPartecipation(long cdEvento)
        {
            Evento evento = GetEventFromNumber(cdEvento);

            var query = (from iscrizioni in context.EventoGiorniPersonaggios
                         where iscrizioni.CdEvento == cdEvento
                         group iscrizioni by iscrizioni.NumeroPg into element
                         select new { NumeroPG = element.Key, DatiGiorni = element });
            List<Partecipazione> partecipazioni = new List<Partecipazione>();
            foreach (var item in query)
            {
                Partecipazione partecipation = new Partecipazione();
                partecipation.CdEvento = cdEvento;
                partecipation.NumeroPG = item.NumeroPG;
                foreach (var giorno in item.DatiGiorni)
                {
                    partecipation.NumeroGiorni++;
                    partecipation.Giocatore = giorno.NomeGiocatore;
                    partecipation.Personaggio = giorno.Personaggio.Nome;
                    partecipation.Prezzo += giorno.EventoGiorni.CostoGiorno.HasValue ? giorno.EventoGiorni.CostoGiorno.Value : 0;
                    partecipation.Pagato = partecipation.Pagato && giorno.Pagato;
                    partecipation.Partecipato = partecipation.Partecipato && giorno.Partecipato;
                    partecipation.PX += giorno.EventoGiorni.PuntiAssegnati.HasValue ? giorno.EventoGiorni.PuntiAssegnati.Value : 0;
                }
                if (partecipation.NumeroGiorni == evento.EventoGiornis.Count)
                {
                    partecipation.Prezzo = (float)evento.Costo;
                    partecipation.PX = evento.PuntiAssegnati;
                }
				if (!partecipation.Partecipato) //mostro solo quelli a cui NON sono già stati assegnati i PX.
				{
					partecipazioni.Add(partecipation);
				}
            }
            return partecipazioni;
        }

        public bool UpdateCharacterSubscriptionsAndPX(long numeroPG, long cdEvento, bool pagato, DateTime dataPagamento, bool partecipato, long PX)
        {
            try
            {
                var query = from iscrizioni in context.EventoGiorniPersonaggios
                            where iscrizioni.NumeroPg == numeroPG
                            && iscrizioni.CdEvento == cdEvento
                            select iscrizioni;
                bool assegnaPX = false;
                foreach (var iscrizione in query)
                {
                    if (!iscrizione.Pagato && pagato)
                    {
                        iscrizione.DataPagamento = dataPagamento;
                    }
                    if (iscrizione.Pagato && !pagato)
                    {
                        iscrizione.DataPagamento = null;
                    }
                    iscrizione.Pagato = pagato;
                    if (!iscrizione.Partecipato && partecipato)
                    {
                        iscrizione.Partecipato = partecipato;
                        assegnaPX = true;
                    }
                }
                if (assegnaPX)
                {
                    Personaggio character = (from personaggi in context.Personaggios
                                             where personaggi.NumeroPG == numeroPG
                                             select personaggi).FirstOrDefault();
                    if (assegnaPX)
                    {
                        character.Punti += PX;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CloseEvent(long cdEvento, float incasso)
        {
            try
            {
                Evento myEvent = (from eventi in context.Eventoes
                                  where eventi.CdEvento == cdEvento
                                  select eventi).FirstOrDefault();
                myEvent.Incasso = incasso;
                myEvent.Chiuso = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertNewEventComplete(string title, string description, double costo, int totalPx, List<DateTime> days, DateTime InGame, DateTime OutGame, DateTime standardInGame, DateTime standardOutGame)
        {
            try
            {
                Evento res = new Evento();
                res.Costo = (float)costo;
                res.DataEvento = days[0].Date;
                res.Descrizione = description;
                res.PuntiAssegnati = totalPx;
                res.TitoloEvento = title;
                for (int i = 0; i < days.Count; i++)
                {
                    EventoGiorni singleDay = new EventoGiorni();
                    singleDay.DataGiorno = days[i];
                    if (i == 0)
                    {
                        singleDay.OraInGioco = InGame;
                    }
                    else
                    {
                        singleDay.OraInGioco = standardInGame;
                    }
                    if (i == days.Count - 1)
                    {
                        singleDay.OraFuoriGioco = OutGame;
                    }
                    else
                    {
                        singleDay.OraFuoriGioco = standardOutGame;
                    }
                    res.EventoGiornis.Add(singleDay);
                }
                context.Eventoes.AddObject(res);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList GetItemsToPrint(long cdEvento)
        {
            var listOfItems = (from stampe in context.EventoElementis
                               where stampe.CdEvento == cdEvento
                               orderby stampe.NewElementi.Progressivo
                               select new { stampe.NewElementi.Progressivo, stampe.NewElementi.Nome, stampe.NewElementi.Descrizione, stampe.NewElementi.Effetto, Copie = stampe.NumeroCopie });

            return listOfItems.ToList();
        }

		public IList GetDisksToPrint(long cdEvento)
		{
			var listOfDisks = (from stampe in context.EventoHolodischis
							   where stampe.CdEvento == cdEvento
							   orderby stampe.HoloDisk.Progressivo
							   select new { stampe.HoloDisk.Progressivo, stampe.HoloDisk.Contenuto, Files = stampe.HoloDisk.HoloDiskFiles.Count, Copie = stampe.NumeroCopie });
			return listOfDisks.ToList();
		}

		public long GetCopiesOfDiskToPrint(long codEvento, long progressivo)
		{
			var getNumber = (from stampe in context.EventoHolodischis
							 where stampe.CdEvento == codEvento
							 && stampe.ProgressivoDisco == progressivo
							 select stampe.NumeroCopie);
			if (getNumber.Count() == 1)
				return getNumber.First().Value;
			else
				return 0;
		}

		public long GetCopiesOfItemsToPrint(long codevento, long progressivo)
		{
			var getNumber = (from stampe in context.EventoElementis
							 where stampe.CdEvento == codevento
							 && stampe.ProgressivoElemento == progressivo
							 select stampe.NumeroCopie);
			if (getNumber.Count() == 1)
				return getNumber.First().Value;
			else
				return 0;
		}

		public bool UpdateHolodiskCopiesToPrint(long cdEvento, long progressivo, int copie)
		{
			bool res = false;
			try
			{
				var diskToPrint = from stampe in context.EventoHolodischis
								  where stampe.CdEvento == cdEvento
								  && stampe.ProgressivoDisco == progressivo
								  select stampe;
				if (copie > 0)
				{
					if (diskToPrint.Count() == 0)
					{
						EventoHolodischi newDiskToPrint = new EventoHolodischi();
						newDiskToPrint.CdEvento = cdEvento;
						newDiskToPrint.ProgressivoDisco = progressivo;
						newDiskToPrint.NumeroCopie = copie;
						context.EventoHolodischis.AddObject(newDiskToPrint);
					}
					else
					{
						var myDisk = diskToPrint.First();
						myDisk.NumeroCopie = copie;
					}
				}
				else
				{
					if (diskToPrint.Count() > 0)
					{
						var myDisk = diskToPrint.First();
						context.EventoHolodischis.DeleteObject(myDisk);
					}
				}
				res = true;
			}
			catch
			{
				res = false;
			}

			return res;
		}

		public bool UpdateElementsCopiesToPrint(long cdEvento, long progressivo, int copie)
		{
			bool res = false;
			try
			{
				var itemsToPrint = from stampe in context.EventoElementis
								   where stampe.CdEvento == cdEvento
								   && stampe.ProgressivoElemento == progressivo
								   select stampe;
				if (copie > 0)
				{
					if (itemsToPrint.Count() == 0)
					{
						EventoElementi newElementToPrint = new EventoElementi();
						newElementToPrint.CdEvento = cdEvento;
						newElementToPrint.ProgressivoElemento = progressivo;
						newElementToPrint.NumeroCopie = copie;
						context.EventoElementis.AddObject(newElementToPrint);
					}
					else
					{
						var myElement = itemsToPrint.First();
						myElement.NumeroCopie = copie;
					}
				}
				else
				{
					if (itemsToPrint.Count() > 0)
					{
						var myElement = itemsToPrint.First();
						context.EventoElementis.DeleteObject(myElement);
					}
				}
				res = true;
			}
			catch
			{
				res = false;
			}
			return res;
		}

		public IQueryable<EventoElementi> GetPrintableElements(long cdEvento)
		{
			return from stampe in context.EventoElementis
				   where stampe.CdEvento == cdEvento
				   orderby stampe.NewElementi.Nome
				   select stampe;
		}

		public IList<NewOggetti> GetPrintableItems(long cdEvento)
		{
			var printableElements = GetPrintableElements(cdEvento);
			var printableItems = printableElements.Where(p => p.NewElementi is NewOggetti);
			List<NewOggetti> returnList = new List<NewOggetti>();
			foreach (var itemToPrint in printableItems)
			{
				for (int i = 0; i < itemToPrint.NumeroCopie; i++)
				{
					returnList.Add((NewOggetti)itemToPrint.NewElementi);
				}
			}
			return returnList;
		}

		public IList<NewSostanze> GetPrintableSubstances(long cdEvento)
		{
			var printableElements = GetPrintableElements(cdEvento);
			var printableItems = printableElements.Where(p => p.NewElementi is NewSostanze);
			List<NewSostanze> returnList = new List<NewSostanze>();
			foreach (var itemToPrint in printableItems)
			{
				if (((NewSostanze)itemToPrint.NewElementi).Tipo != 0)
				{
					for (int i = 0; i < itemToPrint.NumeroCopie; i++)
					{
						returnList.Add((NewSostanze)itemToPrint.NewElementi);
					}
				}
			}
			return returnList;
		}

		public IList<NewSostanze> GetPrintableIngredients(long cdEvento)
		{
			var printableElements = GetPrintableElements(cdEvento);
			var printableItems = printableElements.Where(p => p.NewElementi is NewSostanze);
			List<NewSostanze> returnList = new List<NewSostanze>();
			foreach (var itemToPrint in printableItems)
			{
				if (((NewSostanze)itemToPrint.NewElementi).Tipo == 0)
				{
					for (int i = 0; i < itemToPrint.NumeroCopie; i++)
					{
						returnList.Add((NewSostanze)itemToPrint.NewElementi);
					}
				}
			}
			return returnList;
		}

		public IList<HoloDisk> GetPrintableHolodisks(long cdEvento)
		{
			var printableElements = from stampe in context.EventoHolodischis
									where stampe.CdEvento == cdEvento
									orderby stampe.HoloDisk.Contenuto
									select stampe;
			List<HoloDisk> returnList = new List<HoloDisk>();
			foreach (var itemToPrint in printableElements)
			{
				for (int i = 0; i < itemToPrint.NumeroCopie; i++)
				{
					returnList.Add(itemToPrint.HoloDisk);
				}
			}
			return returnList;
		}
	}
}

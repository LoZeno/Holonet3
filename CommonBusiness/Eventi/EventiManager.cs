using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Collections;

namespace CommonBusiness.Eventi
{
    /// <summary>
    /// Classe per la gestione degli Eventi dei Live
    /// </summary>
    public class EventiManager
    {
        private string _connectionString;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="ConnectionString">Stringa di connessione al database (per Entity Framework)</param>
        public EventiManager(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

		public int Count()
		{
			int ret = 0;
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				ret = (from eventi in context.Eventoes
							  select eventi.CdEvento).Count();
			}
			return ret;
		}

        /// <summary>
        /// Restituisce l'elenco di eventi (con Codice, Titolo, Data inizio, Costo e Descrizione) paginata secondo i parametri passati
        /// </summary>
        /// <param name="startPage">Numero del record di inizio paginazione</param>
        /// <param name="pageSize">Dimensione della paginazione</param>
        /// <returns>Numero (Codice Evento), Titolo, Data, Costo, Descrizione</returns>
        public IList GetPagedEventsList_reduced(int startPage, int pageSize)
        {
            using (HolonetEntities context = new HolonetEntities(_connectionString))
            {
                var events = (from elencoEventi in context.Eventoes
                              orderby elencoEventi.DataEvento descending
                              select new { Numero = elencoEventi.CdEvento, Titolo = elencoEventi.TitoloEvento, Data = elencoEventi.DataEvento, Costo = elencoEventi.Costo, Descrizione = elencoEventi.Descrizione }).Skip(startPage).Take(pageSize);
                return events.ToList();
            }
        }
		/// <summary>
		/// Restituisce l'elenco di eventi (con Codice, Titolo, Data inizio, Costo e Descrizione) paginata secondo i parametri passati
		/// </summary>
		/// <param name="startPage">Numero del record di inizio paginazione</param>
		/// <param name="pageSize">Dimensione della paginazione</param>
		/// <returns></returns>
		public IList<Evento> GetPagedEventsList(int startPage, int pageSize)
		{
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				var events = (from elencoEventi in context.Eventoes
							  orderby elencoEventi.DataEvento descending
							  select elencoEventi).Skip(startPage).Take(pageSize);
				return events.ToList();
			}
		}
        /// <summary>
        /// Restituisce l'elenco dei giorni di live per l'evento selezionato
        /// </summary>
        /// <param name="eventCode">Codice dell'Evento</param>
        /// <returns>IEnumerable di oggetti EventoGiorni</returns>
        public IList<EventoGiorni> GetDaysList(long eventCode)
        {
            using (HolonetEntities context = new HolonetEntities(_connectionString))
            {
                var giorniEvento = (from elencoGiorni in context.EventoGiornis
                                    where elencoGiorni.CdEvento == eventCode
                                    orderby elencoGiorni.DataGiorno ascending
                                    select elencoGiorni);
                return giorniEvento.ToList();
            }
        }

		public IList GetPlayingCharactersForDay(long eventCode, DateTime day)
		{
			using (HolonetEntities context = new HolonetEntities(_connectionString))
            {
				var iscritti = from elencoGiorniPersonaggi in context.EventoGiorniPersonaggios
							   where elencoGiorniPersonaggi.CdEvento == eventCode
							   && elencoGiorniPersonaggi.DataGiorno == day
							   select new { CdEvento = elencoGiorniPersonaggi.CdEvento, DataPagamento = elencoGiorniPersonaggi.DataPagamento, NumeroPg = elencoGiorniPersonaggi.Personaggio.NumeroPG, NomePg = elencoGiorniPersonaggi.Personaggio.Nome, NumeroSW = elencoGiorniPersonaggi.Personaggio.NumeroSW, Giocatore = elencoGiorniPersonaggi.Personaggio.Giocatore.Cognome + " " + elencoGiorniPersonaggi.Personaggio.Giocatore.Nome, Pagato = elencoGiorniPersonaggi.Pagato, Partecipato = elencoGiorniPersonaggi.Partecipato };
				return iscritti.ToList();

			}
		}

        public IList GetPlayingCharacters(long eventCode, List<DateTime> days)
        {
            using (HolonetEntities context = new HolonetEntities(_connectionString))
            {
				var personaggiIscritti = (from elencoGiorniPersonaggi in context.EventoGiorniPersonaggios
										  where elencoGiorniPersonaggi.CdEvento == eventCode
										  //&& days.Contains(elencoGiorniPersonaggi.DataGiorno)
										  group elencoGiorniPersonaggi by elencoGiorniPersonaggi.NumeroPg into iscrizioni
										  join personaggi in context.Personaggios on iscrizioni.Key equals personaggi.NumeroPG
										  select new { NumeroPg = iscrizioni.Key, Nome = personaggi.Nome, NumeroSW = personaggi.NumeroSW, Giocatore = personaggi.Giocatore.Cognome + " " + personaggi.Giocatore.Nome, Giorni = iscrizioni.Count() }
										  );
                return personaggiIscritti.ToList();
            }
        }

		/// <summary>
		/// Controlla che non ci sia già un evento in quelle date
		/// </summary>
		/// <param name="dateToCheck">Date da controllare <remarks>(assicurarsi che non ci sia la componente TIME)</remarks></param>
		/// <returns>true se almeno una data è occupata, false altrimenti</returns>
		public bool DatesAlreadyInUse(List<DateTime> datesToCheck)
		{
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				var dateOccupate = (from elencoGiorni in context.EventoGiornis
									where datesToCheck.Contains(elencoGiorni.DataGiorno)
									select elencoGiorni);
				if (dateOccupate.Count() > 0)
				{
					return true;
				}
			}
			return false;
		}

		public Evento InsertNewEventComplete(string title, string description, int totalPx, List<DateTime> days, DateTime InGame, DateTime OutGame, DateTime standardInGame, DateTime standardOutGame)
		{
			Evento res = null;
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				res = new Evento();
				res.Costo = totalPx;
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
				context.SaveChanges();
			}
			return res;
		}
    }
}

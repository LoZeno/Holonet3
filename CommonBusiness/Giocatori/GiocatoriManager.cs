using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Data.Objects.SqlClient;

namespace CommonBusiness.Giocatori
{
    public class GiocatoriManager : BaseDataManager
    {
        public GiocatoriManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public List<Giocatore> GetAllPlayers()
		{
			return (from giocatori in context.Giocatores
					orderby giocatori.Cognome
					select giocatori).ToList();
		}

        public int Count()
        {
            return (from giocatori in context.Giocatores
                    select giocatori).Count();
        }

        public List<Giocatore> GetPlayerByName(string name)
        {
            name = name.Trim();
            return (from giocatori in context.Giocatores
                    where giocatori.Nome.ToLower().Contains(name.ToLower())
                    || giocatori.Cognome.ToLower().Contains(name.ToLower())
                    select giocatori).ToList<Giocatore>();
        }

        public List<Giocatore> GetPagedPlayers(int startPage, int pageSize)
        {
            var elencoGiocatori = (from players in context.Giocatores
                                 orderby players.Cognome ascending
                                 select players).Skip(startPage).Take(pageSize);
            return elencoGiocatori.ToList();
        }

        public Giocatore GetPlayerFromNumberSW(long numeroSW)
        {
            return (from giocatori in context.Giocatores
                    where giocatori.NumeroSW == numeroSW
                    select giocatori).FirstOrDefault();
        }

        public bool SaveNewPlayer(string cognome, string nome, DateTime dataNascita, string indirizzo, string citta, string provincia, string cap, string telefono, DateTime dataIscrizione, string sesso, string tipoGiocatore, string email, string password)
        {
            try
            {
                Giocatore giocatore = new Giocatore();
                giocatore.CAP = cap;
                giocatore.Citta = citta;
                giocatore.Cognome = cognome;
                giocatore.DataIscrizione = dataIscrizione;
                giocatore.DataNascita = dataNascita;
                giocatore.Email = email;
                giocatore.Indirizzo = indirizzo;
                giocatore.Nome = nome;
                giocatore.Password = password;
                giocatore.Provincia = provincia;
                giocatore.Sesso = sesso;
                giocatore.Telefono = telefono;
                giocatore.TipoGiocatore = tipoGiocatore;
                context.AddToGiocatores(giocatore);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SavePlayer(long? numeroSW, string cognome, string nome, DateTime dataNascita, string indirizzo, string citta, string provincia, string cap, string telefono, DateTime dataIscrizione, string sesso, string tipoGiocatore, string email, string password)
        {
            try
            {
                if (!numeroSW.HasValue)
                {
                    return SaveNewPlayer(cognome, nome, dataNascita, indirizzo, citta, provincia, cap, telefono, dataIscrizione, sesso, tipoGiocatore, email, password);
                }
                Giocatore giocatore = GetPlayerFromNumberSW(numeroSW.Value);
                giocatore.CAP = cap;
                giocatore.Citta = citta;
                giocatore.Cognome = cognome;
                giocatore.DataIscrizione = dataIscrizione;
                giocatore.DataNascita = dataNascita;
                giocatore.Email = email;
                giocatore.Indirizzo = indirizzo;
                giocatore.Nome = nome;
                giocatore.Password = password;
                giocatore.Provincia = provincia;
                giocatore.Sesso = sesso;
                giocatore.Telefono = telefono;
                giocatore.TipoGiocatore = tipoGiocatore;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;

namespace CommonBusiness.Rete
{
	public class Account
	{
		public long NumeroPG
		{ get; set; }
		public string Nome
		{ get; set; }
		public string Titolo
		{ get; set; }
	}

	public class ReteManager : BaseDataManager
	{
		public ReteManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}
		/// <summary>
		/// Restituisce gli account dei personaggi che sono vivi E che sono stati attivi almeno nell'ultimo anno.
		/// </summary>
		/// <param name="numeroRete">Numero della rete dei cui personaggi servono gli account</param>
		/// <returns>IEnumerable di oggetti anonimi che contengono: NumeroPG, Nome, Titolo</returns>
		public IEnumerable<Account> GetAvailableAccounts(long numeroRete)
		{
			var accounts = (from people in context.Personaggios
							where people.Fazione == numeroRete
							&& people.Vivo == 1
							orderby people.Nome
							select people);
			foreach (var singleUser in accounts)
			{
				if (singleUser.Giocatore != null && singleUser.Giocatore.TipoGiocatore != "PG")
				{
					yield return new Account() { NumeroPG = singleUser.NumeroPG, Nome = singleUser.Nome, Titolo = singleUser.Titolo };
				}
				else
				{
					foreach (var iscrizione in singleUser.EventoGiorniPersonaggios)
					{
						if (iscrizione.EventoGiorni.DataGiorno >= DateTime.Today.AddYears(-1))
						{
							yield return new Account() { NumeroPG = singleUser.NumeroPG, Nome = singleUser.Nome, Titolo = singleUser.Titolo };
							break;
						}
					}
				}
			}
		}

        public Dictionary<long, string> GetNetworksForCombo()
        {
            var networks = (from reti in context.Retes
                            orderby reti.NumeroRete
                            select new {reti.NumeroRete, Descrizione = reti.NomeRete + " - " + reti.Fazione});
            Dictionary<long, string> res = new Dictionary<long, string>();
            foreach (var item in networks)
            {
                res.Add(item.NumeroRete, item.Descrizione);
            }
            return res;
        }

		/// <summary>
		/// Restituisce le reti a cui il terminale ha accesso, identificando il terminale in base all'IP della LAN
		/// </summary>
		/// <param name="IPAddress">Indirizzo IPV4 del terminale</param>
		/// <returns></returns>
		public IEnumerable<DataAccessLayer.Rete> GetNetworksForWorkstation(string IPAddress)
		{
			var reti = (from c in context.RegistroIPs
						where c.IndirizzoIP == IPAddress
						select c.Rete);
			foreach (var idRete in reti)
			{
				yield return (from rete in context.Retes
						where rete.NumeroRete == idRete
						select rete).FirstOrDefault();
			}
		}
	}
}

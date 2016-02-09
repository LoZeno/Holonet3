using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace CommonBusiness.Personaggi
{
	public class PersonaggiManager
	{
		private string _connectionString;

		public PersonaggiManager(string ConnectionString)
		{
			_connectionString = ConnectionString;
		}

		public void CheckAllGuid()
		{
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				var personaggi = from chars in context.Personaggios
								 select chars;

				foreach (var singoloPersonaggio in personaggi)
				{
					if (!singoloPersonaggio.CodicePg.HasValue)
					{
						singoloPersonaggio.CodicePg = Guid.NewGuid();
					}
				}
				context.SaveChanges();
			}
		}

		/// <summary>
		/// Restituisce l'elenco di personaggi paginato secondo i parametri passati
		/// </summary>
		/// <param name="startPage">Numero del record di inizio paginazione</param>
		/// <param name="pageSize">Dimensione della paginazione</param>
		/// <returns></returns>
		public IList<Personaggio> GetPagedCharactersList(int startPage, int pageSize)
		{
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				var characters = (from elencoPersonaggi in context.Personaggios
							 orderby elencoPersonaggi.NumeroPG ascending
							  select elencoPersonaggi).Skip(startPage).Take(pageSize);
				return characters.ToList();
			}
		}

		public IList<Personaggio> GetCharactersByCode(List<long> NumeriPG)
		{			
			using (HolonetEntities context = new HolonetEntities(_connectionString))
			{
				var characters = (from elencoPersonaggi in context.Personaggios.Include("AbilitaPersonaggios").Include("Giocatore")
								  where NumeriPG.Contains(elencoPersonaggi.NumeroPG)
								  orderby elencoPersonaggi.NumeroPG ascending
								  select elencoPersonaggi);
				return characters.ToList();
			}
		}

        public long GetPersonaggioByGUID(Guid? uniqueID)
        {
            long NumeroPG = -1;
            using (HolonetEntities context = new HolonetEntities(_connectionString))
            {
                var character = (from personaggi in context.Personaggios
                                where personaggi.CodicePg == uniqueID
                                select personaggi).FirstOrDefault();

                if (character != null)
                {
                    NumeroPG = character.NumeroPG;
                }
            }
            return NumeroPG;
        }
	}
}

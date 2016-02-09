using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;

namespace CommonBusiness.Infezioni
{
    public class InfezioniManager : BaseDataManager
    {
        public InfezioniManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

        public IList<Infezione> GetAllInfections()
        {
            return (from infezioni in context.Infeziones
                    orderby infezioni.Nome ascending
                    select infezioni).ToList();
        }

        public IList<Infezione> GetInfectionsByCharacter(long numeroPG)
        {
            var infezioni = (from personaggi in context.Personaggios
                             where personaggi.NumeroPG == numeroPG
                             select personaggi).FirstOrDefault().Infeziones.OrderBy(p => p.Nome);
            return infezioni.ToList();
        }

        public string GetInfectionDescription(long progressivo)
        {
            return (from infezioni in context.Infeziones
                    where infezioni.Progressivo == progressivo
                    select infezioni.Descrizione).FirstOrDefault();
        }

        public bool InsertNewInfection(string nome, string descrizione)
        {
            try
            {
                Infezione malattia = new Infezione();
                malattia.Nome = nome.Trim();
                malattia.Descrizione = descrizione.Trim();
                context.Infeziones.AddObject(malattia);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddInfectionToCharacter(long numeroPG, long progressivo)
        {
            try
            {
                var personaggio = (from personaggi in context.Personaggios
                                   where personaggi.NumeroPG == numeroPG
                                   select personaggi).FirstOrDefault();
                var infezione = (from infezioni in context.Infeziones
                                 where infezioni.Progressivo == progressivo
                                 select infezioni).FirstOrDefault();
                if (!personaggio.Infeziones.Contains(infezione))
                {
                    personaggio.Infeziones.Add(infezione);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveInfectionFromCharacter(long numeroPG, long progressivo)
        {
            try
            {
                var personaggio = (from personaggi in context.Personaggios
                                   where personaggi.NumeroPG == numeroPG
                                   select personaggi).FirstOrDefault();
                var infezione = (from infezioni in context.Infeziones
                                 where infezioni.Progressivo == progressivo
                                 select infezioni).FirstOrDefault();
                if (personaggio.Infeziones.Contains(infezione))
                {
                    personaggio.Infeziones.Remove(infezione);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

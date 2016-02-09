using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;

namespace CommonBusiness.Sostanze
{
	public class SostanzeManager : BaseDataManager
	{
		public SostanzeManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public int Count()
		{
			return (from oggetti in context.NewElementis
					select oggetti).OfType<NewSostanze>().Count();
		}

		public NewSostanze GetSubstanceFromNumber(long progressivo)
        {
            return (from items in context.NewElementis
                    where items.Progressivo == progressivo
                    select items).OfType<NewSostanze>().FirstOrDefault();
        }

        public NewSostanze GetSubstanceFromQRCode(Guid codiceQR)
        {
            var oggetto = (from codes in context.CodiciQrs
                           where codes.Codice == codiceQR
                           select codes.NewElementi).OfType<NewSostanze>().FirstOrDefault();
            return oggetto;
        }

		public IEnumerable<NewSostanze> GetSubstancesFromNumbers(List<long> progressivi)
        {
            var substances = (from items in context.NewElementis
                    where progressivi.Contains(items.Progressivo)
                    orderby items.Nome
					select items).OfType<NewSostanze>();
			foreach (var sostanza in substances)
			{
				int codesAvailable = sostanza.CodiciQrs.Count;
				if (codesAvailable < 10)
				{
					for (int i = 0; i < 10; i++)
					{
						CodiciQr codeToCheck = sostanza.CodiciQrs.Skip(i).FirstOrDefault();
						if (codeToCheck == null)
						{
							codeToCheck = new CodiciQr();
							codeToCheck.Codice = Guid.NewGuid();
							sostanza.CodiciQrs.Add(codeToCheck);
						}
					}
                    context.SaveChanges();
				}
			}

			return substances;
        }

		public IList<NewSostanze> GetPagedSubstancesList(int startPage, int pageSize)
		{
			var elencoOggetti = (from items in context.NewElementis
								 orderby items.Nome ascending
								 select items).OfType<NewSostanze>().Skip(startPage).Take(pageSize);
			return elencoOggetti.ToList();
		}

        public IList<NewSostanze> GetPagedSubstancesList(int startPage, int pageSize, long type)
        {
            var elencoOggetti = (from items in context.NewElementis
                                 orderby items.Nome ascending
                                 select items).OfType<NewSostanze>().Where(p => p.Tipo == type).Skip(startPage).Take(pageSize);
            return elencoOggetti.ToList();
        }

		public IList<NewSostanze> GetSubstancesFromText(string toSearch)
		{
			toSearch = toSearch.Trim().ToLower();
			var elencoOggetti = (from items in context.NewElementis
								 where items.Nome.ToLower().Contains(toSearch)
								 || items.Effetto.ToLower().Contains(toSearch)
								 select items).OfType<NewSostanze>();
			return elencoOggetti.ToList();
		}

        public IList<NewSostanze> GetSubstancesFromText(string toSearch, long tipo)
        {
            return GetSubstancesFromText(toSearch).Where(p => p.Tipo == tipo).ToList();
        }

		public bool SaveNewSubstance(string nome, string desc, string effetto, string urlImmagine, float costo, long disponibilita, DateTime? scadenza, string modoUso, long tipoSostanza, long valoreEfficacia)
		{
			try
			{
				//creo l'oggetto
				NewSostanze newItem = new NewSostanze();
				newItem.Costo = costo;
				newItem.DataScadenza = scadenza;
				newItem.Descrizione = desc;
				newItem.Disponibilita = disponibilita;
				newItem.Effetto = effetto;
				newItem.Immagine = urlImmagine;
				newItem.Nome = nome;
				newItem.ModoUso = modoUso;
				newItem.ValoreEfficacia = valoreEfficacia;
				newItem.Tipo = tipoSostanza;
				//ora creo i dieci GUID che servono a fare i QR differenziati
				for (int i = 0; i < 10; i++)
				{
					CodiciQr codice = new CodiciQr();
					codice.Codice = Guid.NewGuid();
					newItem.CodiciQrs.Add(codice);
				}
				context.AddToNewElementis(newItem);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveSubstance(long? progressivo, string nome, string desc, string effetto, string urlImmagine, float costo, long disponibilita, DateTime? scadenza, string modoUso, long tipoSostanza, long valoreEfficacia)
        {
            try
            {
                if (!progressivo.HasValue)
                {
                    return SaveNewSubstance(nome, desc, effetto, urlImmagine, costo, disponibilita, scadenza, modoUso, tipoSostanza, valoreEfficacia);
                }
                NewSostanze itemToEdit = GetSubstanceFromNumber(progressivo.Value);
                itemToEdit.Costo = costo;
                itemToEdit.DataScadenza = scadenza;
                itemToEdit.Descrizione = desc;
                itemToEdit.Disponibilita = disponibilita;
                itemToEdit.Effetto = effetto;
                itemToEdit.Immagine = urlImmagine;
                itemToEdit.Nome = nome;
				itemToEdit.ModoUso = modoUso;
				itemToEdit.ValoreEfficacia = valoreEfficacia;
				itemToEdit.Tipo = tipoSostanza;
                return true;
            }
            catch
            {
                return false;
            }
        }

		public bool CloneItem(long progressivo, string nome, string desc, string effetto, string urlImmagine, float costo, long disponibilita, DateTime? scadenza, string modoUso, long tipoSostanza, long valoreEfficacia)
        {
            try
            {
                //Creo l'oggetto nuovo (la clonatura in realtà è avvenuta in Form, qui "clono" solo i Componenti
				NewSostanze newItem = new NewSostanze();
                newItem.Costo = costo;
                newItem.DataScadenza = scadenza;
                newItem.Descrizione = desc;
                newItem.Disponibilita = disponibilita;
                newItem.Effetto = effetto;
                newItem.Immagine = urlImmagine;
                newItem.Nome = nome;
				newItem.ModoUso = modoUso;
				newItem.ValoreEfficacia = valoreEfficacia;
				newItem.Tipo = tipoSostanza;
                context.AddToNewElementis(newItem);
                //Ora "clono" i componenti dall'oggetto originale
                IEnumerable<NewFormule> components = from componenti in context.NewFormules
                                                     where componenti.Risultato == progressivo
                                                     orderby componenti.NumeroIngrediente ascending
                                                     select componenti;
                foreach (NewFormule singleComponent in components)
                {
                    NewFormule newComponent = new NewFormule();
                    newComponent.Ingrediente = singleComponent.Ingrediente;
                    newComponent.NumeroIngrediente = singleComponent.NumeroIngrediente;
                    newItem.Componenti.Add(newComponent);
                }
				//ora creo i dieci GUID che servono a fare i QR differenziati
				for (int i = 0; i < 10; i++)
				{
					CodiciQr codice = new CodiciQr();
					codice.Codice = Guid.NewGuid();
					newItem.CodiciQrs.Add(codice);
				}
				context.AddToNewElementis(newItem);
                return true;
            }
            catch
            {
                return false;
            }
        }

		public IEnumerable GetComponentsBySubstance(long progressivo)
		{
			return from componenti in context.NewFormules
				   where componenti.Risultato == progressivo
				   orderby componenti.NumeroIngrediente
				   select new { componenti.NumeroIngrediente, componenti.NewElementi.Nome };
		}

		public IEnumerable GetSubstancesForCombo()
		{
			return (from componenti in context.NewElementis
					orderby componenti.Nome, componenti.Progressivo
					select componenti).OfType<NewSostanze>();
		}

        public IEnumerable GetSubstancesForCombo(long tipo)
        {
            return GetSubstancesForCombo().OfType<NewSostanze>().Where(comp => comp.Tipo == tipo).ToList<NewSostanze>();
        }

		public string GetEffectOfSubstance(long progressivo)
		{
			return (from oggetto in context.NewElementis
				   where oggetto.Progressivo == progressivo
				   select oggetto.Effetto).FirstOrDefault();
		}
		public long GetEffectValueOfSubstance(long progressivo)
		{
			var substance = (from oggetto in context.NewElementis
							 where oggetto.Progressivo == progressivo
							 select oggetto).FirstOrDefault();
			NewSostanze sostanza = substance as NewSostanze;
			return sostanza.ValoreEfficacia;
		}

		public bool AddComponentToSubstance(long progressivoSostanza, long progressivoIngrediente)
		{
			try
			{
				long? numeroMassimo = null;
				var ingredienti = (from componenti in context.NewFormules
											where componenti.Risultato == progressivoSostanza
											orderby componenti.NumeroIngrediente descending
											select componenti.NumeroIngrediente);
				if (ingredienti.Count() > 0)
				{
					numeroMassimo = ingredienti.Max();
				}
				if (!numeroMassimo.HasValue)
				{
					numeroMassimo = -1;
				}
				NewSostanze item = (from oggetti in context.NewElementis
								   where oggetti.Progressivo == progressivoSostanza
									select oggetti).OfType<NewSostanze>().FirstOrDefault();
				NewFormule ingrediente = new NewFormule();
				ingrediente.Ingrediente = progressivoIngrediente;
				ingrediente.NumeroIngrediente = numeroMassimo.Value + 1;
				item.Componenti.Add(ingrediente);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool RemoveComponentFromSubstance(long progressivoOggetto, long numeroIngrediente)
		{
			try
			{
				var ingrediente = (from componenti in context.NewFormules
								   where componenti.Risultato == progressivoOggetto
								   && componenti.NumeroIngrediente == numeroIngrediente
								   select componenti).FirstOrDefault();

				if (ingrediente != null)
				{
					NewSostanze item = (from sostanze in context.NewElementis
										where sostanze.Progressivo == progressivoOggetto
										select sostanze).OfType<NewSostanze>().FirstOrDefault();
					item.Componenti.Remove(ingrediente);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public NewSostanze GetSubstanceFromListOfComponents(List<long?> ingredienti)
		{
			//var query = (from sostanze in context.NewElementis
			//             join formule in context.NewFormules on sostanze equals formule.Composto
			//             where ingredienti.Contains(formule.NewElementi.Progressivo)
			//             && sostanze.Componenti.Count() == ingredienti.Count
			//             select sostanze);

			var query = from formule in context.NewFormules
						where ingredienti.Contains(formule.Ingrediente)
						group formule by formule.Risultato into selezione
						select new { numero = selezione.Key, elementi = selezione};
			NewSostanze sostanza = null;
			foreach (var element in query)
			{
				var query2 = (from sostanze in context.NewElementis
							  where sostanze.Progressivo == element.numero
							  && sostanze.Componenti.Count == ingredienti.Count
							  select sostanze).OfType<NewSostanze>().FirstOrDefault();
				//sostanza = GetSubstanceFromNumber(element.numero);
				if (query2 != null && query2 is NewSostanze)
				{
					//controlliamo l'ORDINE degli ingredienti
					var componenti = (from components in query2.Componenti
									  orderby components.NumeroIngrediente
									  select components).ToList();
					bool found = true;
					for (int i = 0; i < ingredienti.Count; i++)
					{
						if (ingredienti[i] != componenti[i].Ingrediente)
						{
							found = false;
							break;
						}
					}
					if (found)
					{
						return (NewSostanze)query2;
					}
				}
			}
			return sostanza;
		}

        public List<TipoSostanze> GetSubstancesTypes()
        {
            return (from tipi in context.TipoSostanzes
                    orderby tipi.Progressivo
                    select tipi).ToList();
        }
	}
}

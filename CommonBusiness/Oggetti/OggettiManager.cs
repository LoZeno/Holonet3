using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;

namespace CommonBusiness.OggettiManager
{
	public class OggettiManager : BaseDataManager
	{
		public OggettiManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public int Count()
		{
			return (from oggetti in context.NewElementis
					select oggetti).OfType<NewOggetti>().Count();
		}

        public NewOggetti GetItemFromQRCode(Guid codiceQR)
        {
            var oggetto = (from codes in context.CodiciQrs
                           where codes.Codice == codiceQR
                           select codes.NewElementi).OfType<NewOggetti>().FirstOrDefault();
            return oggetto;
        }

        public NewOggetti GetItemFromNumber(long progressivo)
        {
            return (from items in context.NewElementis
                    where items.Progressivo == progressivo
                    select items).OfType<NewOggetti>().FirstOrDefault();
        }

        public IEnumerable<NewOggetti> GetItemsFromNumbers(List<long> progressivi)
        {
            var oggetti = (from items in context.NewElementis
                    where progressivi.Contains(items.Progressivo)
                    orderby items.Nome
                    select items).OfType<NewOggetti>();

            foreach (var oggetto in oggetti)
            {
                int codesAvailable = oggetto.CodiciQrs.Count;
                if (codesAvailable < 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        CodiciQr codeToCheck = oggetto.CodiciQrs.Skip(i).FirstOrDefault();
                        if (codeToCheck == null)
                        {
                            codeToCheck = new CodiciQr();
                            codeToCheck.Codice = Guid.NewGuid();
                            oggetto.CodiciQrs.Add(codeToCheck);
                        }
                    }
                    context.SaveChanges();
                }
            }
            return oggetti;
        }

		public IList<NewOggetti> GetPagedItemsList(int startPage, int pageSize)
		{
			var elencoOggetti = (from items in context.NewElementis
								 orderby items.Nome ascending
								 select items).OfType<NewOggetti>().Skip(startPage).Take(pageSize);
			return elencoOggetti.ToList();
		}

		public IList<NewOggetti> GetItemsFromText(string toSearch)
		{
			toSearch = toSearch.Trim().ToLower();
			var elencoOggetti = (from items in context.NewElementis
								 where items.Nome.ToLower().Contains(toSearch)
								 || items.Effetto.ToLower().Contains(toSearch)
								 select items).OfType<NewOggetti>();
			return elencoOggetti.ToList();
		}

        public IList<NewOggetti> GetItemsFromText(string toSearch, long tipo)
        {
            return GetItemsFromText(toSearch).Where(p => p.Tipo == tipo).ToList();
        }

		public bool SaveNewItem(string nome, string desc, string effetto, string urlImmagine, float costo, long disponibilita, DateTime? scadenza, int? numeroCariche, long tipoOggetto)
		{
			try
			{
				//creo l'oggetto
				NewOggetti newItem = new NewOggetti();
				newItem.Costo = costo;
				newItem.DataScadenza = scadenza;
				newItem.Descrizione = desc;
				newItem.Disponibilita = disponibilita;
				newItem.Effetto = effetto;
				newItem.Immagine = urlImmagine;
				newItem.Nome = nome;
				newItem.NumeroCariche = numeroCariche;
                newItem.Tipo = tipoOggetto;
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

        public bool SaveItem(long? progressivo, string nome, string desc, string effetto, string urlImmagine, float costo, long disponibilita, DateTime? scadenza, int? numeroCariche, long tipoOggetto)
        {
            try
            {
                if (!progressivo.HasValue)
                {
                    return SaveNewItem(nome, desc, effetto, urlImmagine, costo, disponibilita, scadenza, numeroCariche, tipoOggetto);
                }
                NewOggetti itemToEdit = GetItemFromNumber(progressivo.Value);
                itemToEdit.Costo = costo;
                itemToEdit.DataScadenza = scadenza;
                itemToEdit.Descrizione = desc;
                itemToEdit.Disponibilita = disponibilita;
                itemToEdit.Effetto = effetto;
                itemToEdit.Immagine = urlImmagine;
                itemToEdit.Nome = nome;
                itemToEdit.NumeroCariche = numeroCariche;
                itemToEdit.Tipo = tipoOggetto;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CloneItem(long progressivo, string nome, string desc, string effetto, string urlImmagine, float costo, long disponibilita, DateTime? scadenza, int? numeroCariche, long tipoOggetto)
        {
            try
            {
                //Creo l'oggetto nuovo (la clonatura in realtà è avvenuta in Form, qui "clono" solo i Componenti
                NewOggetti newItem = new NewOggetti();
                newItem.Costo = costo;
                newItem.DataScadenza = scadenza;
                newItem.Descrizione = desc;
                newItem.Disponibilita = disponibilita;
                newItem.Effetto = effetto;
                newItem.Immagine = urlImmagine;
                newItem.Nome = nome;
                newItem.NumeroCariche = numeroCariche;
                newItem.Tipo = tipoOggetto;
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

		public IEnumerable GetComponentsByItem(long progressivo)
		{
			return from componenti in context.NewFormules
				   where componenti.Risultato == progressivo
				   orderby componenti.NumeroIngrediente
				   select new { componenti.NumeroIngrediente, componenti.NewElementi.Nome };
		}

		public IEnumerable GetItemsForCombo()
		{
			return (from componenti in context.NewElementis
					orderby componenti.Nome, componenti.Progressivo
					select componenti).OfType<NewOggetti>();
		}

        public IEnumerable GetItemsForCombo(long tipo)
        {
            return GetItemsForCombo().OfType<NewOggetti>().Where(obj => obj.Tipo == tipo).ToList<NewOggetti>();
        }

		public string GetEffectOfItem(long progressivo)
		{
			return (from oggetto in context.NewElementis
				   where oggetto.Progressivo == progressivo
                    select oggetto.Descrizione + "\r\n \r\n" + oggetto.Effetto).FirstOrDefault();
		}

		public bool AddComponentToItem(long progressivoOggetto, long progressivoComponente)
		{
			try
			{
				long? numeroMassimo = null;
				var ingredienti = (from componenti in context.NewFormules
											where componenti.Risultato == progressivoOggetto
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
				NewOggetti item = (from oggetti in context.NewElementis
								   where oggetti.Progressivo == progressivoOggetto
								   select oggetti).OfType<NewOggetti>().FirstOrDefault();
				NewFormule ingrediente = new NewFormule();
				ingrediente.Ingrediente = progressivoComponente;
				ingrediente.NumeroIngrediente = numeroMassimo.Value + 1;
				item.Componenti.Add(ingrediente);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool RemoveComponentFromItem(long progressivoOggetto, long numeroIngrediente)
		{
			try
			{
				var ingrediente = (from componenti in context.NewFormules
								   where componenti.Risultato == progressivoOggetto
								   && componenti.NumeroIngrediente == numeroIngrediente
								   select componenti).FirstOrDefault();

				if (ingrediente != null)
				{
					NewOggetti item = (from oggetti in context.NewElementis
									   where oggetti.Progressivo == progressivoOggetto
									   select oggetti).OfType<NewOggetti>().FirstOrDefault();
					item.Componenti.Remove(ingrediente);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<string> GetTypesList()
		{
			return from tipi in context.TipoOggettis
				   orderby tipi.Descrizione ascending
				   select tipi.Descrizione;
		}

		public bool SaveNewType(string nuovoTipo)
		{
			try
			{
				var presente = from tipi in context.TipoOggettis
							   where tipi.Descrizione == nuovoTipo.Trim()
							   select tipi;
				if (presente.Count() > 0)
				{
					return false;
				}

				TipoOggetti tipo = new TipoOggetti();
				tipo.Descrizione = nuovoTipo;
				context.AddToTipoOggettis(tipo);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public NewOggetti GetItemFromListOfComponents(List<long?> ingredienti)
		{

			var query = from formule in context.NewFormules
						where ingredienti.Contains(formule.Ingrediente)
						group formule by formule.Risultato into selezione
						select new { numero = selezione.Key, elementi = selezione };
			NewOggetti oggetto = null;
			foreach (var element in query)
			{
				var query2 = (from oggetti in context.NewElementis
							  where oggetti.Progressivo == element.numero
							  && oggetti.Componenti.Count == ingredienti.Count
							  select oggetti).OfType<NewOggetti>().FirstOrDefault();
				//sostanza = GetSubstanceFromNumber(element.numero);
				if (query2 != null && query2 is NewOggetti)
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
						return (NewOggetti)query2;
					}
				}
			}
			return oggetto;
		}

        public List<TipoOggetti> GetItemTypes()
        {
            List<TipoOggetti> result = (from tipi in context.TipoOggettis
                    orderby tipi.Descrizione ascending
                    select tipi).ToList();
            TipoOggetti allItems = new TipoOggetti() { Descrizione = "TUTTI GLI OGGETTI", Progressivo = -1 };
            result.Insert(0, allItems);
            return result;
        }

        public IList<NewOggetti> GetPagedItemsList(int startPage, short pageSize, long tipoOggetti)
        {
            var elencoOggetti = (from items in context.NewElementis
                                 orderby items.Nome ascending
                                 select items).OfType<NewOggetti>().Where(p => p.Tipo == tipoOggetti).Skip(startPage).Take(pageSize);
            return elencoOggetti.ToList();
        }
    }
}

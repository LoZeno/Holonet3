using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;

namespace CommonBusiness.Rubrica
{
	public class RubricaManager : BaseDataManager
	{
		public RubricaManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}
		/// <summary>
		/// Carica l'intera lista della Rubrica di un personaggio
		/// </summary>
		/// <param name="numeroPg">numero PG del personaggio</param>
		/// <returns></returns>
		public IEnumerable<DataAccessLayer.Rubrica> GetContactsByCharacter(long numeroPg)
		{
			return from names in context.Rubricas
				   where names.NumeroPG == numeroPg
				   orderby names.NomeVisualizzato ascending
				   select names;
		}

		public void DeleteContact(long numeroPg, long contatto)
		{
			DataAccessLayer.Rubrica toDelete = (from names in context.Rubricas
												where names.NumeroPG == numeroPg
												&& names.NumeroSalvato == contatto
												select names).FirstOrDefault();
			if (toDelete != null)
			{
				context.Rubricas.DeleteObject(toDelete);
			}
		}

		public void AddNewContact(long numeroPg, long contatto, string nome)
		{
			DataAccessLayer.Rubrica elemento = new DataAccessLayer.Rubrica();
			elemento.NumeroPG = numeroPg;
			elemento.NumeroSalvato = contatto;
			elemento.NomeVisualizzato = nome;
			context.AddToRubricas(elemento);
		}

		public bool HasContact(long numeroPg, long contatto)
		{
			return (from names in context.Rubricas
						  where names.NumeroPG == numeroPg && names.NumeroSalvato == contatto
						  select names).Any();
		}
	}
}

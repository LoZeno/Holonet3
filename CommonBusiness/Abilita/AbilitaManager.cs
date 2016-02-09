using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;
using System.Linq.Expressions;
using DataAccessLayer.Enum;

namespace CommonBusiness.Abilita
{
	public class AbilitaManager : BaseDataManager
	{
		public AbilitaManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public IList<Attitudine> GetAllSkillgroups()
		{
			return (from attitudini in context.Attitudines
					orderby attitudini.CdAttitudine
					select attitudini).ToList<Attitudine>();
		}

		public IList GetSkillgroupsForCombo()
		{
			return (from attitudini in context.Attitudines
					orderby attitudini.Nome ascending
					select new { attitudini.CdAttitudine, attitudini.Nome }).ToList();
		}

        public IList GetSkillgroupsForCombo(TipoAttitudine tipo)
        {
            return (from attitudini in context.Attitudines
                    where attitudini.Tipo == (long)tipo
                    orderby attitudini.Nome ascending
                    select new { attitudini.CdAttitudine, attitudini.Nome }).ToList();
        }

		public DataAccessLayer.Abilita GetSkill(long cdAbilita)
		{
			return (from abilita in context.Abilitas
					where abilita.CdAbilita == cdAbilita
					select abilita).FirstOrDefault();
		}

		public IEnumerable GetSkillsFromGroup(string cdAttitudine)
		{
			//var skillGroup = (from attitudini in context.Attitudines
			//                        where attitudini.CdAttitudine == cdAttitudine
			//                        select attitudini).FirstOrDefault();

			//var selection = from abilita in context.Abilitas
			//                where abilita.Attitudines.Contains(skillGroup)
			//                select abilita;

			var selection = (from attitudini in context.Attitudines
				   where attitudini.CdAttitudine == cdAttitudine
				   select attitudini.Abilitas).FirstOrDefault();
			return selection;
		}

		public bool EditSkillGroup(string cdAttitudine, string nome, string descrizione, TipoAttitudine tipo)
		{
			try
			{
				Attitudine skillGroup = (from attitudini in context.Attitudines
										 where attitudini.CdAttitudine == cdAttitudine
										 select attitudini).FirstOrDefault();
				if (skillGroup == null)
				{
					return false;
				}
				skillGroup.Nome = nome;
				skillGroup.Descrizione = descrizione;
                skillGroup.TipoAttitudine = tipo;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool InsertNewSkillgroup(string cdAttitudine, string nome, string descrizione, TipoAttitudine tipo)
		{
			try
			{
				Attitudine newGroup = new Attitudine();
				newGroup.CdAttitudine = cdAttitudine;
				newGroup.Nome = nome;
				newGroup.Descrizione = descrizione;
                newGroup.TipoAttitudine = tipo;
				context.Attitudines.AddObject(newGroup);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Attitudine GetSkillGroup(string cdAttitudine)
		{
			return (from attitudini in context.Attitudines
					where attitudini.CdAttitudine == cdAttitudine
					select attitudini).FirstOrDefault();
		}

        public IEnumerable<Attitudine> GetSkillGroupFromType(TipoAttitudine tipo)
        {
            return (from attitudini in context.Attitudines
                    where attitudini.Tipo == (long)tipo
                    orderby attitudini.Nome
                    select attitudini);
        }

		public bool InsertSkillToGroup(string cdAttitudine, string nome, string descrizione, bool multiAcquisto, long costo, bool avanzato)
		{
			try
			{
				Attitudine list = GetSkillGroup(cdAttitudine);
				DataAccessLayer.Abilita skill = new DataAccessLayer.Abilita();
				skill.Nome = nome;
				skill.Descrizione = descrizione;
				skill.Multiacquisto = multiAcquisto ? 1 : 0;
				skill.Costo = costo;
				skill.BaseAvanzato = avanzato ? 1 : 0;
				list.Abilitas.Add(skill);				
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool EditSkill(long cdAbilita, string nome, string descrizione, bool multiAcquisto, long costo, bool avanzato)
		{
			try
			{
				DataAccessLayer.Abilita skill = GetSkill(cdAbilita);
				skill.Nome = nome;
				skill.Descrizione = descrizione;
				skill.Multiacquisto = multiAcquisto ? 1 : 0;
				skill.Costo = costo;
				skill.BaseAvanzato = avanzato ? 1 : 0;
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}

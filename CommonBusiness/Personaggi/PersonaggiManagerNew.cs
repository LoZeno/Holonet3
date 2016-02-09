using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;
using CommonBusiness.Abilita;
using System.Data.Objects.SqlClient;

namespace CommonBusiness.Personaggi
{
	public class PersonaggiManagerNew : BaseDataManager
	{
		public PersonaggiManagerNew(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

        public int Count()
        {
            return (from personaggi in context.Personaggios
                    select personaggi).Count();
        }

		public IList GetCharacterForSelectableGrid()
		{
			return (from personaggi in context.Personaggios
					orderby personaggi.Nome
					select new {Nome = personaggi.Nome, NumeroPG = personaggi.NumeroPG }).ToList();
		}

		public IList<Personaggio> GetAllCharacters()
		{
			return (from personaggi in context.Personaggios
					orderby personaggi.Nome
					select personaggi).ToList();
		}

        public IList<Personaggio> GetPagedCharacters(int startPage, int pageSize)
        {
            var elencoPersonaggi = (from characters in context.Personaggios
                                    orderby characters.Nome ascending
                                    select characters).Skip(startPage).Take(pageSize);
            return elencoPersonaggi.ToList();
        }

		public Personaggio GetCharacterByGUID(Guid? uniqueID)
		{
			var character = (from personaggi in context.Personaggios
								where personaggi.CodicePg == uniqueID
								select personaggi).FirstOrDefault();
			return character;
		}

		public Personaggio GetCharacterByNumber(long numeroPG)
		{
			return (from personaggi in context.Personaggios
					where personaggi.NumeroPG == numeroPG
					select personaggi).FirstOrDefault();
		}

		public string GetCharacterNameByNumber(long numeroPg)
		{
			var character = (from personaggio in context.Personaggios
						   where personaggio.NumeroPG == numeroPg && personaggio.Vivo == 1
						   select personaggio).FirstOrDefault();
			if (character != null)
			{
				return character.Nome;
			}
			return null;
		}

		public long? GetCharacterNumberByName(string name)
		{
			name = name.Trim();
			var personaggio = (from personaggi in context.Personaggios
					where personaggi.Nome == name && personaggi.Vivo == 1
					select personaggi).FirstOrDefault();
			if (personaggio != null)
			{
				return personaggio.NumeroPG;
			}
			return null;
		}

        public IList<Personaggio> GetCharactersByName(string name)
        {
            name = name.Trim().ToLower();
            return (from personaggi in context.Personaggios
                    where personaggi.Nome.ToLower().Contains(name) 
                    && personaggi.Vivo == 1
                    select personaggi).ToList();
        }

		public Personaggio GetCharacterByName(string name)
		{
			name = name.Trim();
			return (from personaggi in context.Personaggios
							   where personaggi.Nome.Contains(name) && personaggi.Vivo == 1
							   select personaggi).FirstOrDefault();
		}

		public IEnumerable<long> GetCharacterNumbersByNames(string[] names)
		{
			for (int i = 0; i < names.Length; i++)
			{
				names[i] = names[i].Trim();
			}
			return from personaggi in context.Personaggios
				   where names.Contains(personaggi.Nome) && personaggi.Vivo == 1
				   select personaggi.NumeroPG;
		}

        public List<Personaggio> GetCharactersByPlayer(long numeroSw)
        {
            return (from personaggi in context.Personaggios
                    where personaggi.NumeroSW == numeroSw
                    orderby personaggi.NumeroPG
                    select personaggi).ToList<Personaggio>();
        }

		public IList GetFactions()
		{
			return (from fazioni in context.Retes
					orderby fazioni.Fazione ascending
					select new { fazioni.NumeroRete, fazioni.Fazione }).ToList();
		}

		public IList GetSpecies()
		{
			return (from specie in context.Species
					orderby specie.Nome ascending
					select new { specie.Specie1, specie.Nome }).ToList();
		}

		public bool HasSkill(long numeroPG, long cdAbilita)
		{
			var ricerca = (from abilita in context.AbilitaPersonaggios
					   where abilita.NumeroPG == numeroPG
					   && abilita.CdAbilita == cdAbilita
					   select abilita);
			return (ricerca.Count() > 0);
		}

		public List<string> GetSpeciesNames()
		{
			return (from specie in context.Species
					orderby specie.Nome ascending
					select specie.Nome).ToList<string>();
		}

		public bool SaveNewSpecies(string name, string desc)
		{
			try
			{
				var checkIfExist = from species in context.Species
								   where species.Nome == name
								   select species;
				if (checkIfExist.Count() > 0)
				{
					return false;
				}
				if (string.IsNullOrWhiteSpace(desc))
				{
					desc = null;
				}

				Specie newSpecies = new Specie();
				newSpecies.Descrizione = desc;
				newSpecies.Nome = name;
				context.AddToSpecies(newSpecies);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool CreateNewCharacter(long? numeroPg, long numeroSw, string nome, long specie, long tipo, long punti, string sesso, long latoOscuro, DateTime dataCreazione, long vivo, DateTime? dataMorte, string password, long fazione, string titolo, List<string> attitudini)
		{
			try
			{
				Personaggio newCharacter = new Personaggio();
				if (numeroPg.HasValue)
				{
					var checkIfExists = GetCharacterByNumber(numeroPg.Value);
					if (checkIfExists != null)
					{
						return false;
					}
					newCharacter.NumeroPG = numeroPg.Value;
				}
				newCharacter.NumeroSW = numeroSw;
				newCharacter.Nome = nome;
				newCharacter.Specie = specie;
				newCharacter.Tipo = tipo;
				newCharacter.Punti = punti;
				newCharacter.Sesso = sesso;
				newCharacter.LatoOscuro = latoOscuro;
				newCharacter.DataCreazione = dataCreazione;
				newCharacter.Vivo = vivo;
				newCharacter.DataMorte = dataMorte;
				newCharacter.PasswordHolonet = password;
				newCharacter.Fazione = fazione;
				newCharacter.Titolo = titolo;
				newCharacter.CodicePg = Guid.NewGuid();
				foreach (string cdattitudine in attitudini)
				{
					Attitudine attitudine = (from lists in context.Attitudines
											where lists.CdAttitudine == cdattitudine
											select lists).FirstOrDefault();
					newCharacter.Attitudines.Add(attitudine);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveCharacter(long numeroPg, string nome, long specie, long tipo, long punti, string sesso, long latoOscuro, DateTime dataCreazione, long vivo, DateTime? dataMorte, string password, long fazione, string titolo, List<string> attitudini)
		{
			try
			{
				Personaggio character = GetCharacterByNumber(numeroPg);
				character.Nome = nome;
				character.Specie = specie;
				character.Tipo = tipo;
				character.Punti = punti;
				character.Sesso = sesso;
				character.LatoOscuro = latoOscuro;
				character.DataCreazione = dataCreazione;
				character.Vivo = vivo;
				character.DataMorte = dataMorte;
				character.PasswordHolonet = password;
				character.Fazione = fazione;
				character.Titolo = titolo;
				foreach (Attitudine grouplist in character.Attitudines)
				{
					if (!attitudini.Contains(grouplist.CdAttitudine))
					{
						character.Attitudines.Remove(grouplist);
					}
				}
				foreach (string cdattitudine in attitudini)
				{
					Attitudine attitudine = (from lists in context.Attitudines
											 where lists.CdAttitudine == cdattitudine
											 select lists).FirstOrDefault();
					if (!character.Attitudines.Contains(attitudine))
					{
						character.Attitudines.Add(attitudine);
					}
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public long GetFreeSkillpoints(long numeroPg)
		{
			Personaggio character = GetCharacterByNumber(numeroPg);
			long total = character.Punti;
			AbilitaManager skillManager = new AbilitaManager(context);
			foreach (AbilitaPersonaggio skill in character.AbilitaPersonaggios)
			{
				DataAccessLayer.Abilita possessedSkill = skillManager.GetSkill(skill.CdAbilita);
				long costo = possessedSkill.Costo;
				if (possessedSkill.Multiacquisto == 1 && skill.NumeroAcquisti.HasValue)
				{
					costo *= skill.NumeroAcquisti.Value;
				}
				total -= costo;
			}
			return total;
		}

		public bool AddSkillToCharacter(long numeroPg, long cdAbilita, long? numAcquisti, string attitudine, string specifiche)
		{
			try
			{
				AbilitaManager skillManager = new AbilitaManager(context);
				Personaggio character = GetCharacterByNumber(numeroPg);
				DataAccessLayer.Abilita skill = skillManager.GetSkill(cdAbilita);
				if (character.PossiedeAbilita(cdAbilita))
				{
					if (skill.Multiacquisto == 0)
					{
						AbilitaPersonaggio newSkill = (from abilitas in character.AbilitaPersonaggios
													   where abilitas.CdAbilita == cdAbilita
													   select abilitas).FirstOrDefault();
						newSkill.NumeroAcquisti = numAcquisti;
					}
				}
				else
				{
					AbilitaPersonaggio newSkill = new AbilitaPersonaggio();
					newSkill.CdAbilita = cdAbilita;
					newSkill.CdAttitudine = attitudine;
					newSkill.NumeroAcquisti = numAcquisti;
					newSkill.NumeroPG = numeroPg;
					newSkill.Specifiche = specifiche;
					character.AbilitaPersonaggios.Add(newSkill);
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

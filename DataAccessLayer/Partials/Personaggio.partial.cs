using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public partial class Personaggio
	{
		public bool PossiedeAbilita(long cdAbilita)
		{
			foreach (var skill in this.AbilitaPersonaggios)
			{
				if (skill.CdAbilita == cdAbilita)
				{
					return true;
				}
			}
			return false;
		}

		public int LivelloHacker
		{
			get
			{
				int level = 0;
				foreach (var skill in AbilitaPersonaggios)
				{
					switch (skill.Abilita.Nome.Trim().ToUpper())
					{
						case "HACKING I":
						case "HACKING II":
						case "HACKING III":
						case "HACKING IV":
							level++;
							break;
						default:
							break;
					}
				}
				return level;
			}
		}

		public int LivelloProtezione
		{
			get
			{
				int res = LivelloHacker;
				if (this.Hacker != null)
				{
					res += (int)this.Hacker.Value;
				}
				return res;
			}
		}

		public int PuntiFerita()
		{
			int total = 1;
			foreach (var skill in AbilitaPersonaggios)
			{
				switch (skill.Abilita.Nome.Trim().ToUpper())
				{
					case "ROBUSTEZZA I":
					case "ROBUSTEZZA II":
					case "ROBUSTEZZA III":
						total++;
						break;
					default:
						break;
				}
			}
			return total;
		}

		public int Robustezza()
		{
			int total = 1;
			foreach (var skill in AbilitaPersonaggios)
			{
				switch (skill.Abilita.Nome.Trim().ToUpper())
				{
					case "ROBUSTEZZA I":
					case "ROBUSTEZZA II":
					case "ROBUSTEZZA III":
						total++;
						break;
					default:
						break;
				}
			}
			return total;
		}

		public int ForzaMentale()
		{
			int total = 0;
			foreach (var skill in AbilitaPersonaggios)
			{
				switch (skill.Abilita.Nome.Trim().ToUpper())
				{
					case "FORZA MENTALE I":
					case "FORZA MENTALE II":
					case "FORZA MENTALE III":
					case "FORZA MENTALE IV":
						total++;
						break;
					default:
						break;
				}
			}
			return total;
		}

		public string NumeroENomeCombo
		{
			get
			{
				return NumeroPG + " - " + Nome;
			}
		}

        public long PuntiLiberi
        {
            get
            {
                long total = this.Punti;
                foreach (AbilitaPersonaggio skill in this.AbilitaPersonaggios)
                {
                    long costo = skill.Abilita.Costo;
                    if (skill.Abilita.Multiacquisto == 1 && skill.NumeroAcquisti.HasValue)
                    {
                        costo *= skill.NumeroAcquisti.Value;
                    }
                    total -= costo;
                }
                return total;
            }
        }

        public IEnumerable<Attitudine> AttitudiniScelte
        {
            get
            {
                Enum.TipoAttitudine selectedType = Enum.TipoAttitudine.Biologico;
                if (this.Tipo == 1)
                {
                    selectedType = Enum.TipoAttitudine.Droide;
                }
                return from liste in Attitudines
                       where liste.TipoAttitudine == selectedType
                       select liste;
            }
        }

        public IEnumerable<Attitudine> AttitudiniExtraDroidi
        {
            get
            {
                //if (this.Tipo == 0)
                //{
                //    return null;
                //}
                return from liste in Attitudines
                       where liste.TipoAttitudine == Enum.TipoAttitudine.Biologico
                       select liste;
            }
        }

        public Attitudine ClasseDroide
        {
            get
            {
                if (this.Tipo == 0)
                {
                    return null;
                }
                return (from liste in Attitudines
                       where liste.TipoAttitudine == Enum.TipoAttitudine.ClasseDroide
                       select liste).FirstOrDefault();
            }
        }
	}
}

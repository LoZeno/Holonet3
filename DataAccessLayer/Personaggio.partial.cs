using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public partial class Personaggio
	{
		public long Protezione
		{
			get
			{
				//E' brutto, lo so, perché questo valore andrebbe cachato ma sono le nove del mattino e non ho dormito. E tanto nessun altro guarda il mio codice sorgente
				long protection = 0;
				if (this.Hacker.HasValue)
				{
					protection += (long)this.Hacker;
				}
				if (this.UltimaCrittazione.HasValue && this.UltimaCrittazione > DateTime.Now.AddHours(-3))
				{
					protection += (long)LivelloCrittazione;
				}
				if (protection <= 0)
				{
					protection = 1;
				}
				return protection;
			}
		}
	}
}

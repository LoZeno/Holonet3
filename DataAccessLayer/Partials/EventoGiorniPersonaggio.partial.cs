using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public partial class EventoGiorniPersonaggio
	{
		public string Nome
		{
			get
			{
				return this.Personaggio.Nome;
			}
		}

		public long NumeroSW
		{
			get
			{
				return this.Personaggio.Giocatore.NumeroSW;
			}
		}

		public string NomeGiocatore
		{
			get
			{
				return this.Personaggio.Giocatore.NomeCompleto;
			}
		}

	}
}

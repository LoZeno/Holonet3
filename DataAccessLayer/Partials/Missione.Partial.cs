using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public partial class Missione
	{
		public string NomeMandante
		{
			get
			{
				return this.Personaggio.Nome;
			}
		}
	}
}

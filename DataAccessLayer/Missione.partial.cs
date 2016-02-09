using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public partial class Missione
	{
		public long LivelloCrittazione
		{
			get
			{
				return LivelloHacking;
			}
			set
			{
				LivelloHacking = value;
			}
		}
	}
}

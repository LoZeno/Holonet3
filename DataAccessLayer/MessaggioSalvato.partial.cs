using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public partial class MessaggioSalvato
	{
		public long LivelloCrittazione
		{
			get
			{
				return this.Hacking;
			}
			set
			{
				this.Hacking = value;
			}
		}
	}
}

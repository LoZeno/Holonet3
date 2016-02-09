using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolonetWinControls.Sostanze
{
	public class ModiUso
	{
		public static List<string> Lista()
		{
			List<string> elenco = new List<string>();
			elenco.Add("INERTE");
			elenco.Add("CONTATTO");
			elenco.Add("INGESTIONE");
			elenco.Add("INALAZIONE");
			elenco.Add("INIEZIONE");
			return elenco;
		}
	}
}

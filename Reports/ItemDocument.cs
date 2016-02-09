using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;

namespace Reports
{
	public class ItemDocument
	{
		public void CreateDocument()
		{
			Rectangle pageSize = new Rectangle(PageSize.POSTCARD);
		}
	}
}

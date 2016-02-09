using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonBusiness.BaseClasses;
using DataAccessLayer;
using System.Collections;

namespace CommonBusiness.ElementiBase
{
	public class ElementiBaseManager : BaseDataManager
	{
		public ElementiBaseManager(HolonetEntities contextToUse)
			: base(contextToUse)
		{
		}

		public IQueryable<NewElementi> GetItemsForCombo()
		{
			return (from componenti in context.NewElementis
					orderby componenti.Nome, componenti.Progressivo
					select componenti);
		}
	}
}

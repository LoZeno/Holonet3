using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace CommonBusiness.BaseClasses
{
	public abstract class BaseDataManager
	{
		protected HolonetEntities context;

		public BaseDataManager(HolonetEntities contextToUse)
		{
			context = contextToUse;
		}
	}
}

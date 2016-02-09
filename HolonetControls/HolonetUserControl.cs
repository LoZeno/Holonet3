using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace HolonetWebControls
{
	public class HolonetUserControl : System.Web.UI.UserControl
	{
		public HolonetPage ParentPage
		{
			get
			{
				if (this.Page is HolonetPage)
				{
					return (HolonetPage)Page;
				}
				return null;
			}
		}

		public HolonetEntities DatabaseContext
		{
			get
			{
				if (ParentPage != null)
				{
					return ParentPage.DatabaseContext;
				}
				return null;
			}
		}
	}
}

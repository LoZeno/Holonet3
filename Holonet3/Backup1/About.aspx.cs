using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using HolonetWebControls;

namespace Holonet3
{
	public partial class About : HolonetPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Assembly current = Assembly.GetExecutingAssembly();
				string version = string.Empty;
				string name = string.Empty;
				object[] attributes = current.GetCustomAttributes(false);

				if (attributes.Length > 0)
				{
					foreach (object attribute in attributes)
					{
						if (attribute.GetType() == typeof(AssemblyCopyrightAttribute))
						{
							lblCopyright.Text = ((AssemblyCopyrightAttribute)attribute).Copyright;
						}
						else if (attribute.GetType() == typeof(AssemblyFileVersionAttribute))
						{
							version = ((AssemblyFileVersionAttribute)attribute).Version;
						}
						else if (attribute.GetType() == typeof(AssemblyTitleAttribute))
						{
							name = ((AssemblyTitleAttribute)attribute).Title;
						}
					}
				}

				lblNameVer.Text = name + " ver. " + version;
			}
		}
	}
}

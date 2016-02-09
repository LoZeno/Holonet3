using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using DataAccessLayer;

namespace HolonetManager.BaseClasses
{
    public class BaseManagerUserControl : UserControl
    {
		protected string HolonetConnectionString
		{
			get
			{
				if (this.ParentForm is BaseManagerForm)
				{
					string value = ((BaseManagerForm)this.ParentForm).HolonetConnectionString;
					if (!string.IsNullOrWhiteSpace(value))
					{
						return value;
					}
					return null;
				}
				return null;
			}
		}
		/// <summary>
		/// Crea il context per le entità del database, da usare all'interno dei blocchi "Using" e da passare ai Managers
		/// </summary>
		/// <returns></returns>
		protected HolonetEntities CreateDatabaseContext()
		{
			return new HolonetEntities(HolonetConnectionString);
		}

        public virtual void LoadData()
        {
        }

		protected void OpenFolder(string folderPath)
		{
			Process prc = new Process();
			prc.StartInfo.FileName = folderPath;
			prc.Start();
		}
    }
}

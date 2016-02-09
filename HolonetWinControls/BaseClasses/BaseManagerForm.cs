using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DataAccessLayer;

namespace HolonetManager.BaseClasses
{
    public class BaseManagerForm : Form
    {
        public string HolonetConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings.Count > 0 && ConfigurationManager.ConnectionStrings["HolonetConnection"] != null)
                {
                    return ConfigurationManager.ConnectionStrings["HolonetConnection"].ConnectionString;
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

        public BaseManagerForm()
            : base()
        { }
    }
}

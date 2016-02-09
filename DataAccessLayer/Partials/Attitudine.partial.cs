using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Enum;

namespace DataAccessLayer
{
    public partial class Attitudine
    {
        public TipoAttitudine TipoAttitudine
        {
            get
            {
                return (TipoAttitudine)Tipo;
            }
            set
            {
                Tipo = (long)value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public partial class Giocatore
    {
        public string NomeCompleto
        {
            get
            {
                return this.Cognome + " " + this.Nome;
            }
        }
    }
}

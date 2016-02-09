using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonBusiness.Notizie
{
    public class NotizieModel
    {
        public List<NotiziaModel> news { get; set; }
    }
    public class NotiziaModel
    {
        public long id { get; set; }
        public string autore { get; set; }
        public string titolo { get; set; }
        public string testo { get; set; }
    }
}

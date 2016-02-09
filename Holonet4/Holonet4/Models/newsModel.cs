using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Holonet4.Models
{
    public class NewsHeader
    {
        public List<SingleNewsHeader> news { get; set; }
    }
    public class SingleNewsHeader
    {
        public long id { get; set; }
        public string autore { get; set; }
        public string titolo { get; set; }
        public string preview { get; set; }
        public string testo { get; set; }
    }

}
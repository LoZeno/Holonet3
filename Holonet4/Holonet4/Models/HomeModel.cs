using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonBusiness.Notizie;

namespace Holonet4.Models
{
    public class HomeModel
    {
        public NotizieModel notizie { get; set; }
        public LogOnModel logon { get; set; }
        public string css { get; set; }
    }
}
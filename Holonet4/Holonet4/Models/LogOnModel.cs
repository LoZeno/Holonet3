using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Holonet4.Models
{
    public class LogOnModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string code { get; set; }
        public bool login { get; set; }
    }
}
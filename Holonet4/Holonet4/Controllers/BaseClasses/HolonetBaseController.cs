using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Holonet4.Controllers.BaseClasses
{
    public class HolonetBaseController : Controller
    {
        private HolonetEntities _context;

        /// <summary>
        /// Object Context delle entità del database, da usare nelle query LINQ in pagina
        /// </summary>
        public HolonetEntities DatabaseContext
        {
            get
            {
                InitializeContext();
                return _context;
            }
        }

        /// <summary>
        /// Connection String (presa dal Web.config) usata per l'inizializzazione dell'Object Context
        /// </summary>
        private string HolonetConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["HolonetEntities"] != null)
                {
                    return ConfigurationManager.ConnectionStrings["HolonetEntities"].ConnectionString;
                }
                return string.Empty;
            }
        }

        //la lascio pubblica perché può tornare utile anche all'interno delle pagine normali
        public bool IsMobile
        {
            get
            {
                return IsBrowserMobile(System.Web.HttpContext.Current);
            }
        }

        /// <summary>
        /// Ottiene l'indirizzo IPv4 del client anche se l'ambiente è IPv6-enabled
        /// </summary>
        /// <returns></returns>
        protected string IP4Address
        {
            get
            {
                string IP4Address = String.Empty;

                foreach (IPAddress IPA in Dns.GetHostAddresses(System.Web.HttpContext.Current.Request.UserHostAddress))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP4Address = IPA.ToString();
                        break;
                    }
                }

                if (IP4Address != String.Empty)
                {
                    return IP4Address;
                }

                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP4Address = IPA.ToString();
                        break;
                    }
                }

                return IP4Address;
            }
        }

        private void InitializeContext()
        {
            if (_context == null)
            {
                if (!string.IsNullOrWhiteSpace(HolonetConnectionString))
                {
                    _context = new HolonetEntities(HolonetConnectionString);
                }
                else
                {
                    _context = new HolonetEntities();
                }
            }
        }

        private static bool IsBrowserMobile(HttpContext context)
        {
            bool isMobile = false;
            string mobile = null;
            HttpCookie cookie = null;

            if (context != null)
            {
                //recupero la querystring
                mobile = context.Request.QueryString["mobile"];
                //e recupero anche il cookie
                cookie = context.Request.Cookies["HolonetMobile"];
            }
            //il codice seguente viene eseguito SOLO se ho una querystring "mobile"
            if (!String.IsNullOrEmpty(mobile))
            {
                //Se la querystring esplicita di USCIRE dalla modalità mobile:
                if (mobile == "false")
                {
                    isMobile = false;
                    // modifico il cookie per le pagine successive
                    if (cookie != null)
                    {
                        if (cookie.Value != "false")
                        {
                            context.Response.Cookies["HolonetMobile"].Value = "false";
                        }
                    }
                    else
                    {
                        context.Response.Cookies.Add(new HttpCookie("HolonetMobile", "false"));
                    }
                }
                else //Se la querystring esplicita di ENTRARE nella modalità mobile:
                {
                    isMobile = true;
                    // modifico il cookie per le pagine successive
                    if (cookie != null)
                    {
                        if (cookie.Value != "true")
                        {
                            context.Response.Cookies["HolonetMobile"].Value = "true";
                        }
                    }
                    else
                    {
                        context.Response.Cookies.Add(new HttpCookie("HolonetMobile", "true"));
                    }
                }
            }
            else //se NON c'è una querystring "mobile":
            {
                if (cookie == null)
                {
                    isMobile = MobileTools.IsMobileClient(context);
                    if (isMobile)
                    {
                        context.Response.Cookies.Add(new HttpCookie("HolonetMobile", "true"));
                    }
                    else
                    {
                        context.Response.Cookies.Add(new HttpCookie("HolonetMobile", "false"));
                    }
                }
                else if (cookie.Value == "false")
                {
                    isMobile = false;
                }
                else
                {
                    isMobile = true;
                }
            }
            return isMobile;
        }
    }
}
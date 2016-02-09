using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DataAccessLayer;
using System.Configuration;
using System.Net;

namespace HolonetWebControls
{
	public class HolonetPage : System.Web.UI.Page
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

		/// <summary>
		/// Ottiene l'indirizzo IPv4 del client anche se l'ambiente è IPv6-enabled
		/// </summary>
		/// <returns></returns>
		protected string IP4Address
		{
			get
			{
				string IP4Address = String.Empty;

				foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
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

        protected virtual void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Tema"] != null)
            {
                Page.Theme = Session["Tema"].ToString();
            }
            else
            {
                Page.Theme = "TemaBlu";
            }
        }

        protected int Rete
        {
            get
            {
                object rete = Session["Rete"];
                if (rete != null)
                {
                    return (int)rete;
                }
                return 0;
            }
        }

        /// <summary>
        /// Personaggio loggato all'Holonet
        /// </summary>
        protected Personaggio LoggedCharacter
        {
            get
            {
                //Controllo per prima cosa se la sessione è ancora valida
                object obj = Session["Personaggio"];
                if (obj == null) //Se non lo è, cerco nel cookie
                {
                    if (Context == null) //Se non c'è il Context, abortire.
                    {
                        return null;
                    }
                    HttpCookie cookie = Context.Request.Cookies["Personaggio"];
                    if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value)) //Se non c'è un cookie, o ha valore "vuoto", non è stato fatto il login
                    {
                        return null;
                    }
                    //Recupero il numero PG dal cookie...
                    int numPG = int.Parse(cookie.Value);
                    using (HolonetEntities entities = new HolonetEntities())
                    {
                        //...e con quello recupero il Personaggio dal Database
                        obj = (from characters in entities.Personaggios
                                    where characters.NumeroPG == numPG
                                    select characters).First();
                    }
                    //Se la query non ha dato risultati, abortire
                    if (obj == null)
                    {
                        return null;
                    }
                    //altrimenti, lo rimetto in Session
                    Session["Personaggio"] = (Personaggio)obj;
                }
                return (Personaggio)obj;
            }
            set
            {   
				HttpCookie cookie = Context.Request.Cookies["Personaggio"];
                if (value == null)
                {
                    Context.Response.Cookies.Add(new HttpCookie("Personaggio", string.Empty));
                }
                else
                {

                    if (cookie != null)
                    {
                        cookie.Value = value.NumeroPG.ToString();
                    }
                    else
                    {
                        Context.Response.Cookies.Add(new HttpCookie("Personaggio", value.NumeroPG.ToString()));
                    }
                }
                Session["Personaggio"] = value;
            }
        }        

		//la lascio pubblica perché può tornare utile anche all'interno delle pagine normali
		public bool IsMobile
		{
			get;
			private set;
		}

		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);
			//Controllo se il browser è mobile, e se sì CAMBIO la master page
			IsMobile = IsBrowserMobile(Context);
			if (IsMobile)
			{
				this.MasterPageFile = "~/Mobile.master";
			}
		}

		public static bool IsBrowserMobile(HttpContext context)
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

		protected override void OnUnload(EventArgs e)
		{
			//Se l'Object Context non è stato già terminato, va distrutto qui.
			if (_context != null)
			{
				_context.Dispose();
                _context = null;
			}
			base.OnUnload(e);
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
	}
}

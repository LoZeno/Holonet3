using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonBusiness.Notizie;
using CommonBusiness.Personaggi;
using DataAccessLayer;
using Holonet4.Models;
using Holonet4.Controllers.BaseClasses;

namespace Holonet4.Controllers
{
    public class HomeController : HolonetBaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            NotizieManager newsM = new NotizieManager(DatabaseContext);
            PersonaggiManagerNew pgM = new PersonaggiManagerNew(DatabaseContext);
             NotizieModel news = new NotizieModel();
             HomeModel model = new HomeModel();
            if (User.Identity.Name != null && User.Identity.Name != "")
            {
                Personaggio pg = pgM.GetCharacterByNumber(long.Parse(User.Identity.Name));
                news = newsM.GetActiveNewsInModel((long)pg.Fazione, DateTime.Now);
                switch((long)pg.Fazione)
                {
                    case 0:
                        model.css = "main.css";
                        break;
                    case 1:
                    case 2:
                    case 3:
                        model.css ="main-impero.css";
                    break;
                }
            }
            else
            {
               news = newsM.GetActiveNewsInModel(0, DateTime.Now);
            }
            model.notizie = news;
           return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        {

                
                PersonaggiManagerNew pgM = new PersonaggiManagerNew(DatabaseContext);
                Personaggio pg = pgM.GetCharacterByNumber(long.Parse(model.logon.username));
                if (pg.PasswordHolonet == model.logon.password)
                {
                    FormsAuthentication.SetAuthCookie(pg.NumeroPG.ToString(), false);
                }
                return RedirectToAction("Index", "Home");


        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Credits()
        {
            return View();
        }
    }
}

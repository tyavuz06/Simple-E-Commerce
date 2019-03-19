
using SimpleLogin.FilterAttirubute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class UserController : Controller
    {
        // GET: User


          //  [AutenticationAttr]
        public ActionResult Basket()
        {
            return View();
        }


        public ActionResult Orders()
        {

            return View();

        }

     
        public ActionResult Orders2()
        {

            return View();

        }
    }
}
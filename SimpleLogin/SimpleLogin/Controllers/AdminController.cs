using SimpleLogin.FilterAttirubute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        [AutenticationAttr(RoleNames = "Admin;Salesmanager;Ogrenci")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }
    }
}
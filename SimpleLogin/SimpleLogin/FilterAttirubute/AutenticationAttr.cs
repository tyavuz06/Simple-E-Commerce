using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.FilterAttirubute
{
    public class AutenticationAttr : ActionFilterAttribute
    {
        public string RoleNames { get; set; }
        public string UserNames { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //  eğer sesion kullanırsak
            if (filterContext.RequestContext.HttpContext.Session["User"] == null)
            {


                filterContext.Result = new  RedirectResult("/Account/Login", false);

                return;
            }


            //todo User içinde roller hatalı bu nedenle tekrar db nesnesini kullandık incele   @KADİR
            var User = Service.LoginControl.ControlLogin();

            if (User == null)
            {
                filterContext.Result = new RedirectResult("/Account/Login", false);
                return;
            }



            if (!string.IsNullOrEmpty(RoleNames))
            {
                Data.SimpleData db = new Data.SimpleData();
                List<Data.Role> userDbRoles = db.Users.FirstOrDefault(t => t.ID == User.ID).Roles.ToList();


                string[] roles = RoleNames.Split(';');
                List<string> userroles = userDbRoles.Select(t => t.Name).ToList();
                var result = true;
                foreach (var item in roles)
                {
                    if (!userroles.Contains(item))
                    {
                        result = false;
                        break;
                    }
                }

                if (result != true)
                {
                    //yetkisiz bir sayfaya giriş yapılmaya çalışılıyor
                    filterContext.Result = new RedirectResult("/Error/Index", false);
                }

            }




        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }



}
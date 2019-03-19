using SimpleLogin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class ActivationController : Controller
    {
        // GET: Activation
        public ActionResult Activate(string email, string validationkey)
        {
            Responses.BaseResponse response = new Responses.BaseResponse((int)CommonContant.LANGUAGEID.TR);

            try
            {
                using (Data.SimpleData db = new Data.SimpleData())
                {

                    var User = db.Users.FirstOrDefault(t => t.Email == email);
                    string userkey = null;

                    if (User != null)
                        userkey = Security.sha512encrypt(User.ValidationKey);

                    if (userkey == validationkey)
                    {
                        User.ActiveStatus = (int)CommonContant.ActiveStatus.activeuser;
                        User.ValidationKey = RandomSfr.Generate(10);
                        db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        response.SetErrror(CommonContant.ERROR_CODE.SECURTYERROR);
                        return View(response);

                    }

                }
            }
            catch (Exception ex)
            {

                response.SetErrror(CommonContant.ERROR_CODE.SYSTEM_ERROR);
                return View(response);

            }


            return View(response);
        }
    }
}
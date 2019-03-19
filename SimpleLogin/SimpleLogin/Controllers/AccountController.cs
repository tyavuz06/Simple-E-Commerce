using SimpleLogin.Common;
using SimpleLogin.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(Data.User user)
        {

            user.EmailConfirm = false;
            user.ActiveStatus = (int)CommonContant.ActiveStatus.pasif;
            user.Password = SimpleLogin.Common.Security.sha512encrypt(user.Password).Substring(0, 70);
            user.ValidationKey = RandomSfr.Generate(10);
            Data.SimpleData db = new Data.SimpleData();
            db.Entry(user).State = System.Data.Entity.EntityState.Added;

            try
            {
                int result = await db.SaveChangesAsync();

                //db ye kayıt edildi
                if (result == 1)
                {

                    string link = "http://localhost:58522/Activation/Activate/" + user.Email + "/" + Security.sha512encrypt(user.ValidationKey);

                    string emailFromTemplate = HelperFunction.RenderViewToString(this.ControllerContext, "~/Views/MailTemplates/UserActivation.cshtml", link);


                    //todo:  metod async yapılacak
                    Common.MailOperations.sendMailFORapp("WissenApp Kayıt", emailFromTemplate, user.Email);


                    return RedirectToAction("ActivationInfo");

                }

            }
            catch (Exception ex)
            {

                throw;
            }



            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Data.User user)
        {

            string returnUrl = Request["returnUrl"];

            LoginResponse response = new LoginResponse((int)CommonContant.LANGUAGEID.TR);
            try
            {
                using (Data.SimpleData db = new Data.SimpleData())
                {
                    string password = Security.sha512encrypt(user.Password).Substring(0, 70);
                    var User = db.Users.FirstOrDefault(t => t.Email == user.Email && t.Password == password);


                    if (User == null)
                    {
                        response.SetErrror(CommonContant.ERROR_CODE.NONACTIVEUSER);
                        return View(response);
                    }

                    if (User.ActiveStatus != (int)CommonContant.ActiveStatus.activeuser)
                    {
                        response.SetErrror(CommonContant.ERROR_CODE.NONACTIVEUSER);
                        return View(response);
                    }


                    Data.Token token = new Data.Token
                    {
                        CreateDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddHours(6),
                        TokenKey = Security.sha512encrypt(RandomSfr.Generate(20)),
                    };
                    User.Tokens.Add(token);
                    db.SaveChanges();

                    HttpCookie cok = new HttpCookie("userauth", token.TokenKey);
                    cok.Expires = DateTime.Now.AddHours(6);
                    Response.Cookies.Add(cok);

                    Session["User"] = User;

                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetErrror(CommonContant.ERROR_CODE.SYSTEM_ERROR);
            }

            return View();
        }


        public ActionResult UserLoginInfoArea()
        {

            var model = Service.LoginControl.ControlLogin();

            return PartialView("_PartialUserLoginInfoArea", model);
        }


        public ActionResult ActivationInfo()
        {

            return View();
        }

        public ActionResult Logout()
        {
            //sesionlar silindi
            Session.Abandon();

            //cookie silindi
            HttpCookie cok = new HttpCookie("userauth");
            cok.Expires = DateTime.Now;
            Response.Cookies.Add(cok);

            return RedirectToAction("Index", "Home");
        }

    }
}
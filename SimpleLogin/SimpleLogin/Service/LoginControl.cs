using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.Service
{
    public class LoginControl
    {

        public static Data.User ControlLogin()
        {

            if (HttpContext.Current.Session["User"] != null)
            {

                return (Data.User)HttpContext.Current.Session["User"];
            }




            if (HttpContext.Current.Request.Cookies["userauth"] != null)
            {
                string tokenFromCookie = HttpContext.Current.Request.Cookies["userauth"].Value;

                using (Data.SimpleData db = new Data.SimpleData())
                {
                    Data.Token token = db.Tokens.FirstOrDefault(t => t.TokenKey == tokenFromCookie && t.ExpireDate > DateTime.Now);

                    if (token != null)
                    {

                        HttpContext.Current.Session["User"] = token.User;
                        return token.User;
                    }
                }

            }

            return null;



        }


    }
}
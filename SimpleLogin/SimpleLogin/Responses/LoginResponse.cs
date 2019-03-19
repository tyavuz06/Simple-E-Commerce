using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.Responses
{
    public class LoginResponse : BaseResponse
    {
        public LoginResponse(int languageID) : base(languageID)
        {
        }

        public Data.User User { get; set; }
    }
}
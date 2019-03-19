using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin
{
    public class CommonContant
    {

        public static List<Data.Error> ErrorList = new List<Data.Error>();

        // 1-activeuser 2-ban 3-Lock 4-pasif
        public enum ActiveStatus
        {
            activeuser = 1,
            ban = 2,
            Lock = 3,
            pasif = 4

        }

        public enum LANGUAGEID
        {
            TR = 1,
            EN = 2
        }

        public const string SmtpCredentialUserName = "wissen502@outlook.com";
        public const string SmtpCredentialPassword = "Wisen502!!";


        public enum ERROR_CODE
        {
            UNDEFINEDERROR = -1,
            SUCCES = 0,
            SYSTEM_ERROR = 1,
            NONACTIVEUSER = 2,
            INVALIDUSERNAMEORPASSWORD = 3,
            SECURTYERROR = 4,
            GOURL = 5

        }

    }
}
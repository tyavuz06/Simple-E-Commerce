using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.Responses
{
    public class BaseResponse
    {

        public BaseResponse(int languageID)
        {
            this.LanguageID = languageID;
        }


        public int LanguageID { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMesseage { get; set; }

        public string GoUrl { get; set; }


        //todo :acaba bu işlem aysnc olsa ıyı olur mu??
        public void SetErrror(CommonContant.ERROR_CODE errorCode)
        {
            if (CommonContant.ErrorList.Count == 0)
            {
                Data.Error.GetAllErrorFromServer();
            }

            Data.Error error = CommonContant.ErrorList.FirstOrDefault(t => t.ErrorID == (int)errorCode && t.LanguageID == this.LanguageID);

            if (error == null)
            {
                this.ErrorCode = (int)CommonContant.ERROR_CODE.UNDEFINEDERROR;
            }

            this.ErrorCode = error.ErrorID;
            this.ErrorMesseage = error.ErrorMesseage;

        }


    }
}
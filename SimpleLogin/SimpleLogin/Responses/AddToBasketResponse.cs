using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.Responses
{
    public class AddToBasketResponse : BaseResponse
    {
        public AddToBasketResponse(int languageID) : base(languageID)
        {
        }

        public int Count { get; set; }
    }
}
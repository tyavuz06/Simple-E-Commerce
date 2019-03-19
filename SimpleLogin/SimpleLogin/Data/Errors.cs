using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.Data
{
    public class Error
    {
        public int ID { get; set; }
        public int ErrorID { get; set; }
        public string ErrorMesseage { get; set; }

        public int LanguageID { get; set; }


        /// <summary>
        /// Hatakodlarını reme alır.Constanta alır
        /// </summary>
        public static void GetAllErrorFromServer()
        {
            //Error listesi henüz cekilmemiş veya reme alınmıs ama remden yok olmus
            if (CommonContant.ErrorList.Count == 0)
            {
                using (Data.SimpleData db = new SimpleData())
                {
                    CommonContant.ErrorList = db.Errors.ToList();
                }
            }

        }


    }
}
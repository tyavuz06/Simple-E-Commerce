using SimpleLogin.FilterAttirubute;
using SimpleLogin.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult AddToBasket(int productID, int count, int color)
        {
            AddToBasketResponse response = new AddToBasketResponse(1);


            DataClasses.Order order = null;
            //adamın zaten sepeti
            if (Session["sepet"] != null)
            {
                order = (Session["sepet"] as DataClasses.Order);

            }
            else
            {
                order = new DataClasses.Order();
            }


            Data.Product p = new Data.Product
            {
                ID = new Random().Next(1, 100),
                Name = Common.RandomSfr.Generate(20),
                Price = new Random().Next(10000, 200000)

            };
            order.Items.Add(new DataClasses.OrderItem
            {
                Product = p,
                Count = count,
                Color = color
            });

            Session["sepet"] = order;

            response.SetErrror(CommonContant.ERROR_CODE.SUCCES);
            response.Count = order.Items.Sum(t => t.Count);
            return Json(response);
        }


        public ActionResult GetUserBasketTop()
        {
            DataClasses.Order order = new DataClasses.Order();
            //adamın zaten sepeti
            if (Session["sepet"] != null)
            {
                order = (Session["sepet"] as DataClasses.Order);
            }

            return PartialView("_PartialUserBasketTop", order.Items.Count);
        }

        public ActionResult OpenBasketPoup(int id)
        {

            AddToBasketResponse response = new AddToBasketResponse((int)CommonContant.LANGUAGEID.TR);


            var User = Service.LoginControl.ControlLogin();

            if (User == null)
            {
                // kullanıcı login değil

                response.SetErrror(CommonContant.ERROR_CODE.GOURL);
                response.GoUrl = "/Account/Login";

                return Json(response);

            }

            return PartialView("_PartialBasketPoup");

        }
    }
}
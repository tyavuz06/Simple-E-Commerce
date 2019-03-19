using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.DataClasses
{
    public class Order
    {
        public Data.User User { get; set; }

        public List<OrderItem> Items = new List<OrderItem>();
        public byte Status { get; set; }
    }

    public class OrderItem
    {

        public Data.Product Product { get; set; }

        public int Count { get; set; }


        public int Color { get; set; }
    }
}
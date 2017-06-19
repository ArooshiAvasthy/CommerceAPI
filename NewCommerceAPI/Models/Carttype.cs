using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCommerceAPI.Models
{
    public class Carttype
    {
        public int CartID { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string PaidStatus { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public Producttype Product { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }
        public string VideoPath { get; set; }
    }
}
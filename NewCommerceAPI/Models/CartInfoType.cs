using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCommerceAPI.Models
{
    public class CartInfoType
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
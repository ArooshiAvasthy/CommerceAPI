using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCommerceAPI.Models
{
    public class FinalOrdertype
    {
        public int FinalOrderID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> SumQuantity { get; set; }
        public Nullable<int> SumPrice { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
    }
}
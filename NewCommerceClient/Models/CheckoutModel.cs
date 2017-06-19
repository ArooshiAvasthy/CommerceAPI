using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCommerceClient.Models
{
    public class CheckoutModel
    {
        public int OrderID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SumQuantity { get; set; }
        public Nullable<int> SumPrice { get; set; }
        public string ApprovedStatus { get; set; }
    }
}
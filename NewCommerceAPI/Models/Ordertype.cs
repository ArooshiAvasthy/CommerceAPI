using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCommerceAPI.Models
{
    public class Ordertype
    {
        public int OrderID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SumQuantity { get; set; }
        public Nullable<int> SumPrice { get; set; }
        public string ApprovedStatus { get; set; }
    
    }
}
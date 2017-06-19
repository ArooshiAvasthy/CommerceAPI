using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCommerceClient.Models
{
    public class ProductModel
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public CategoryModel Category { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Price { get; set; }
        public Nullable<int> QuantityAvailable { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }

    }
}
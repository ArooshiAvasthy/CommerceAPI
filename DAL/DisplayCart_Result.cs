//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    
    public partial class DisplayCart_Result
    {
        public int CartID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public string PaidStatus { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string ProductName { get; set; }
    }
}

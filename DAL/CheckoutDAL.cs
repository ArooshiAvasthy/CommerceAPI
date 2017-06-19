using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
    public class CheckoutDAL : ICheckout
    {
        //NewCommerceEntities obj = new NewCommerceEntities();


        public List<Order> ProceedTOCheckout(string Username)
        {
            using (NewCommerceEntities obj = new NewCommerceEntities())
            {
                var userParam = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = Username
                };

                var order = obj.Orders.SqlQuery("exec Checkout @Name", userParam).ToList<Order>();
                return order;
            }
        }



        public List<FinalOrder> FinalBuy(int id)
        {
            using (NewCommerceEntities obj = new NewCommerceEntities())
            {
                var FinalID = new SqlParameter
                {
                    ParameterName = "ID",
                    Value = id
                };

                var record = obj.FinalOrders.SqlQuery("exec FinalBuy @ID", FinalID).ToList<FinalOrder>();
                return record;
            }
        }


        public void deleteOrder(int id)
        {
            using (NewCommerceEntities obj = new NewCommerceEntities())
            {
                var receipt = (from c in obj.Orders
                               where c.OrderID == id
                               select c).First();
                obj.Orders.Remove(receipt);
                //obj.Entry(receipt).State = System.Data.Entity.EntityState.Deleted;
                obj.SaveChanges();
            }

        }

        public Order getOrder(int id)
        {
            using (NewCommerceEntities obj = new NewCommerceEntities())
            {
                var receipt = (from c in obj.Orders
                               where c.OrderID == id
                               select c).First();
                return receipt;

            }
        }


   
        public List<Order> DisplayCheckout(string Username)
        {
            using (NewCommerceEntities obj = new NewCommerceEntities())
            {
                var userParam = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = Username
                };

                var order = obj.Orders.SqlQuery("exec DisplayCheckout @Name", userParam).ToList<Order>();
                return order;
            }
        }
    }
}

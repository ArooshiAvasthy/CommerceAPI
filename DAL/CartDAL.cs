using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CartDAL: ICart
    {
        NewCommerceEntities obj = new NewCommerceEntities();
        public List<Cart> DisplayCart(string name)
        {
            //using (NewCommerceEntities obj = new NewCommerceEntities())
            //{
                var userParam = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = name,
                    //Value = Username
                };

                var cartList = obj.Carts.SqlQuery("exec DisplayCart @Name", userParam).ToList<Cart>();
                return cartList;
           // }
        }

        //public List<Cart> AddToCart(string Title,int Quantity)
        public void AddToCart(string Title, int Quantity, string Username)
        {
            //using (NewCommerceEntities obj = new NewCommerceEntities())
            //{
                var titleParam = new SqlParameter
                {
                    ParameterName = "Title",
                    Value = Title,
                };
                var QuantityParam = new SqlParameter
                {
                    ParameterName = "Quantity",
                    Value = Quantity,
                };
                var userParam = new SqlParameter
                {
                    ParameterName = "Name",
                    
                    Value = Username
                };

                var query = obj.Carts.SqlQuery("EXEC AddToCart  @Title, @Name,@Quantity", titleParam, userParam, QuantityParam).ToList<Cart>();
                //return query.Count();
           // }

        }

        public List<Cart> AddToCartDisplay(string Username)
        {
            //using (NewCommerceEntities obj = new NewCommerceEntities())
            //{
               
                var userParam = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = Username
                };

                var query = obj.Carts.SqlQuery("EXEC AddToCartDisplay  @Name",userParam).ToList<Cart>();
                return query;
          //  }

        }





        public void GetClearItem(int id)
        {
            var record = (from c in obj.Carts
                          where c.CartID == id
                          select c).FirstOrDefault();
            obj.Carts.Remove(record);
            obj.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class HomeDAL:IHome
    {
        NewCommerceEntities homeObj = new NewCommerceEntities();
        public List<Product> DisplayAllProducts()
        
        {
            using (NewCommerceEntities homeObj2 = new NewCommerceEntities())
            {

                var productList = homeObj.Products.SqlQuery("exec DisplayAllProducts").ToList<Product>();
                return productList;


                //tset
                //var data = homeObj.DisplayAllProducts();
                //var data2 = data.ToList();
                //List<Product> list = new List<Product>();
                
                //foreach(var item in data2)
                //{
                //    list.Add(item);
                //}
                //return data2;
                
               // var data2 = data.ToList<Product>();
                //return productList;
            }

        }

        public List<Product> DisplayProductsByCategory(string CategoryName)
        {
            
                var idParam = new SqlParameter
                {
                    ParameterName = "Category",
                    Value = CategoryName
                };

                var productList = homeObj.Products.SqlQuery("exec DisplayProduct_ByCategory @Category", idParam).ToList<Product>();
                return productList;
            
        }

        public int GetQuantity(string name)
        {
            //using (NewCommerceEntities homeObj = new NewCommerceEntities())
            //{
                var number = (from c in homeObj.Products
                              where c.ProductName == name
                              select c.QuantityAvailable).FirstOrDefault();

                return Convert.ToInt32(number);
            //}
        }



        public MovieList GetMovie(string movie)
        {
            var data = (from c in homeObj.MovieLists
                        where c.Title == movie
                        select c).FirstOrDefault();

            return data;
        }
    }
}

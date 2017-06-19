using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using AutoMapper;
using NewCommerceAPI.Models;
using System.Web.Http.Cors;

namespace NewCommerceAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CartAPIController : ApiController
    {
        ICart cartObj = new CartDAL();

        [Route("api/cartapi/getdisplaycart/{name}")]
        public List<Carttype> GetDisplayCart(string name)
        {
            var list = cartObj.DisplayCart(name);
            List<Carttype> serviceList = new List<Carttype>();

            if (list.Any())
            {

                Mapper.Initialize(cfg => { cfg.CreateMap<Cart, Carttype>(); cfg.CreateMap<Product, Producttype>(); cfg.CreateMap<Category, Categorytype>(); });
                foreach (var item in list)
                {
                    Carttype userModel = Mapper.Map<Cart, Carttype>(item);
                    userModel.Product.ProductName = item.Product.ProductName;
                    userModel.ProductName = item.Product.ProductName;
                    userModel.ImagePath = item.Product.ImagePath;
                    userModel.ImagePath2 = item.Product.ImagePath2;
                    userModel.VideoPath = item.Product.VideoPath;
                    serviceList.Add(userModel);

                }
            }

            return serviceList;

        }

        /// <summary>
        /// Add to Cart- POST & GET
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Quantity"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        [Route("api/cartapi/GetAddItem/{Username}")]
        public List<Carttype> GetAddItem(string Username)
        {

            var list = cartObj.AddToCartDisplay(Username);
            List<Carttype> serviceList = new List<Carttype>();

            
            if (list.Any())
            {
             
                Mapper.Initialize(cfg => { cfg.CreateMap<Cart,Carttype>(); cfg.CreateMap<Product, Producttype>(); cfg.CreateMap<Category, Categorytype>(); });
                foreach (var item in list)
                {
                    Carttype userModel = Mapper.Map<Cart, Carttype>(item);
                    userModel.Product.ProductName = item.Product.ProductName;
                    userModel.ProductName = item.Product.ProductName;
                    userModel.ImagePath = item.Product.ImagePath;
                    userModel.ImagePath2 = item.Product.ImagePath2;
                    userModel.VideoPath = item.Product.VideoPath;
                    serviceList.Add(userModel);

                }
            }

            return serviceList;

        }

       [HttpPost]
       [Route("api/cartapi/PostAddItem")]
        public void PostAddItem([FromBody]CartInfoType infobj)
        {
           
           cartObj.AddToCart(infobj.Title, infobj.Quantity, infobj.Name);
           
        }

        [Route("api/cartapi/GetClearItem/{id:int}")]
        public void GetClearItem(int id)
        {
           
           cartObj.GetClearItem(id);
           
        }
    }
}

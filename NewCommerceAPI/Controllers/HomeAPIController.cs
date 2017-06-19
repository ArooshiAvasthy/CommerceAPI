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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeAPIController : ApiController
    {
        IHome homeObj = new HomeDAL();

        
       // [ActionName("DefaultAction")]
        [Route("api/homeapi/GetDisplayAllProducts")]
        public List<Producttype> GetDisplayAllProducts()
        {
            try
            {
                var list = homeObj.DisplayAllProducts();
                var serviceList = new List<Producttype>();


                Mapper.Initialize(cfg => { cfg.CreateMap<Product, Producttype>(); });
                if (list.Any())
                {
                    Mapper.Initialize(cfg => { cfg.CreateMap<Category, Categorytype>(); cfg.CreateMap<Product, Producttype>(); });
                    foreach (var item in list)
                    {
                        Producttype userModel =
                          Mapper.Map<Product,Producttype>(item);
                        userModel.Category.CategoryName = item.Category.CategoryName;
                        serviceList.Add(userModel);
                    }
                }


                return serviceList;
            }

            catch (Exception ex)
            {
                throw ex;
            }
           
      }

        [HttpGet]
        [Route("api/homeapi/GetDisplayProductsByCategory/{CategoryName}")]
        public List<Producttype> GetDisplayProductsByCategory(string CategoryName)
        {
            var list = homeObj.DisplayProductsByCategory(CategoryName);
            var serviceList = new List<Producttype>();


            Mapper.Initialize(cfg => { cfg.CreateMap<Product, Producttype>(); });
            if (list.Any())
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<Category, Categorytype>(); cfg.CreateMap<Product, Producttype>(); });
                foreach (var item in list)
                {
                    Producttype userModel =
                      Mapper.Map<Product, Producttype>(item);
                    userModel.Category.CategoryName = item.Category.CategoryName;
                    serviceList.Add(userModel);
                }
            }


            return serviceList;
        }

        [HttpGet]
        [Route("api/homeapi/GetQuantity/{name}")]
        public int GetQuantity(string name)
        {
            int Quantity = homeObj.GetQuantity(name);
            return Quantity;
        }

        [HttpGet]
        [Route("api/homeapi/GetMovie/{movie}")]
        public ImdbEntityType GetMovie(string movie)
        {
            MovieList data = homeObj.GetMovie(movie);

            Mapper.Initialize(cfg => cfg.CreateMap<MovieList, ImdbEntityType>());

            ImdbEntityType list = Mapper.Map<MovieList, ImdbEntityType>(data);
            return list;
        }
    }
}

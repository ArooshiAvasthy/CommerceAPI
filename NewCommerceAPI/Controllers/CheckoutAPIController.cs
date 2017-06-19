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
    public class CheckoutAPIController : ApiController
    {
        ICheckout checkOBj = new CheckoutDAL();

        [HttpGet]
        [Route("api/checkoutapi/GETProceedTOCheckout/{Username}")]
        public List<Ordertype> GETProceedTOCheckout(string Username)
        {
            var list = checkOBj.ProceedTOCheckout(Username);
            List<Ordertype> serviceList = new List<Ordertype>();

            Mapper.Initialize(cfg => { cfg.CreateMap<Order, Ordertype>(); });

            if (list != null)
            {
                foreach (var item in list)
                {

                    Ordertype itemModel = Mapper.Map<Order, Ordertype>(item);
                    serviceList.Add(itemModel);
                }
            }

            return serviceList;
        }




        [Route("api/CheckoutAPI/GETFinalBuy/{id:int}")]
        public List<FinalOrdertype> GETFinalBuy(int id)
        {

            var list = checkOBj.FinalBuy(id);
            List<FinalOrdertype> serviceList = new List<FinalOrdertype>();

            Mapper.Initialize(cfg => { cfg.CreateMap<FinalOrder, FinalOrdertype>(); });

            if (list != null)
            {
                foreach (var item in list)
                {

                    FinalOrdertype itemModel = Mapper.Map<FinalOrder, FinalOrdertype>(item);
                    serviceList.Add(itemModel);
                }
            }

            return serviceList;
        }

        [Route("api/checkoutapi/getOrder/{id:int}")]
        public Ordertype getOrder(int id)
        {
            var list = checkOBj.getOrder(id);

            Mapper.Initialize(cfg => cfg.CreateMap<Order, Ordertype>());

            Ordertype userModel =
            Mapper.Map<Order, Ordertype>(list);

            //  return View(delRecord);
            return userModel;
        }

        [Route("api/checkoutapi/postdeleteOrder/{id:int}")]
        public void postdeleteOrder(int id)
        {
            checkOBj.deleteOrder(id);
        }


        [HttpGet]
        [Route("api/CheckoutAPI/GETDisplayCheckout/{Username}")]
        public List<Ordertype> GETDisplayCheckout(string Username)
        {
            var list = checkOBj.DisplayCheckout(Username);
            List<Ordertype> serviceList = new List<Ordertype>();

            Mapper.Initialize(cfg => { cfg.CreateMap<Order, Ordertype>(); });

            if (list != null)
            {
                foreach (var item in list)
                {

                    Ordertype itemModel = Mapper.Map<Order, Ordertype>(item);
                    serviceList.Add(itemModel);
                }
            }

            return serviceList;
        }
    }
}

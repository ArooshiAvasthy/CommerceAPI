using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NewCommerceClient.Models;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace NewCommerceClient.Controllers
{
    public class CartController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (Session["Name"] == null)
            {
                return View("PleaseLogin");
            }
            else
            {
                string name = Session["Name"].ToString();

                string apiUrl = "http://localhost:51499/api/cartapi/getdisplaycart/" + name;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();

                        if (data.Length>2)
                        {
                            JavaScriptSerializer oJS = new JavaScriptSerializer();
                            List<CartModel> obj = new List<CartModel>();
                            obj = oJS.Deserialize<List<CartModel>>(data);
                            return View(obj);
                        }

                        else
                        {
                            return View("Proceed");
                        }

                    }

                    else
                        return View("Error");
                }
            }
        }



        [HttpGet]
        public async Task<ActionResult> DisplayRecentCartItem()
        {
            try
            {
                string name = Session["Name"].ToString();
                string apiUrl = "http://localhost:51499/api/cartapi/GetAddItem/" + name;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();

                        JavaScriptSerializer oJS = new JavaScriptSerializer();
                        List<CartModel> cart = new List<CartModel>();
                        cart = oJS.Deserialize<List<CartModel>>(data);
                        //cart = oJS.Deserialize<List<ProductModel>>(data); 
                        return View(cart);


                    }

                    else
                        return View("Error");
                }
            }
           
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //Post
        [HttpPost]
       
        public async Task<ActionResult> AddToCart(ImdEntity obj, FormCollection collection)
        {
            try
            {
                string Title = obj.Title;
                string name = Session["Name"].ToString();
                var quantity = collection["dropdown"];
                //int num = Convert.ToInt32(quantity.ToString());
                if (quantity.ToString()=="")
                {
                    return View("QuantityPlease");
                }
                else
                {

                    string apiUrl = "http://localhost:51499/api/cartapi/PostAddItem";
                    CartInfo infobj = new CartInfo();
                    infobj.Name = name;
                    infobj.Quantity = Convert.ToInt32(quantity);
                    infobj.Title = Title;

                    using (HttpClient client = new HttpClient())
                    {
                        //client.BaseAddress = new Uri(apiUrl);
                        //client.DefaultRequestHeaders.Accept.Clear();
                        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        ////var response = await HttpClient.PostAsJsonAsync(requestUri, content);


                        var response = await client.PostAsJsonAsync(apiUrl, infobj);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("DisplayRecentCartItem");
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                }
            }
           

            catch(Exception ex)
            {
                throw ex;
            }

        }


        public async Task<FilePathResult> Download(string videopath, string title, string id)
        {

            int cartId = Convert.ToInt32(id);
            string titlemain = title + ".mp4";
            string filepath = videopath;
            string contentType = "application/mp4";
            string apiUrl = "http://localhost:51499/api/cartapi/GetClearItem/" + cartId;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
            }
            return File(filepath, contentType, titlemain);
        }
    
	}
}
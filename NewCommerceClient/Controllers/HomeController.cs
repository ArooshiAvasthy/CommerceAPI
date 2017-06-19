using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NewCommerceClient.Models;

namespace NewCommerceClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// Get complete list of products
        /// </summary>
        /// <returns></returns>
        /// 
        ///Display Category Icons
        public ActionResult Index()
        {
            return View();
        }

        //Gets all the movie List
        public async Task<ActionResult> AllMoviePage()
        {

            string apiUrl = "http://localhost:51499/api/homeapi/GetDisplayAllProducts";

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
                    List<ProductModel> obj = new List<ProductModel>();
                    obj = oJS.Deserialize<List<ProductModel>>(data);
                    return View(obj);


                }

                else
                    return View("Error");
            }
        }

        public async Task<ActionResult> DisplayProduct_ByCategory(string CategoryName)
        {
            string apiUrl = "http://localhost:51499/api/homeapi/GetDisplayProductsByCategory/" + CategoryName;

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
                    List<ProductModel> obj = new List<ProductModel>();
                    obj = oJS.Deserialize<List<ProductModel>>(data);
                    return View(obj);

                }

                else
                    return View("Error");
            }
        }


	}
}
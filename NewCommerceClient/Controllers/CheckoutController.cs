using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NewCommerceClient.Models;
using System.Net.Http.Headers;

namespace NewCommerceClient.Controllers
{
    public class CheckoutController : Controller
    {
        
        public async Task<ActionResult> Checkout()
        {
            //var orderlist = obj.ProceedTOCheckout();
            string name = Session["Name"].ToString();
            string apiUrl = "http://localhost:51499/api/CheckoutAPI/GETProceedTOCheckout/"+name;
          
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
                    List<CheckoutModel> obj = new List<CheckoutModel>();
                    obj = oJS.Deserialize<List<CheckoutModel>>(data);
                    return View(obj);


                }

                else
                    return View("Error");
            }
        }


     
        //
        // GET: /Checkout/Details/5

        //
        // GET: /Checkout/Edit/5

        public async Task<ActionResult> FinalBuy(int id)
        {
            try
            {


                //string name = Session["Name"].ToString();
                string apiUrl = "http://localhost:51499/api/CheckoutAPI/GETFinalBuy/" + id;

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
                        List<ReceiptModel> obj = new List<ReceiptModel>();
                        obj = oJS.Deserialize<List<ReceiptModel>>(data);
                        return View(obj);


                    }

                    else
                        return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        //
        // POST: /Checkout/Edit/5

  
        //
        // GET: /Checkout/Delete/5

        public async Task<ActionResult> Delete(int id)
        {
            
            string apiUrl = "http://localhost:51499/api/CheckoutAPI/getOrder/" + id;

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
                    CheckoutModel obj = new CheckoutModel();
                    obj = oJS.Deserialize<CheckoutModel>(data);
                    return View(obj);


                }

                else
                    return View("Error");
            }
        }


        //Delete not working
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                string apiUrl = "http://localhost:51499/api/checkoutapi/postdeleteOrder/"+id;
              

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(apiUrl, id);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("DisplayCheckout", "Checkout");
                    }

                    else
                        return RedirectToAction("Error");
                }
      
               
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DisplayCheckout()
        {
            //var orderlist = obj.ProceedTOCheckout();
            string name = Session["Name"].ToString();
            string apiUrl = "http://localhost:51499/api/CheckoutAPI/GETDisplayCheckout/" + name;

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
                    List<CheckoutModel> obj = new List<CheckoutModel>();
                    obj = oJS.Deserialize<List<CheckoutModel>>(data);
                    return View(obj);


                }

                else
                    return View("Error");
            }
        }
	}
}
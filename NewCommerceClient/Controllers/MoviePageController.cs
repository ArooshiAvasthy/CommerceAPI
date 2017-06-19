using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NewCommerceClient.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewCommerceClient.Controllers
{
    public class MoviePageController : Controller
    {
        public async Task<ActionResult> MovieReview(string name)
        {

             using (HttpClient client = new HttpClient())
             {

                //get Quantity
                List<SelectListItem> QuantityList = new List<SelectListItem>();

                 string apiUrl = "http://localhost:51499/api/HomeAPI/GetQuantity/" + name;
                  client.BaseAddress = new Uri(apiUrl);
                  client.DefaultRequestHeaders.Accept.Clear();
                  client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                  HttpResponseMessage response = await client.GetAsync(apiUrl);
                  if (response.IsSuccessStatusCode)
                  {
                      var data = await response.Content.ReadAsStringAsync();

                      JavaScriptSerializer oJ = new JavaScriptSerializer();
                      int quantity = oJ.Deserialize<int>(data);           

                      for (int i = 1; i <= quantity; i++)
                      {
                          QuantityList.Add(new SelectListItem { Text = i.ToString() });

                      }
                      TempData["dropdownQTy"] = QuantityList;

                  }
             }

             using (HttpClient client = new HttpClient())
             {

                  //Get Movie Data 
                  string movieapiUrl = "http://localhost:51499/api/HomeAPI/GetMovie/" + name;
                  client.BaseAddress = new Uri(movieapiUrl);
                  client.DefaultRequestHeaders.Accept.Clear();
                  client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                  HttpResponseMessage response2 = await client.GetAsync(movieapiUrl);
                  if (response2.IsSuccessStatusCode)
                  {
                      var data = await response2.Content.ReadAsStringAsync();

                      JavaScriptSerializer oJS = new JavaScriptSerializer();
                      ImdEntity obj = new ImdEntity();
                      obj = oJS.Deserialize<ImdEntity>(data);
                      return View(obj);

                  }

                  else
                      return View("Error");

             }
               // return View(obj);
              
        }

    }
        
  }

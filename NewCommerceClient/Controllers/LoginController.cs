using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using NewCommerceClient.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewCommerceClient.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
     

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string Name,string Password)
        {
            //PutAsjsonAsync username and password and verify
            Session["UserName"] = Name;
            Session["Password"] = Password;
            Session["Login"] = null;
            Session["Name"] = null;

            return RedirectToAction("Authorization");
        }

        public ActionResult Authorization()
        {
            if (Session["UserName"] != null && Session["Password"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("InvalidCredentials");
            }
        }
        public ActionResult InvalidCredentials()
        {
            return View();
        }

        //[WebMethod(EnableSession = true)]
        public void SetSession()
        {
            Session["Login"] = "Success";
            Session["Name"] = Session["UserName"];
        }

        public ActionResult Logout ()
        {
            Session["UserName"] = null;
            Session["Password"] = null;
            Session["Login"] = null;
            Session["Name"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserModel usermodel)
        {

            try
            {

                string apiUrl = "http://localhost:51499/api/loginapi/PostNewUser/";


                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(apiUrl,usermodel);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("SignUp", "Login");
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
	}
}
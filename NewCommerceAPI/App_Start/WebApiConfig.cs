using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NewCommerceAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var cors = new System.Web.Http.Cors.EnableCorsAttribute("http://localhost:64374/", "*", "*");
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            //config.EnableCors();
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            //Custom Configs:1
            config.Routes.MapHttpRoute(
                 name: "CustomApi",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {  id = RouteParameter.Optional }
            );

            
            //action = "DefaultAction",
         
           
         
        }
    }
}

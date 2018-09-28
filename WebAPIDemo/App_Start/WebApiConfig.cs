﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Http;
//using System.Web.Http.Cors;

//namespace WebAPIDemo
//{
//    public static class WebApiConfig
//    {
//        public static void Register(HttpConfiguration config)
//        {
//            // Web API configuration and services

//            // Web API routes
//            config.MapHttpAttributeRoutes();

//            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
//            config.EnableCors(cors);

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );
//        }
//    }
//}


using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}


//using Newtonsoft.Json.Serialization;
//using System.Linq;
//using System.Net.Http.Formatting;
//using System.Web.Http;
//using System.Web.Http.Cors;

//namespace WebAPIDemo
//{
//    public class WebApiConfig
//    {
//        public static void Register(HttpConfiguration config)
//        {
//            // Web API configuration and services  

//            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
//            config.EnableCors(cors);

//            // Web API routes  
//            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );

//            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
//            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//        }
//    }
//}

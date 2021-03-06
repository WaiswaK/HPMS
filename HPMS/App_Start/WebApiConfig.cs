﻿using System.Web.Http;

namespace HPMS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Enforce HTTPS
            //config.Filters.Add(new HPMS.Filters.RequireHttpsAttribute());
        }
    }
}

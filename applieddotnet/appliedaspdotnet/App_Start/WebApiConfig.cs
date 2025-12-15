using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using appliedaspdotnet.program;

namespace appliedaspdotnet
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

            config.Routes.MapHttpRoute(
            name: "Route2",
            routeTemplate: "api2/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional },
            constraints: null,
            handler: new apikeyhandler("bangbang")  // per-route message handler
        );

            config.MessageHandlers.Add(new customheaderhandler());  // global message handler
        }
    }
}

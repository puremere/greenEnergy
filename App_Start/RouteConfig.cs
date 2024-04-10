using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace greenEnergy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "login", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default0",
                url: "{first}/{second}",
                defaults: new { controller = "Home", action = "page", first = "", second ="" }
            );
           
        }
    }
}

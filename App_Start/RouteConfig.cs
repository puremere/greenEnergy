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
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "Default0",
            //    url: "portal/{action}/{id}",
            //    defaults: new { controller = "portal", action = "login", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
            name: "Default5",
            url: "webapp/{action}/{id}",
            defaults: new { controller = "webapp", action = "splash", id = UrlParameter.Optional }
        );
            routes.MapRoute(
             name: "Default4",
             url: "admin/{action}/{id}",
             defaults: new { controller = "admin", action = "login", id = UrlParameter.Optional }
         );
            routes.MapRoute(
              name: "Default3",
              url: "portal/{action}/{id}",
              defaults: new { controller = "portal", action = "login", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "Default2",
               url: "panel/{action}/{id}",
               defaults: new { controller = "panel", action = "login", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Default00",
              url: "home/{action}/{id}",
              defaults: new { controller = "Home", action = UrlParameter.Optional, id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Default0",
              url: "{first}/{second}/{third}",
              defaults: new { controller = "Home", action = "page", first = UrlParameter.Optional, second = UrlParameter.Optional, third = UrlParameter.Optional }
          );




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace dyplomowaApka00
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Lutynia",
                url: "lutynia",
                defaults: new { controller = "Inwestycje", action = "Details", id = 1 }
            );

            routes.MapRoute(
                name: "Krzeptów",
                url: "krzeptow",
                defaults: new { controller = "Inwestycje", action = "Details", id = 2 }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Id",
                "photo/{id}",
                new { controller = "Photo", action = "Details" },
                new { id = @"[0-9]+"}
                );
            
            routes.MapRoute("Title",
                "photo/{title}",
                new { controller = "Photo", action = "Title" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
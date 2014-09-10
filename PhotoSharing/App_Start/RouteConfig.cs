using MvcCodeRouting;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapCodeRoutes(
            rootController: typeof(Controllers.HomeController),
            settings: new CodeRoutingSettings { UseImplicitIdToken = true }
        );
        }
    }
}
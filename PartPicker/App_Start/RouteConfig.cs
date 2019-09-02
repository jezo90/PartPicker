using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PartPicker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BuildsList",
                url: "Builds/{cpuM}/{cpuS}",
                defaults: new { controller = "Builds", action = "List", cpuM = UrlParameter.Optional, cpuS = UrlParameter.Optional});

            routes.MapRoute(
                name: "Static",
                url: "{name}",
                defaults: new { controller = "Home", action = "Static" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

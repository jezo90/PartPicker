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
                name: "CpuDetails",
                url: "Cpu/{name}15{id}38",
                defaults: new { controller = "Cpu", action = "Details", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "BuildsDetails",
                url: "Builds/{name}15{id}38",
                defaults: new { controller = "Builds", action = "Details", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Builds",
                url: "Builds",
                defaults: new { controller = "Builds", action = "List"});

            routes.MapRoute(
                name: "Static",
                url: "{name}",
                defaults: new { controller = "Home", action = "Static" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}

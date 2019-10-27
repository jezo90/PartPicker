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
                name: "NewBuild",
                url: "NewBuild",
                defaults: new { controller = "NewBuild", action = "Index" });
            // CPU
            routes.MapRoute(
                name: "DeleteCpuFromNewBuild",
                url: "NewBuild/delete-cpu",
                defaults: new { controller = "NewBuild", action = "DeleteCpuFromBuild" });

            routes.MapRoute(
                name: "AddCpuToNewBuild",
                url: "NewBuild/cpu-{id}",
                defaults: new { controller = "NewBuild", action = "AddCpuToBuild", id = UrlParameter.Optional });
            // GPU
            routes.MapRoute(
                name: "DeleteGpuFromNewBuild",
                url: "NewBuild/delete-gpu",
                defaults: new { controller = "NewBuild", action = "DeleteGpuFromBuild" });

            routes.MapRoute(
                name: "AddGpuToNewBuild",
                url: "NewBuild/gpu-{id}",
                defaults: new { controller = "NewBuild", action = "AddGpuToBuild", id = UrlParameter.Optional });
            // MOBO
            routes.MapRoute(
                name: "DeleteMoboFromNewBuild",
                url: "NewBuild/delete-mobo",
                defaults: new { controller = "NewBuild", action = "DeleteMoboFromBuild" });

            routes.MapRoute(
                name: "AddMoboToNewBuild",
                url: "NewBuild/mobo-{id}",
                defaults: new { controller = "NewBuild", action = "AddMoboToBuild", id = UrlParameter.Optional });
            // RAM
            routes.MapRoute(
                name: "DeleteRamFromNewBuild",
                url: "NewBuild/delete-ram",
                defaults: new { controller = "NewBuild", action = "DeleteRamFromBuild" });

            routes.MapRoute(
                name: "AddRamToNewBuild",
                url: "NewBuild/ram-{id}",
                defaults: new { controller = "NewBuild", action = "AddRamToBuild", id = UrlParameter.Optional });
            // PSU
            routes.MapRoute(
                name: "DeletePsuFromNewBuild",
                url: "NewBuild/delete-psu",
                defaults: new { controller = "NewBuild", action = "DeletePsuFromBuild" });

            routes.MapRoute(
                name: "AddPsuToNewBuild",
                url: "NewBuild/psu-{id}",
                defaults: new { controller = "NewBuild", action = "AddPsuToBuild", id = UrlParameter.Optional });
            // STORAGE
            routes.MapRoute(
                name: "DeleteStorageFromNewBuild",
                url: "NewBuild/delete-storage",
                defaults: new { controller = "NewBuild", action = "DeleteStorageFromBuild" });

            routes.MapRoute(
                name: "AddStorageToNewBuild",
                url: "NewBuild/storage-{id}",
                defaults: new { controller = "NewBuild", action = "AddStorageToBuild", id = UrlParameter.Optional });
            // CASE
            routes.MapRoute(
                name: "DeleteCaseFromNewBuild",
                url: "NewBuild/delete-case",
                defaults: new { controller = "NewBuild", action = "DeleteCaseFromBuild" });

            routes.MapRoute(
                name: "AddCaseToNewBuild",
                url: "NewBuild/case-{id}",
                defaults: new { controller = "NewBuild", action = "AddCaseToBuild", id = UrlParameter.Optional });


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

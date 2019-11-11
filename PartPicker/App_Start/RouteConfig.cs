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
                name: "CaseDetails",
                url: "obudowy/{name}-{id}",
                defaults: new { controller = "Case", action = "CaseDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Cases",
                url: "obudowy",
                defaults: new { controller = "Case", action = "CaseList" });

            routes.MapRoute(
                name: "PsuDetails",
                url: "zasilacze/{name}-{id}",
                defaults: new { controller = "Psu", action = "PsuDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Psus",
                url: "zasilacze",
                defaults: new { controller = "Psu", action = "PsuList" });

            routes.MapRoute(
                name: "RamDetails",
                url: "ram/{name}-{id}",
                defaults: new { controller = "Ram", action = "RamDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Rams",
                url: "ram",
                defaults: new { controller = "Ram", action = "RamList" });

            routes.MapRoute(
                name: "StorageDetails",
                url: "dyski-twarde/{name}-{id}",
                defaults: new { controller = "Storage", action = "StorageDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Storages",
                url: "dyski-twarde",
                defaults: new { controller = "Storage", action = "StorageList" });

            routes.MapRoute(
                name: "MoboDetails",
                url: "plyty-glowne/{name}-{id}",
                defaults: new { controller = "Mobo", action = "MoboDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Mobos",
                url: "plyty-glowne",
                defaults: new { controller = "Mobo", action = "MoboList" });

            routes.MapRoute(
                name: "GpuDetails",
                url: "karty-graficzne/{name}-{id}",
                defaults: new { controller = "Gpu", action = "GpuDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Gpus",
                url: "karty-graficzne",
                defaults: new { controller = "Gpu", action = "GpuList" });

            routes.MapRoute(
                name: "CpuDetails",
                url: "procesory/{name}-{id}",
                defaults: new { controller = "Cpu", action = "CpuDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Cpus",
                url: "procesory",
                defaults: new { controller = "Cpu", action = "CpuList" });

            routes.MapRoute(
                name: "BuildsDetails",
                url: "buildy/{name}-{id}",
                defaults: new { controller = "Builds", action = "BuildsDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Builds",
                url: "buildy",
                defaults: new { controller = "Builds", action = "List" });


            routes.MapRoute(
                name: "NewBuild",
                url: "nowy-build",
                defaults: new { controller = "NewBuild", action = "Index" });
            // CPU
            routes.MapRoute(
                name: "DeleteCpuFromNewBuild",
                url: "nowy-build/delete-cpu",
                defaults: new { controller = "NewBuild", action = "DeleteCpuFromBuild" });

            routes.MapRoute(
                name: "AddCpuToNewBuild",
                url: "nowy-build/cpu-{id}",
                defaults: new { controller = "NewBuild", action = "AddCpuToBuild", id = UrlParameter.Optional });
            // GPU
            routes.MapRoute(
                name: "DeleteGpuFromNewBuild",
                url: "nowy-build/delete-gpu",
                defaults: new { controller = "NewBuild", action = "DeleteGpuFromBuild" });

            routes.MapRoute(
                name: "AddGpuToNewBuild",
                url: "nowy-build/gpu-{id}",
                defaults: new { controller = "NewBuild", action = "AddGpuToBuild", id = UrlParameter.Optional });
            // MOBO
            routes.MapRoute(
                name: "DeleteMoboFromNewBuild",
                url: "nowy-build/delete-mobo",
                defaults: new { controller = "NewBuild", action = "DeleteMoboFromBuild" });

            routes.MapRoute(
                name: "AddMoboToNewBuild",
                url: "nowy-build/mobo-{id}",
                defaults: new { controller = "NewBuild", action = "AddMoboToBuild", id = UrlParameter.Optional });
            // RAM
            routes.MapRoute(
                name: "DeleteRamFromNewBuild",
                url: "nowy-build/delete-ram",
                defaults: new { controller = "NewBuild", action = "DeleteRamFromBuild" });

            routes.MapRoute(
                name: "AddRamToNewBuild",
                url: "nowy-build/ram-{id}",
                defaults: new { controller = "NewBuild", action = "AddRamToBuild", id = UrlParameter.Optional });
            // PSU
            routes.MapRoute(
                name: "DeletePsuFromNewBuild",
                url: "nowy-build/delete-psu",
                defaults: new { controller = "NewBuild", action = "DeletePsuFromBuild" });

            routes.MapRoute(
                name: "AddPsuToNewBuild",
                url: "nowy-build/psu-{id}",
                defaults: new { controller = "NewBuild", action = "AddPsuToBuild", id = UrlParameter.Optional });
            // STORAGE
            routes.MapRoute(
                name: "DeleteStorageFromNewBuild",
                url: "nowy-build/delete-storage",
                defaults: new { controller = "NewBuild", action = "DeleteStorageFromBuild" });

            routes.MapRoute(
                name: "AddStorageToNewBuild",
                url: "nowy-build/storage-{id}",
                defaults: new { controller = "NewBuild", action = "AddStorageToBuild", id = UrlParameter.Optional });
            // CASE
            routes.MapRoute(
                name: "DeleteCaseFromNewBuild",
                url: "nowy-build/delete-case",
                defaults: new { controller = "NewBuild", action = "DeleteCaseFromBuild" });

            routes.MapRoute(
                name: "AddCaseToNewBuild",
                url: "nowy-build/case-{id}",
                defaults: new { controller = "NewBuild", action = "AddCaseToBuild", id = UrlParameter.Optional });

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

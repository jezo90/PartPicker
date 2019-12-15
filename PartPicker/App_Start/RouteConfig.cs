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
                name: "AddPsuToDatabase",
                url: "zarzadzanie/dodaj-zasilacz",
                defaults: new { controller = "Parts", action = "PsuAddForm" });

            routes.MapRoute(
                name: "AddRamToDatabase",
                url: "zarzadzanie/dodaj-ram",
                defaults: new { controller = "Parts", action = "RamAddForm" });

            routes.MapRoute(
                name: "AddStorageToDatabase",
                url: "zarzadzanie/dodaj-dysk",
                defaults: new { controller = "Parts", action = "StorageAddForm" });

            routes.MapRoute(
                name: "AddCaseToDatabase",
                url: "zarzadzanie/dodaj-obudowe",
                defaults: new { controller = "Parts", action = "CaseAddForm" });

            routes.MapRoute(
                name: "AddMoboToDatabase",
                url: "zarzadzanie/dodaj-plyte-glowna",
                defaults: new { controller = "Parts", action = "MoboAddForm" });

            routes.MapRoute(
                name: "AddGpuToDatabase",
                url: "zarzadzanie/dodaj-karte-graficzna",
                defaults: new { controller = "Parts", action = "GpuAddForm" });

            routes.MapRoute(
                name: "Manage",
                url: "zarzadzanie",
                defaults: new { controller = "Parts", action = "Index" });

            routes.MapRoute(
                name: "AddCpuToDatabase",
                url: "zarzadzanie/dodaj-procesor",
                defaults: new { controller = "Parts", action = "CpuAddForm"});

            routes.MapRoute(
                name: "Login",
                url: "zaloguj",
                defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "Register",
                url: "rejestracja",
                defaults: new { controller = "Account", action = "Register" });

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
                url: "dyski/{name}-{id}",
                defaults: new { controller = "Storage", action = "StorageDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Storages",
                url: "dyski",
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
                url: "konfiguracje/{name}-{id}",
                defaults: new { controller = "Builds", action = "BuildDetails", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Builds",
                url: "konfiguracje",
                defaults: new { controller = "Builds", action = "BuildList" });

            routes.MapRoute(
                 name: "BuildsHide",
                 url: "konfiguracje/{name}-{id}/ukryj",
                 defaults: new { controller = "Builds", action = "BuildHide", id = UrlParameter.Optional, name = UrlParameter.Optional });

            routes.MapRoute(
                 name: "BuildCommentDelete",
                 url: "konfiguracje/{name}-{buildId}/usun-komentarz-{rateId}",
                 defaults: new { controller = "Builds", action = "BuildCommentDelete", buildId = UrlParameter.Optional, name = UrlParameter.Optional, rateId = UrlParameter.Optional });

            routes.MapRoute(
                name: "BuildsForm",
                url: "konfiguracje/{action}/{id}",
                defaults: new { controller = "Builds", action = "BuildsList", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "NewBuild",
                url: "nowa-konfiguracja",
                defaults: new { controller = "NewBuild", action = "Index" });
            // CPU
            routes.MapRoute(
                name: "DeleteCpuFromNewBuild",
                url: "nowa-konfiguracja/delete-cpu",
                defaults: new { controller = "NewBuild", action = "DeleteCpuFromBuild" });

            routes.MapRoute(
                name: "AddCpuToNewBuild",
                url: "nowa-konfiguracja/cpu-{id}",
                defaults: new { controller = "NewBuild", action = "AddCpuToBuild", id = UrlParameter.Optional });
            // GPU
            routes.MapRoute(
                name: "DeleteGpuFromNewBuild",
                url: "nowa-konfiguracja/delete-gpu",
                defaults: new { controller = "NewBuild", action = "DeleteGpuFromBuild" });

            routes.MapRoute(
                name: "AddGpuToNewBuild",
                url: "nowa-konfiguracja/gpu-{id}",
                defaults: new { controller = "NewBuild", action = "AddGpuToBuild", id = UrlParameter.Optional });
            // MOBO
            routes.MapRoute(
                name: "DeleteMoboFromNewBuild",
                url: "nowa-konfiguracja/delete-mobo",
                defaults: new { controller = "NewBuild", action = "DeleteMoboFromBuild" });

            routes.MapRoute(
                name: "AddMoboToNewBuild",
                url: "nowa-konfiguracja/mobo-{id}",
                defaults: new { controller = "NewBuild", action = "AddMoboToBuild", id = UrlParameter.Optional });
            // RAM
            routes.MapRoute(
                name: "DeleteRamFromNewBuild",
                url: "nowa-konfiguracja/delete-ram",
                defaults: new { controller = "NewBuild", action = "DeleteRamFromBuild" });

            routes.MapRoute(
                name: "AddRamToNewBuild",
                url: "nowa-konfiguracja/ram-{id}",
                defaults: new { controller = "NewBuild", action = "AddRamToBuild", id = UrlParameter.Optional });
            // PSU
            routes.MapRoute(
                name: "DeletePsuFromNewBuild",
                url: "nowa-konfiguracja/delete-psu",
                defaults: new { controller = "NewBuild", action = "DeletePsuFromBuild" });

            routes.MapRoute(
                name: "AddPsuToNewBuild",
                url: "nowa-konfiguracja/psu-{id}",
                defaults: new { controller = "NewBuild", action = "AddPsuToBuild", id = UrlParameter.Optional });
            // STORAGE
            routes.MapRoute(
                name: "DeleteStorageFromNewBuild",
                url: "nowa-konfiguracja/delete-storage",
                defaults: new { controller = "NewBuild", action = "DeleteStorageFromBuild" });

            routes.MapRoute(
                name: "AddStorageToNewBuild",
                url: "nowa-konfiguracja/storage-{id}",
                defaults: new { controller = "NewBuild", action = "AddStorageToBuild", id = UrlParameter.Optional });
            // CASE
            routes.MapRoute(
                name: "DeleteCaseFromNewBuild",
                url: "nowa-konfiguracja/delete-case",
                defaults: new { controller = "NewBuild", action = "DeleteCaseFromBuild" });

            routes.MapRoute(
                name: "AddCaseToNewBuild",
                url: "nowa-konfiguracja/case-{id}",
                defaults: new { controller = "NewBuild", action = "AddCaseToBuild", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}

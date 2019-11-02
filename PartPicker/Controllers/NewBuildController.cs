using PartPicker.DAL;
using PartPicker.Infrastructure;
using PartPicker.Models;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Controllers
{
    public class NewBuildController : Controller
    {
        private BuildManager BuildManager;
        private ISessionManager SessionManager { get; set; }
        private PickerContext context = new PickerContext();

        public NewBuildController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                NewBuildViewModel newBuildViewModel = new NewBuildViewModel()
                {
                    Cpu = BuildManager.GetCpu(),
                    Gpu = BuildManager.GetGpu(),
                    Ram = BuildManager.GetRam(),
                    Case = BuildManager.GetCase(),
                    Mobo = BuildManager.GetMobo(),
                    Psu = BuildManager.GetPsu(),
                    Storage = BuildManager.GetStorage()
                };

                return View("NewBuild", newBuildViewModel);
            }
            else return RedirectToAction("Login", "Account");
        }

        // CPU
        public ActionResult AddCpuToBuild(int id)
        {
            var c = context.Cpu.Where(a => a.CpuId == id).Take(1).ToList();
            if (BuildManager.GetMobo() != null)
            {
                if(BuildManager.GetMobo().Socket.Name == c[0].Socket.Name)
                {
                    BuildManager.CpuAddToBuild(c[0]);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                BuildManager.CpuAddToBuild(c[0]);
            }


            return RedirectToAction("Index");
        }

        public ActionResult DeleteCpuFromBuild()
        {
            BuildManager.CpuDeleteFromBuild();

            return RedirectToAction("Index");
        }

        // GPU
        public ActionResult AddGpuToBuild(int id)
        {
            var c = context.Gpu.Where(a => a.GpuId == id).Take(1).ToList();
            BuildManager.GpuAddToBuild(c[0]);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteGpuFromBuild()
        {
            BuildManager.GpuDeleteFromBuild();

            return RedirectToAction("Index");
        }

        // MOBO
        public ActionResult AddMoboToBuild(int id)
        {
            var c = context.Mobo.Where(a => a.MoboId == id).Take(1).ToList();
            if (BuildManager.GetCpu() != null)
            {
                if (BuildManager.GetCpu().Socket.Name == c[0].Socket.Name)
                {
                    BuildManager.MoboAddToBuild(c[0]);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                BuildManager.MoboAddToBuild(c[0]);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteMoboFromBuild()
        {
            BuildManager.MoboDeleteFromBuild();

            return RedirectToAction("Index");
        }

        // RAM
        public ActionResult AddRamToBuild(int id)
        {
            var c = context.Ram.Where(a => a.RamId == id).Take(1).ToList();
            BuildManager.RamAddToBuild(c[0]);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteRamFromBuild()
        {
            BuildManager.RamDeleteFromBuild();

            return RedirectToAction("Index");
        }

        // PSU
        public ActionResult AddPsuToBuild(int id)
        {
            var c = context.Psu.Where(a => a.PsuId == id).Take(1).ToList();
            BuildManager.PsuAddToBuild(c[0]);

            return RedirectToAction("Index");
        }

        public ActionResult DeletePsuFromBuild()
        {
            BuildManager.PsuDeleteFromBuild();

            return RedirectToAction("Index");
        }

        // CASE
        public ActionResult AddCaseToBuild(int id)
        {
            var c = context.Case.Where(a => a.CaseId == id).Take(1).ToList();
            BuildManager.CaseAddToBuild(c[0]);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCaseFromBuild()
        {
            BuildManager.CaseDeleteFromBuild();

            return RedirectToAction("Index");
        }

        // STORAGE
        public ActionResult AddStorageToBuild(int id)
        {
            var c = context.Storage.Where(a => a.StorageId == id).Take(1).ToList();
            BuildManager.StorageAddToBuild(c[0]);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteStorageFromBuild()
        {
            BuildManager.StorageDeleteFromBuild();

            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PartPicker.DAL;
using PartPicker.Infrastructure;
using PartPicker.Models;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> AddBuild(NewBuild build, string name, string description)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    var newBuild = BuildManager.CreateBuild(build, userId, description, name);

                    var user = await UserManager.FindByIdAsync(userId);
                    TryUpdateModel(user.Builds);
                    await UserManager.UpdateAsync(user);

                    BuildManager.EmptyBuild();

                    return RedirectToAction("BuildsList", "Builds");
                }
                else return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(build);
            }
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // CPU
        public ActionResult AddCpuToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Cpu.Where(a => a.CpuId == id).Take(1).ToList();

                if (BuildManager.GetMobo() != null)
                {
                    if (BuildManager.GetMobo().Socket.Name == c[0].Socket.Name)
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
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteCpuFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.CpuDeleteFromBuild();
            }
            else return RedirectToAction("Login", "Account");

            return RedirectToAction("Index");
        }

        // GPU
        public ActionResult AddGpuToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Gpu.Where(a => a.GpuId == id).Take(1).ToList();
                if (BuildManager.GetCase() != null)
                {
                    if (BuildManager.GetCase().GpuLenght >= c[0].Length)
                    {
                        BuildManager.GpuAddToBuild(c[0]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    BuildManager.GpuAddToBuild(c[0]);
                }
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteGpuFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.GpuDeleteFromBuild();
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        // MOBO
        public ActionResult AddMoboToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Mobo.Where(a => a.MoboId == id).Take(1).ToList();
                if (BuildManager.GetCpu() != null || BuildManager.GetCase() != null || BuildManager.GetRam() != null)
                {
                    if(BuildManager.GetCase() != null && BuildManager.GetCpu() != null && BuildManager.GetRam() != null)
                    {
                        if (BuildManager.GetCpu().Socket.Name == c[0].Socket.Name && 
                            BuildManager.GetCase().FormFactor.Name == c[0].FormFactor.Name &&
                            BuildManager.GetRam().RamType.Name == c[0].RamType.Name)
                        {
                            BuildManager.MoboAddToBuild(c[0]);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else if(BuildManager.GetCase() != null && BuildManager.GetRam() != null && BuildManager.GetCpu() == null)
                    {
                        if(BuildManager.GetCase().FormFactor.Name == c[0].FormFactor.Name &&
                            BuildManager.GetRam().RamType.Name == c[0].RamType.Name)
                        {
                            BuildManager.MoboAddToBuild(c[0]);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else if(BuildManager.GetCpu() != null && BuildManager.GetRam() != null && BuildManager.GetCase() == null)
                    {
                        if (BuildManager.GetCpu().Socket.Name == c[0].Socket.Name &&
                            BuildManager.GetRam().RamType.Name == c[0].RamType.Name)
                        {
                            BuildManager.MoboAddToBuild(c[0]);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else if (BuildManager.GetCpu() != null && BuildManager.GetCase() != null && BuildManager.GetRam() == null)
                    {
                        if (BuildManager.GetCase().FormFactor.Name == c[0].FormFactor.Name &&
                            BuildManager.GetCpu().Socket.Name == c[0].Socket.Name)
                        {
                            BuildManager.MoboAddToBuild(c[0]);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else if(BuildManager.GetCpu() != null && BuildManager.GetRam() == null && BuildManager.GetCase() == null)
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
                    else if (BuildManager.GetCase() != null && BuildManager.GetRam() == null && BuildManager.GetCpu() == null)
                    {
                        if (BuildManager.GetCase().FormFactor.Name == c[0].FormFactor.Name)
                        {
                            BuildManager.MoboAddToBuild(c[0]);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else if (BuildManager.GetRam() != null && BuildManager.GetCase() == null && BuildManager.GetCpu() == null)
                    {
                        if (BuildManager.GetRam().RamType.Name == c[0].RamType.Name)
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
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    BuildManager.MoboAddToBuild(c[0]);
                }

                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteMoboFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.MoboDeleteFromBuild();
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        // RAM
        public ActionResult AddRamToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Ram.Where(a => a.RamId == id).Take(1).ToList();
                if (BuildManager.GetMobo() != null)
                {
                    if (BuildManager.GetMobo().RamType.Name == c[0].RamType.Name)
                    {
                        BuildManager.RamAddToBuild(c[0]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    BuildManager.RamAddToBuild(c[0]);
                }
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteRamFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.RamDeleteFromBuild();
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        // PSU
        public ActionResult AddPsuToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Psu.Where(a => a.PsuId == id).Take(1).ToList();
                BuildManager.PsuAddToBuild(c[0]);
            }
            else return RedirectToAction("Login", "Account");

            return RedirectToAction("Index");
        }

        public ActionResult DeletePsuFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.PsuDeleteFromBuild();
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        // CASE
        public ActionResult AddCaseToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Case.Where(a => a.CaseId == id).Take(1).ToList();
                if (BuildManager.GetMobo() != null && BuildManager.GetGpu() != null)
                {
                    if (BuildManager.GetMobo().FormFactor.Name == c[0].FormFactor.Name && BuildManager.GetGpu().Length < c[0].GpuLenght)
                    {
                        BuildManager.CaseAddToBuild(c[0]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (BuildManager.GetMobo() != null)
                {
                    if (BuildManager.GetMobo().FormFactor.Name == c[0].FormFactor.Name)
                    {
                        BuildManager.CaseAddToBuild(c[0]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (BuildManager.GetGpu() != null)
                {
                    if (BuildManager.GetGpu().Length < c[0].GpuLenght)
                    {
                        BuildManager.CaseAddToBuild(c[0]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    BuildManager.CaseAddToBuild(c[0]);
                }
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteCaseFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.CaseDeleteFromBuild();
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        // STORAGE
        public ActionResult AddStorageToBuild(int id)
        {
            if (Request.IsAuthenticated)
            {
                var c = context.Storage.Where(a => a.StorageId == id).Take(1).ToList();
                BuildManager.StorageAddToBuild(c[0]);

                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteStorageFromBuild()
        {
            if (Request.IsAuthenticated)
            {
                BuildManager.StorageDeleteFromBuild();
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Login", "Account");
        }
    }
}
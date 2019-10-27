using HtmlAgilityPack;
using PartPicker.DAL;
using PartPicker.Infrastructure;
using PartPicker.Models;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Controllers
{
    public class CpuController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public CpuController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id, string name)
        {
            var cpu = context.Cpu.Find(id);
            var cpuList = context.Cpu.Where(a => a.Name == cpu.Name).ToList();
            List<string> prices = new List<string>();

            foreach (Cpu c in cpuList)
            {
                prices.Add(Functions.GetPrice(c));
            }


            var cpuDetailsViewModel = new CpuDetailsViewModel()
            {
                Cpu = cpu,
                CpuList = cpuList,
                Prices = prices,
                NewBuildViewModel = new NewBuildViewModel()
                {
                    Cpu = BuildManager.GetCpu(),
                    Gpu = BuildManager.GetGpu(),
                    Ram = BuildManager.GetRam(),
                    Case = BuildManager.GetCase(),
                    Mobo = BuildManager.GetMobo(),
                    Psu = BuildManager.GetPsu(),
                    Storage = BuildManager.GetStorage()
                }

            };

            return View(cpuDetailsViewModel);
        }
    }
}
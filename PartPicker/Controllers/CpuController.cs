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
        private PickerContext context = new PickerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id, string name)
        {
            var cpu = context.Cpu.Find(id);
            var cpuList = context.Cpu.Where(a => a.Name == cpu.Name).ToList();
            List<string> prizes = new List<string>();

            foreach (Cpu c in cpuList)
            {
                prizes.Add(Functions.GetPrice(c));                 
            }

            var cpuDetailsViewModel = new CpuDetailsViewModel()
            {
                Cpu = cpu,
                CpuList = cpuList,
                Prizes = prizes
            };

            return View(cpuDetailsViewModel);
        }
    }
}
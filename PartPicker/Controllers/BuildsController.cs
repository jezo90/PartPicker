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
    public class BuildsController : Controller
    {
        private PickerContext context = new PickerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List(string cpuM = "", string cpuS = "")
        {
            var buildsBase = context.Build.Where(a => !a.Hidden).ToList();
            var builds = buildsBase;
            var buildsCpu = new List<Build>();
            var buildsGpu = new List<Build>();
            var buildsRam = new List<Build>();
            var buildsStorage = new List<Build>();
            var buildsOut = new List<Build>();

            if (cpuS != "")
            {
                builds = buildsBase.Where(a => a.Cpu.Product.Series.Name == cpuS).ToList();
                foreach (var j in builds)
                {
                    buildsCpu.Add(j);
                }
                buildsOut = buildsCpu;
            }
            else if (cpuM != "")
            {
                builds = buildsBase.Where(a => a.Cpu.Product.Manufacturer.Name == cpuM).ToList();
                foreach (var j in builds)
                {
                    buildsCpu.Add(j);
                }
                buildsOut = buildsCpu;
            }

            //if (gpuM.Count() != 0)
            //{
            //    foreach (var i in gpuM)
            //    {
            //        if (buildsCpu != null)
            //            builds = buildsCpu.Where(a => a.Gpu.Product.Manufacturer.Name == i).ToList();
            //        else
            //            builds = buildsBase.Where(a => a.Gpu.Product.Manufacturer.Name == i).ToList();
            //        foreach (var j in builds)
            //            buildsGpu.Add(j);
            //    }
            //    buildsOut = buildsGpu;
            //}

            //if (ramT.Count() != 0)
            //{
            //    foreach (var i in ramT)
            //    {
            //        if (buildsGpu != null)
            //            builds = buildsGpu.Where(a => a.Ram.RamType.Name == i).ToList();
            //        else
            //            builds = buildsBase.Where(a => a.Ram.RamType.Name == i).ToList();
            //        foreach (var j in builds)
            //            buildsRam.Add(j);
            //    }
            //    buildsOut = buildsRam;
            //}

            //if (storageT.Count() != 0)
            //{
            //    foreach (var i in storageT)
            //    {
            //        if (buildsRam != null)
            //            builds = buildsRam.Where(a => a.Storage.Interface.Name == i).ToList();
            //        else
            //            builds = buildsBase.Where(a => a.Storage.Interface.Name == i).ToList();
            //        foreach (var j in builds)
            //            buildsStorage.Add(j);
            //    }
            //    buildsOut = buildsStorage;
            //}

            if (buildsOut.Count() == 0)
                buildsOut = buildsBase;

            int amountOfBuilds = buildsBase.Count() + 1;
            double[] sum = new double[amountOfBuilds];
            double[] average = new double[amountOfBuilds];
            double[] count = new double[amountOfBuilds];

            for (int i = 0; i < amountOfBuilds; i++)
            {
                sum[i] = 0.0d;
                count[i] = 0.0d;
            }

            foreach (Build b in buildsBase)
            {
                foreach (Rate r in b.Rates)
                {
                    sum[r.BuildId] += r.Grade;
                    count[r.BuildId]++;
                }
            }

            for (int i = 0; i < amountOfBuilds; i++)
            {
                if (count[i] != 0d) average[i] = sum[i] / count[i] * 1.0d;
            }

            var buildsListViewModel = new BuildsListViewModel()
            {
                Builds = buildsOut,
                Average = average,
                Count = count,
                CpuM = cpuM,
                CpuS = cpuS
            };

            return View(buildsListViewModel);
        }

        [ChildActionOnly]
        public ActionResult Filters(BuildSearchViewModel search)
        {
            var cpus = context.Cpu.ToList();

            var cpuManufacturer = context.Cpu.Select(a => a.Product.Manufacturer.Name)
                                .Distinct()
                                .ToList();

            var cpuSeries = context.Cpu.Select(a => a.Product.Series.Name)
                        .Distinct()
                        .ToList();

            var gpuManufacturer = context.Gpu.Select(a => a.Product.Series.Name)
                                .Distinct()
                                .ToList();

            var storageType = context.Storage.Select(a => a.Type)
                            .Distinct()
                            .ToList();

            var ramType = context.RamType.Select(a => a.Name)
                        .Distinct()
                        .ToList();

            var buildFiltersViewModel = new BuildFiltersViewModel()
            {
                Cpus = cpus,
                CpuSeries = cpuSeries,
                CpuManufacturers = cpuManufacturer,
                GpuManufacturers = gpuManufacturer,
                StorageTypes = storageType,
                RamTypes = ramType
            };

            return PartialView("_Filters", buildFiltersViewModel);
        }
    }
}

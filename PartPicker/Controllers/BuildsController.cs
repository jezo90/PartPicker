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
        ICacheProvider cache = new DefaultCacheProvider();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //public ActionResult List()
        //{
        //    var builds = context.Build.ToList();

        //    int amountOfBuilds = context.Build.Count() + 1;
        //    double[] sum = new double[amountOfBuilds];
        //    double[] average = new double[amountOfBuilds];
        //    double[] count = new double[amountOfBuilds];

        //    for (int i = 0; i < amountOfBuilds; i++)
        //    {
        //        sum[i] = 0.0d;
        //        count[i] = 0.0d;
        //    }

        //    foreach (Build b in builds)
        //    {
        //        foreach (Rate r in b.Rates)
        //        {
        //            sum[r.BuildId] += r.Grade;
        //            count[r.BuildId]++;
        //        }
        //    }

        //    for (int i = 0; i < amountOfBuilds; i++)
        //    {
        //        if (count[i] != 0d) average[i] = sum[i] / count[i] * 1.0d;
        //    }

        //    var buildsListViewModel = new BuildsListViewModel()
        //    {
        //        Builds = builds,
        //        Average = average,
        //        Count = count
        //    };

        //    return View(buildsListViewModel);
        //}

        public ActionResult List(BuildSearchViewModel search)
        {
            var builds = context.Build.Where(a => !a.Hidden).ToList();

            if (search.CpuManufacturers.Count() != 0)
            {
                foreach (var i in search.CpuManufacturers)
                    builds = builds.Where(a => a.Cpu.Product.Manufacturer.Name == i).ToList();
            }

            if (search.CpuSeries.Count() != 0)
            {
                foreach (var i in search.CpuSeries)
                    builds = builds.Where(a => a.Cpu.Product.Series.Name == i).ToList();
            }

            if (search.GpuManufacturers.Count() != 0)
            {
                foreach (var i in search.GpuManufacturers)
                    builds = builds.Where(a => a.Gpu.Product.Manufacturer.Name == i).ToList();
            }

            if (search.RamType.Count() != 0)
            {
                foreach (var i in search.RamType)
                    builds = builds.Where(a => a.Ram.RamType.Name == i).ToList();
            }

            if (search.StorageType.Count() != 0)
            {
                foreach (var i in search.StorageType)
                    builds = builds.Where(a => a.Storage.Interface.Name == i).ToList();
            }

            int amountOfBuilds = builds.Count() + 1;
            double[] sum = new double[amountOfBuilds];
            double[] average = new double[amountOfBuilds];
            double[] count = new double[amountOfBuilds];

            for (int i = 0; i < amountOfBuilds; i++)
            {
                sum[i] = 0.0d;
                count[i] = 0.0d;
            }

            foreach (Build b in builds)
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
                Builds = builds,
                Average = average,
                Count = count,
                Search = search
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
                RamTypes = ramType,
                Search = search
            };

            return PartialView("_Filters", buildFiltersViewModel);
        }
    }
}

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

        public ActionResult List()
        {
            var builds = context.Build.ToList();

            int amountOfBuilds = context.Build.Count() + 1;
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
                Count = count
            };

            return View(buildsListViewModel);
        }

        [ChildActionOnly]
        public ActionResult Filters()
        {
            var cpuManufacturer = context.Cpu.Select(a => a.SeriesCpu.Manufacturer)
                                .Distinct()
                                .ToList();

            var cpuSeries = context.SeriesCpu.OrderBy(a => a.Name)
                            .ToList();

            var gpuManufacturer = context.Gpu.Select(a => a.Manufacturer)
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

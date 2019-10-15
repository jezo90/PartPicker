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

        public ActionResult List(string cpuM = "", string cpuS = "", string gpuS = "", string ramT = "", string storageT = "", int reset = 0)
        {
            var buildsBase = context.Build.Where(a => !a.Hidden).ToList();
            var builds = buildsBase;
            var buildsAll = buildsBase;
            int matched = -1;
            var buildsCpu = new List<Build>();
            var buildsCpuM = new List<Build>();
            var buildsGpu = new List<Build>();
            var buildsRam = new List<Build>();
            var buildsStorage = new List<Build>();
            var cpuMList = new List<string>();
            var cpuSList = new List<string>();
            var gpuSList = new List<string>();
            var ramTList = new List<string>();
            var storageTList = new List<string>();

            ICacheProvider cache = new DefaultCacheProvider();

            if (reset == 1)
            {
                cache.Invalidate(CacheNames.cpuMBuildsFilter);
                cache.Invalidate(CacheNames.cpuSBuildsFilter);
                cache.Invalidate(CacheNames.gpuSBuildsFilter);
                cache.Invalidate(CacheNames.ramTBuildsFilter);
                cache.Invalidate(CacheNames.storageTBuildsFilter);
            }

            //////////// CPU SERIE CACHE

            if (cache.IsSet(CacheNames.cpuSBuildsFilter))
                cpuSList = cache.Get(CacheNames.cpuSBuildsFilter) as List<string>;

            if (cpuS != "")
            {
                if (cpuSList.Contains(cpuS))
                    cpuSList.Remove(cpuS);
                else
                    cpuSList.Add(cpuS);
            }

            if (cpuSList.Count() == 0 && cache.IsSet(CacheNames.cpuSBuildsFilter))
                cache.Invalidate(CacheNames.cpuSBuildsFilter);
            if (cpuSList.Count != 0)
                cache.Set(CacheNames.cpuSBuildsFilter, cpuSList, 60);

            //////////// CPU MODELE CACHE

            if (cache.IsSet(CacheNames.cpuMBuildsFilter))
                cpuMList = cache.Get(CacheNames.cpuMBuildsFilter) as List<string>;

            if (cpuM != "")
            {
                if (cpuMList.Contains(cpuM))
                    cpuMList.Remove(cpuM);
                else
                    cpuMList.Add(cpuM);
            }

            if (cpuMList.Count() == 0 && cache.IsSet(CacheNames.cpuMBuildsFilter))
                cache.Invalidate(CacheNames.cpuMBuildsFilter);
            if (cpuMList.Count() != 0)
                cache.Set(CacheNames.cpuMBuildsFilter, cpuMList, 60);

            //////////// CPU SERIE

            foreach (var i in cpuSList)
            {
                builds = buildsBase.Where(a => a.Cpu.Product.Series.Name == i).ToList();
                foreach (var j in builds)
                {
                    buildsCpu.Add(j);
                }
            }

            if (cpuSList.Count != 0)
            {
                buildsBase = buildsCpu;
                matched = buildsBase.Count();
            }

            //////////// CPU MODELE
            
            foreach (var i in cpuMList)
            {
                builds = buildsBase.Where(a => a.Cpu.Product.Manufacturer.Name == i).ToList();
                foreach (var j in builds)
                {
                    buildsCpuM.Add(j);
                }
            }

            if (cpuMList.Count != 0)
            {
                buildsBase = buildsCpuM;
                matched = buildsBase.Count();
            }
            //////////// GPU SERIE

            if (cache.IsSet(CacheNames.gpuSBuildsFilter))
                gpuSList = cache.Get(CacheNames.gpuSBuildsFilter) as List<string>;

            if (gpuS != "")
            {
                if (gpuSList.Contains(gpuS))
                    gpuSList.Remove(gpuS);
                else
                    gpuSList.Add(gpuS);
            }

            if (gpuSList.Count() == 0 && cache.IsSet(CacheNames.gpuSBuildsFilter))
                cache.Invalidate(CacheNames.gpuSBuildsFilter);
            if (gpuSList.Count() != 0)
                cache.Set(CacheNames.gpuSBuildsFilter, gpuSList, 60);

            foreach (var i in gpuSList)
            {
                builds = buildsBase.Where(a => a.Gpu.Product.Series.Name == i).ToList();

                foreach (var j in builds)
                {
                    buildsGpu.Add(j);
                }
            }

            if (gpuSList.Count != 0)
            {
                buildsBase = buildsGpu;
                matched = buildsBase.Count();
            }

            //////////// TYP RAM

            if (cache.IsSet(CacheNames.ramTBuildsFilter))
                ramTList = cache.Get(CacheNames.ramTBuildsFilter) as List<string>;

            if (ramT != "")
            {
                if (ramTList.Contains(ramT))
                    ramTList.Remove(ramT);
                else
                    ramTList.Add(ramT);
            }

            if (ramTList.Count() == 0 && cache.IsSet(CacheNames.ramTBuildsFilter))
                cache.Invalidate(CacheNames.ramTBuildsFilter);
            if (ramTList.Count() != 0)
                cache.Set(CacheNames.ramTBuildsFilter, ramTList, 60);

            foreach (var i in ramTList)
            {
                builds = buildsBase.Where(a => a.Ram.RamType.Name == i).ToList();

                foreach (var j in builds)
                {
                    buildsRam.Add(j);
                }
            }

            if (ramTList.Count() != 0)
            {
                buildsBase = buildsRam;
                matched = buildsBase.Count();
            }

            //////////// STORAGE TYP

            if (cache.IsSet(CacheNames.storageTBuildsFilter))
                storageTList = cache.Get(CacheNames.storageTBuildsFilter) as List<string>;

            if (storageT != "")
            {
                if (storageTList.Contains(storageT))
                    storageTList.Remove(storageT);
                else
                    storageTList.Add(storageT);
            }

            if (storageTList.Count() == 0 && cache.IsSet(CacheNames.storageTBuildsFilter))
                cache.Invalidate(CacheNames.storageTBuildsFilter);
            if (storageTList.Count() != 0)
                cache.Set(CacheNames.storageTBuildsFilter, storageTList, 60);

            foreach (var i in storageTList)
            {
                builds = buildsBase.Where(a => a.Storage.Type == i).ToList();

                foreach (var j in builds)
                {
                    buildsStorage.Add(j);
                }
            }

            if (storageTList.Count() != 0)
            {
                buildsBase = buildsStorage;
                matched = buildsBase.Count();
            }

            /// KONIEC 


            int amountOfBuilds = buildsAll.Count() + 1;
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
                Builds = buildsBase,
                Average = average,
                Count = count
            };

            return View(buildsListViewModel);
        }

        [ChildActionOnly]
        public ActionResult Filters()
        {
            ICacheProvider cache = new DefaultCacheProvider();

            var cpus = context.Cpu.ToList();

            var cpuManufacturer = context.Cpu.Select(a => a.Product.Manufacturer.Name)
                                .Distinct()
                                .ToList();

            var cpuSeries = context.Cpu.Select(a => a.Product.Series.Name)
                        .Distinct()
                        .ToList();

            var gpuSeries = context.Gpu.Select(a => a.Product.Series.Name)
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
                GpuSeries = gpuSeries,
                StorageTypes = storageType,
                RamTypes = ramType,
                Cache = cache
            };

            return PartialView("_Filters", buildFiltersViewModel);
        }
    }
}

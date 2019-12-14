using PagedList;
using PartPicker.DAL;
using PartPicker.Infrastructure;
using PartPicker.Models;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity.Migrations;

namespace PartPicker.Controllers
{
    public class BuildsController : Controller
    {
        private PickerContext context = new PickerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildDetails(int id, string name)
        {
            var build = context.Build.Find(id);
            return View(build);
        }

        public ActionResult BuildList(List<string> cpuSeries, List<string> gpuSeries, List<string> ramType, List<string> storageType,
                                    int? page, string seriesCpuString = "", string seriesGpuString = "",
                                    string storageTypeString = "", string ramTypeString = "")
        {
            var builds = context.Build.ToList();
            List<Build> buildsFound = new List<Build>();
            List<Build> buildsOut = new List<Build>();
            int filtred = 0;

            // OCENY
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
            if (Request.IsAuthenticated)
            {
                var userName = User.Identity.GetUserName();
                if (userName != "admin")
                    builds = context.Build.Where(a => a.Hidden == false).ToList();
            }
            else
            {
                builds = context.Build.Where(a => a.Hidden == false).ToList();
            }

            // CPU
            if (cpuSeries != null)
            {
                foreach (var serie in cpuSeries)
                {
                    buildsOut = builds.Where(a => a.Cpu.Product.Series.Name == serie).ToList();
                    foreach (var buildsout in buildsOut)
                    {
                        buildsFound.Add(buildsout);
                    }
                }
                filtred = 1;
            }
            else if (seriesCpuString != "")
            {
                string[] cpuSeriesT = seriesCpuString.Split('_');
                List<string> tempCpuSeries = new List<string>();
                foreach (var serie in cpuSeriesT)
                {
                    buildsOut = builds.Where(a => a.Cpu.Product.Series.Name == serie).ToList();
                    if (serie != "")
                    {
                        tempCpuSeries.Add(serie);
                    }
                    foreach (var buildsout in buildsOut)
                    {
                        buildsFound.Add(buildsout);
                    }
                }
                cpuSeries = tempCpuSeries;
                filtred = 1;
            }

            if (filtred == 1)
            {
                builds.Clear();
                foreach (var add in buildsFound)
                {
                    builds.Add(add);
                }
                buildsFound.Clear();
                filtred = 0;
            }

            // GPU
            if (builds.Count() > 0)
            {
                if (gpuSeries != null)
                {
                    foreach (var serie in gpuSeries)
                    {
                        buildsOut = builds.Where(a => a.Gpu.Product.Series.Name == serie).ToList();
                        foreach (var buildsout in buildsOut)
                        {
                            buildsFound.Add(buildsout);
                        }
                    }
                    filtred = 1;
                }
                else if (seriesGpuString != "")
                {
                    string[] gpuSeriesT = seriesGpuString.Split('_');
                    List<string> tempGpuSeries = new List<string>();
                    foreach (var serie in gpuSeriesT)
                    {
                        buildsOut = builds.Where(a => a.Gpu.Product.Series.Name == serie).ToList();
                        if (serie != "")
                        {
                            tempGpuSeries.Add(serie);
                        }
                        foreach (var buildsout in buildsOut)
                        {
                            buildsFound.Add(buildsout);
                        }
                    }
                    gpuSeries = tempGpuSeries;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                builds.Clear();
                foreach (var add in buildsFound)
                {
                    builds.Add(add);
                }
                buildsFound.Clear();
                filtred = 0;
            }

            // RAM
            if (builds.Count() > 0)
            {
                if (ramType != null)
                {
                    foreach (var ram in ramType)
                    {
                        buildsOut = builds.Where(a => a.Ram.RamType.Name == ram).ToList();
                        foreach (var buildsout in buildsOut)
                        {
                            buildsFound.Add(buildsout);
                        }
                    }
                    filtred = 1;
                }
                else if (ramTypeString != "")
                {
                    string[] ramTypeT = ramTypeString.Split('_');
                    List<string> tempRamType = new List<string>();
                    foreach (var ram in ramTypeT)
                    {
                        buildsOut = builds.Where(a => a.Ram.RamType.Name == ram).ToList();
                        if (ram != "")
                        {
                            tempRamType.Add(ram);
                        }
                        foreach (var buildsout in buildsOut)
                        {
                            buildsFound.Add(buildsout);
                        }
                    }
                    ramType = tempRamType;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                builds.Clear();
                foreach (var add in buildsFound)
                {
                    builds.Add(add);
                }
                buildsFound.Clear();
                filtred = 0;
            }

            // STORAGE
            if (builds.Count() > 0)
            {
                if (storageType != null)
                {
                    foreach (var type in storageType)
                    {
                        buildsOut = builds.Where(a => a.Storage.Type == type).ToList();
                        foreach (var buildsout in buildsOut)
                        {
                            buildsFound.Add(buildsout);
                        }
                    }
                    filtred = 1;
                }
                else if (storageTypeString != "")
                {
                    string[] storageTypeT = storageTypeString.Split('_');
                    List<string> tempStorageType = new List<string>();
                    foreach (var type in storageTypeT)
                    {
                        buildsOut = builds.Where(a => a.Storage.Type == type).ToList();
                        if (type != "")
                        {
                            tempStorageType.Add(type);
                        }
                        foreach (var buildsout in buildsOut)
                        {
                            buildsFound.Add(buildsout);
                        }
                    }
                    storageType = tempStorageType;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                builds.Clear();
                foreach (var add in buildsFound)
                {
                    builds.Add(add);
                }
                buildsFound.Clear();
                filtred = 0;
            }


            int pageSize = 5;
            int pageNumber = (page ?? 1);

            List<string> emptyList = new List<string> { "" };
            if (cpuSeries == null) cpuSeries = emptyList;
            if (gpuSeries == null) gpuSeries = emptyList;
            if (ramType == null) ramType = emptyList;
            if (storageType == null) storageType = emptyList;

            var buildListViewModel = new BuildListViewModel()
            {
                PagedList = builds.ToPagedList(pageNumber, pageSize),
                Average = average,
                Count = count,

                BuildFormCheckedViewModel = new BuildFormCheckedViewModel()
                {
                    CpuSeriesChecked = cpuSeries,
                    GpuSeriesChecked = gpuSeries,
                    RamTypeChecked = ramType,
                    StorageTypeChecked = storageType,
                    CpuManufacturersChecked = emptyList
                }
            };

            return View(buildListViewModel);
        }

        public ActionResult BuildHide(int id, string name)
        {
            if (Request.IsAuthenticated)
            {
                if (User.Identity.GetUserName() == "admin")
                {
                    var buildToHide = context.Build.Where(a => a.BuildId == id).ToList();
                    buildToHide[0].Hidden = !buildToHide[0].Hidden;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("BuildDetails", new { id, name });
        }

        public ActionResult BuildCommentDelete(int rateId, int buildId, string name)
        {
            if (Request.IsAuthenticated)
            {
                if (User.Identity.GetUserName() == "admin")
                {
                    var commentToDelete = context.Rate.Where(a => a.RateId == rateId).ToList();
                    context.Rate.Remove(commentToDelete[0]);

                    context.SaveChanges();
                }
            }

            return RedirectToAction("BuildDetails", new { id = buildId, name });
        }


        [ChildActionOnly]
        public ActionResult RateForm(int id, string name)
        {
            var userId = User.Identity.GetUserId();
            var rate = context.Rate.Where(a => a.BuildId == id && a.ApplicationUserId == userId).ToList();
            if (rate.Count == 0)
            {
                var empty = new Rate()
                {
                    Grade = 3,
                    Comment = "Dodaj komentarz"
                };
                rate.Add(empty);
            }
            var buildRatesViewModel = new BuildRatesViewModel()
            {
                BuildId = id,
                BuildName = name,
                Rate = rate[0]
            };

            return PartialView("_RateForm", buildRatesViewModel);
        }

        public ActionResult AddRate(int id, string name, string comment, int rate = 0)
        {
            if (rate != 0)
            {
                var userId = User.Identity.GetUserId();
                if (comment == "") comment = "Brak";
                var newRate = new Rate()
                {
                    BuildId = id,
                    ApplicationUserId = userId,
                    Comment = comment,
                    Grade = rate,
                    Added = DateTime.Now
                };
                var rates = context.Rate.Where(a => a.BuildId == id && a.ApplicationUserId == userId).ToList();
                foreach (var r in rates)
                {
                    context.Rate.Remove(r);
                }
                context.Rate.Add(newRate);
                context.SaveChanges();
            }

            return RedirectToAction("BuildDetails", new { id, name });
        }


        [ChildActionOnly]
        public ActionResult Form(BuildFormCheckedViewModel checkd)
        {

            var cpus = context.Cpu.ToList();

            var gpus = context.Gpu.ToList();

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

            List<string> emptyList = new List<string> { "" };
            List<string> manuList = new List<string> { "" };

            if (checkd.CpuSeriesChecked == null)
            {
                checkd.CpuManufacturersChecked = emptyList;
                checkd.CpuSeriesChecked = emptyList;
            }
            else
            {
                foreach (var serie in checkd.CpuSeriesChecked)
                {
                    if (serie != "")
                    {
                        var name = cpus.Where(a => a.Product.Series.Name == serie).ToList();
                        if (!checkd.CpuManufacturersChecked.Contains(name[0].Product.Manufacturer.Name))
                        {
                            manuList.Add(name[0].Product.Manufacturer.Name);
                        }
                    }
                }
                if (manuList.Count() != 0)
                {
                    checkd.CpuManufacturersChecked = manuList;
                }
            }
            if (checkd.GpuSeriesChecked == null) checkd.GpuSeriesChecked = emptyList;
            if (checkd.RamTypeChecked == null) checkd.RamTypeChecked = emptyList;
            if (checkd.StorageTypeChecked == null) checkd.StorageTypeChecked = emptyList;
            if (checkd.CpuManufacturersChecked == null) checkd.CpuManufacturersChecked = emptyList;


            var buildFormViewModel = new BuildFormViewModel()
            {
                Cpus = cpus,
                Gpus = gpus,
                CpuSeries = cpuSeries,
                CpuManufacturers = cpuManufacturer,
                GpuSeries = gpuSeries,
                StorageTypes = storageType,
                RamTypes = ramType,
                BuildFormCheckedViewModel = checkd
            };

            return PartialView("_Form", buildFormViewModel);
        }


    }
}

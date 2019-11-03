using PartPicker.DAL;
using PartPicker.Infrastructure;
using PartPicker.Models;
using PartPicker.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Controllers
{
    public class GpuController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public GpuController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GpuList(List<string> series, List<string> rams, List<string> manufacturers, int? page, int lengthMax = 0,
                                    int ramMin = 0, int ramMax = 0, string seriesString = "", string ramsString = "", string manufacturersString = "")
        {
            if (ramMin != 0 || ramMax != 0)
            {
                if (ramMin > ramMax && ramMin != 0 && ramMax != 0)
                {
                    var temp = ramMin;
                    ramMin = ramMax;
                    ramMax = temp;
                }
            }

            var gpu = context.Gpu.ToList();
            var benchmarkMax = context.Gpu.Max(a => a.Benchmark);
            List<Gpu> gpuOut = new List<Gpu>();
            List<Gpu> gpuFound = new List<Gpu>();
            int filtred = 0;

            if (series != null)
            {
                foreach(var serie in series)
                {
                    gpuOut = gpu.Where(a => a.Product.Series.Name == serie).ToList();
                    foreach(var gpuout in gpuOut)
                    {
                        gpuFound.Add(gpuout);
                    }
                }
                filtred = 1;
            }
            else if (seriesString !="")
            {
                string[] seriesT = seriesString.Split('_');
                List<string> tempSeries = new List<string>();
                foreach (var serie in seriesT)
                {
                    gpuOut = gpu.Where(a => a.Product.Series.Name == serie).ToList();
                    if (serie != "")
                    {
                        tempSeries.Add(serie);
                    }
                    foreach (var gpuout in gpuOut)
                    {
                        gpuFound.Add(gpuout);
                    }
                }
                series = tempSeries;
                filtred = 1;
            }

            if (filtred == 1)
            {
                gpu.Clear();
                foreach (var add in gpuFound)
                {
                    gpu.Add(add);
                }
                gpuFound.Clear();
                filtred = 0;
            }

            // MANUFACTURERS
            if (gpu.Count() > 0)
            {
                if (manufacturers != null)
                {
                    foreach (var manu in manufacturers)
                    {
                        gpuOut = gpu.Where(a => a.Product.Manufacturer.Name == manu).ToList();
                        foreach (var gpuout in gpuOut)
                        {
                            gpuFound.Add(gpuout);
                        }
                    }
                    filtred = 1;
                }
                else if (manufacturersString != "")
                {
                    string[] manuT = manufacturersString.Split('_');
                    List<string> tempManu = new List<string>();
                    foreach (var manu in manuT)
                    {
                        gpuOut = gpu.Where(a => a.Product.Manufacturer.Name == manu).ToList();
                        if (manu != "")
                        {
                            tempManu.Add(manu);
                        }
                        foreach (var gpuout in gpuOut)
                        {
                            gpuFound.Add(gpuout);
                        }
                    }
                    manufacturers = tempManu;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                gpu.Clear();
                foreach (var add in gpuFound)
                {
                    gpu.Add(add);
                }
                gpuFound.Clear();
                filtred = 0;
            }

            // RAM 
            if (gpu.Count() > 0)
            {
                if (rams != null)
                {
                    foreach (var ram in rams)
                    {
                        gpuOut = gpu.Where(a => a.GpuRam.Name == ram).ToList();
                        foreach (var gpuout in gpuOut)
                        {
                            gpuFound.Add(gpuout);
                        }
                    }
                    filtred = 1;
                }
                else if (ramsString != "")
                {
                    string[] ramsT = ramsString.Split('_');
                    List<string> tempRams = new List<string>();
                    foreach (var ram in ramsT)
                    {
                        gpuOut = gpu.Where(a => a.GpuRam.Name == ram).ToList();
                        if (ram != "")
                        {
                            tempRams.Add(ram);
                        }
                        foreach (var gpuout in gpuOut)
                        {
                            gpuFound.Add(gpuout);
                        }
                    }
                    rams = tempRams;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                gpu.Clear();
                foreach (var add in gpuFound)
                {
                    gpu.Add(add);
                }
                gpuFound.Clear();
                filtred = 0;
            }

            // ILOŚĆ RAM

            if (ramMax > 0 || ramMin > 0)
            {
                if (gpu.Count() > 0)
                {
                    if (ramMax < 1) ramMax = 100;
                    if (ramMin < 1) ramMin = 0;

                    gpuOut = gpu.Where(a => a.Ram > ramMin && a.Ram < ramMax).ToList();
                    foreach (var gpuout in gpuOut)
                    {
                        gpuFound.Add(gpuout);
                    }
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                gpu.Clear();
                foreach (var add in gpuFound)
                {
                    gpu.Add(add);
                }
                gpuFound.Clear();
                filtred = 0;
            }

            // DŁUGOŚĆ

            if (lengthMax > 0)
            {
                if (gpu.Count() > 0)
                {
                    gpuOut = gpu.Where(a => a.Length <= lengthMax).ToList();
                    foreach (var gpuout in gpuOut)
                    {
                        gpuFound.Add(gpuout);
                    }
                    filtred = 1;
                }
            }
            else
            {
                lengthMax = 0;
            }

            if (filtred == 1)
            {
                gpu.Clear();
                foreach (var add in gpuFound)
                {
                    gpu.Add(add);
                }
                gpuFound.Clear();
                filtred = 0;
            }

            if(gpu.Count()>0)
            {
                var names = gpu.Select(a => a.Name).Distinct().ToList();
                foreach(var name in names)
                {
                    var add = gpu.Where(a => a.Name == name).Take(1).ToList();
                    gpuFound.Add(add[0]);
                }
                gpu = gpuFound;
            }


            List<string> emptyList = new List<string> { "" };
            if (manufacturers == null) manufacturers = emptyList;
            if (series == null) series = emptyList;
            if (rams == null) rams = emptyList;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (gpu.Count() > pageSize) page = 1;

            GpuListViewModel gpuListViewModel = new GpuListViewModel()
            {
                BenchmarkMax = benchmarkMax,
                PagedList = gpu.ToPagedList(pageNumber, pageSize),
                GpuFormCheckedViewModel = new GpuFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    SeriesChecked = series,
                    RamsChecked = rams,
                    RamMaxChecked = ramMax,
                    RamMinChecked = ramMin,
                    LengthMaxChecked = lengthMax
                }
            };

            return View(gpuListViewModel);
        }

        [ChildActionOnly]
        public ActionResult Form(GpuFormCheckedViewModel checkd)
        {
            var gpus = context.Gpu.ToList();

            var manufacturers = gpus.OrderBy(a => a.Product.Manufacturer.Name)
                                    .Select(a => a.Product.Manufacturer.Name)
                                    .Distinct().ToList();

            var series = gpus.OrderBy(a => a.Product.Series.Name)
                                .Select(a => a.Product.Series.Name)
                                .Distinct().ToList();

            var rams = gpus.OrderBy(a => a.GpuRam.Name)
                                .Select(a => a.GpuRam.Name)
                                .Distinct().ToList();

            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.SeriesChecked == null) checkd.SeriesChecked = emptyList;
            if (checkd.RamsChecked == null) checkd.RamsChecked = emptyList;

            var gpuFormViewModel = new GpuFormViewModel()
            {
                Manufacturers = manufacturers,
                Gpus = gpus,
                Rams = rams,
                Series = series,
                GpuFormCheckedViewModel = checkd
            };

            return PartialView("_Form", gpuFormViewModel);
        }

        public ActionResult GpuDetails(int id, string name)
        {
            var gpus = context.Gpu.ToList();
            var gpu = gpus.Find(a => a.GpuId == id);
            var gpuList = gpus.Where(a => a.Name == gpu.Name).ToList();
            var benchmarkMax = gpus.Max(a => a.Benchmark);
            List<string> prices = new List<string>();

            foreach (Gpu g in gpuList)
            {
                prices.Add(Functions.GetPrice(g));
            }


            var gpuDetailsViewModel = new GpuDetailsViewModel()
            {
                Gpu = gpu,
                GpuList = gpuList,
                Prices = prices,
                BenchmarkMax = benchmarkMax,
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

            return View(gpuDetailsViewModel);
        }

    }
}
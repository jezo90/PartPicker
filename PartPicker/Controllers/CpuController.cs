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

        public ActionResult CpuList(List<string> series, List<string> sockets, int? page, string gpu = "",
                                    int coresMin = 0, int coresMax = 0, string seriesString = "", string socketsString = "")
        {
            if (coresMin != 0 || coresMax != 0)
            {
                if (coresMin > coresMax && coresMin != 0 && coresMax != 0)
                {
                    var temp = coresMin;
                    coresMin = coresMax;
                    coresMax = temp;
                }
            }
            var cpu = context.Cpu.ToList();
            var benchmarkMax = context.Cpu.Max(a => a.Benchmark);
            List<Cpu> cpuOut = new List<Cpu>();
            List<Cpu> cpuFound = new List<Cpu>();
            int filtred = 0;

            // SERIE
            if (series != null)
            {
                foreach (var serie in series)
                {
                    cpuOut = cpu.Where(a => a.Product.Series.Name == serie).ToList();
                    foreach (var cpuout in cpuOut)
                    {
                        cpuFound.Add(cpuout);
                    }
                }
                filtred = 1;
            }
            else if (seriesString != "")
            {
                string[] seriesT = seriesString.Split('_');
                List<string> tempSeries = new List<string>();
                foreach (var serie in seriesT)
                {
                    cpuOut = cpu.Where(a => a.Product.Series.Name == serie).ToList();
                    if (serie != "")
                    {
                        tempSeries.Add(serie);
                    }
                    foreach (var cpuout in cpuOut)
                    {
                        cpuFound.Add(cpuout);
                    }
                }
                series = tempSeries;
                filtred = 1;
            }

            if (filtred == 1)
            {
                cpu.Clear();
                foreach(var add in cpuFound)
                {
                    cpu.Add(add);
                }
                cpuFound.Clear();
                filtred = 0;
            }

            // SOCKET
            if (cpu.Count() > 0)
            {
                if (sockets != null)
                {
                    foreach (var socket in sockets)
                    {
                        cpuOut = cpu.Where(a => a.Socket.Name == socket).ToList();
                        foreach (var cpuout in cpuOut)
                        {
                            cpuFound.Add(cpuout);
                        }
                    }
                    filtred = 1;
                }
                else if (socketsString != "")
                {
                    string[] socketsT = socketsString.Split('_');
                    List<string> tempSockets = new List<string>();
                    foreach (var socket in socketsT)
                    {
                        cpuOut = cpu.Where(a => a.Socket.Name == socket).ToList();
                        if (socket != "")
                        {
                            tempSockets.Add(socket);
                        }
                        foreach (var cpuout in cpuOut)
                        {
                            cpuFound.Add(cpuout);
                        }
                    }
                    sockets = tempSockets;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                cpu.Clear();
                foreach (var add in cpuFound)
                {
                    cpu.Add(add);
                }
                cpuFound.Clear();
                filtred = 0;
            }

            // GPU
            if (gpu != "")
            {
                if (cpu.Count() > 0)
                {
                    if (gpu == "true")
                    {
                        cpuOut = cpu.Where(a => a.Gpu != "Brak").ToList();
                        foreach (var cpuout in cpuOut)
                        {
                            cpuFound.Add(cpuout);
                        }
                        filtred = 1;
                    }
                    else if (gpu == "false")
                    {
                        cpuOut = cpu.Where(a => a.Gpu == "Brak").ToList();
                        foreach (var cpuout in cpuOut)
                        {
                            cpuFound.Add(cpuout);
                        }
                        filtred = 1;
                    }
                }
            }

            if (filtred == 1)
            {
                cpu.Clear();
                foreach (var add in cpuFound)
                {
                    cpu.Add(add);
                }
                cpuFound.Clear();
                filtred = 0;
            }

            // CORES
            if (coresMax > 0 || coresMin > 0)
            {
                if (cpu.Count() > 0)
                {
                    if (coresMax < 1) coresMax = 100;
                    if (coresMin < 1) coresMin = 0;

                    cpuOut = cpu.Where(a => a.Cores > coresMin && a.Cores < coresMax).ToList();
                    foreach (var cpuout in cpuOut)
                    {
                        cpuFound.Add(cpuout);
                    }
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                cpu.Clear();
                foreach (var add in cpuFound)
                {
                    cpu.Add(add);
                }
                cpuFound.Clear();
                filtred = 0;
            }

            if (cpu.Count() > 0)
            {
                var names = cpu.Select(a => a.Name).Distinct().ToList();
                foreach (var name in names)
                {
                    var add = cpu.Where(a => a.Name == name).Take(1).ToList();
                    cpuFound.Add(add[0]);
                }
                cpu = cpuFound;
            }


            List<string> manufacturers = new List<string>();
            List<string> emptyList = new List<string> { "" };
            if (series == null) manufacturers = emptyList;
            if (series == null) series = emptyList;
            else
            {
                foreach(var serie in series)
                {
                    var manu = context.Product.Where(a => a.Series.Name == serie).Select(a => a.Manufacturer.Name).ToList();
                    manufacturers.Add(manu[0]);
                }
            }
            if (sockets == null) sockets = emptyList;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (cpu.Count() > pageSize) page = 1;
            CpuListViewModel cpuListViewModel = new CpuListViewModel()
            {
                BenchmarkMax = benchmarkMax,
                PagedList = cpu.ToPagedList(pageNumber, pageSize),
                CpuFormCheckedViewModel = new CpuFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    SeriesChecked = series,
                    SocketsChecked = sockets,
                    CoresMaxChecked = coresMax,
                    CoresMinChecked = coresMin,
                    GpuChecked = gpu
                }
            };

            return View(cpuListViewModel);
        }

        [ChildActionOnly]
        public ActionResult Form(CpuFormCheckedViewModel checkd)
        {
            var cpus = context.Cpu.ToList();

            var manufacturers = cpus.OrderBy(a => a.Product.Manufacturer.Name)
                                    .Select(a => a.Product.Manufacturer.Name)
                                    .Distinct().ToList();

            var series = cpus.OrderBy(a => a.Product.Series.Name)
                                .Select(a => a.Product.Series.Name)
                                .Distinct().ToList();

            var sockets = context.Socket.OrderBy(a => a.Name)
                                .Select(a => a.Name)
                                .ToList();

            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.SeriesChecked == null) checkd.SeriesChecked = emptyList;
            if (checkd.SocketsChecked == null) checkd.SocketsChecked = emptyList;
            if (checkd.GpuChecked == null) checkd.GpuChecked = "";

            var cpuFormViewModel = new CpuFormViewModel()
            {
                Manufacturers = manufacturers,
                Cpus = cpus,
                Sockets = sockets,
                Series = series,
                CpuFormCheckedViewModel = checkd
            };

            return PartialView("_Form", cpuFormViewModel);
        }

        public ActionResult CpuDetails(int id, string name)
        {
            var cpus = context.Cpu.ToList();
            var cpu = cpus.Find(a => a.CpuId == id);
            var cpuList = cpus.Where(a => a.Name == cpu.Name).ToList();
            var benchmarkMax = cpus.Max(a => a.Benchmark);
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

            return View(cpuDetailsViewModel);
        }
    }
}
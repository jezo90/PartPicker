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

namespace PartPicker.Controllers
{
    public class MoboController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public MoboController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MoboList(List<string> manufacturers, List<string> sockets, List<string> formFactor, List<string> rams,
                                    int? page, string manufacturersString = "", string socketsString = "", string ramsString = "", 
                                    string formsString = "")
        {
            var mobo = context.Mobo.ToList();
            List<Mobo> moboOut = new List<Mobo>();
            List<Mobo> moboFound = new List<Mobo>();
            int filtred = 0;

            // MANUFACTURERS
            if (manufacturers != null)
            {
                foreach (var manu in manufacturers)
                {
                    moboOut = mobo.Where(a => a.Manufacturer.Name == manu).ToList();
                    foreach (var moboout in moboOut)
                    {
                        moboFound.Add(moboout);
                    }
                }
                filtred = 1;
            }
            else if (manufacturersString != "")
            {
                string[] manusT = manufacturersString.Split('_');
                List<string> tempManus = new List<string>();
                foreach (var manu in manusT)
                {
                    moboOut = mobo.Where(a => a.Manufacturer.Name == manu).ToList();
                    if (manu != "")
                    {
                        tempManus.Add(manu);
                    }
                    foreach (var moboout in moboOut)
                    {
                        moboFound.Add(moboout);
                    }
                }
                manufacturers = tempManus;
                filtred = 1;
            }

            if (filtred == 1)
            {
                mobo.Clear();
                foreach (var add in moboFound)
                {
                    mobo.Add(add);
                }
                moboFound.Clear();
                filtred = 0;
            }

            // SOCKET
            if (mobo.Count() > 0)
            {
                if (sockets != null)
                {
                    foreach (var socket in sockets)
                    {
                        moboOut = mobo.Where(a => a.Socket.Name == socket).ToList();
                        foreach (var moboout in moboOut)
                        {
                            moboFound.Add(moboout);
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
                        moboOut = mobo.Where(a => a.Socket.Name == socket).ToList();
                        if (socket != "")
                        {
                            tempSockets.Add(socket);
                        }
                        foreach (var moboout in moboOut)
                        {
                            moboFound.Add(moboout);
                        }
                    }
                    sockets = tempSockets;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                mobo.Clear();
                foreach (var add in moboFound)
                {
                    mobo.Add(add);
                }
                moboFound.Clear();
                filtred = 0;
            }

            // FORMFACTOR
            if (mobo.Count() > 0)
            {
                if (formFactor != null)
                {
                    foreach (var form in formFactor)
                    {
                        moboOut = mobo.Where(a => a.FormFactor.Name == form).ToList();
                        foreach (var moboout in moboOut)
                        {
                            moboFound.Add(moboout);
                        }
                    }
                    filtred = 1;
                }
                else if (formsString != "")
                {
                    string[] formsT = formsString.Split('_');
                    List<string> tempForms = new List<string>();
                    foreach (var form in formsT)
                    {
                        moboOut = mobo.Where(a => a.FormFactor.Name == form).ToList();
                        if (form != "")
                        {
                            tempForms.Add(form);
                        }
                        foreach (var moboout in moboOut)
                        {
                            moboFound.Add(moboout);
                        }
                    }
                    formFactor = tempForms;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                mobo.Clear();
                foreach (var add in moboFound)
                {
                    mobo.Add(add);
                }
                moboFound.Clear();
                filtred = 0;
            }

            // RAM TYPE
            if (mobo.Count() > 0)
            {
                if (rams != null)
                {
                    foreach (var ram in rams)
                    {
                        moboOut = mobo.Where(a => a.RamType.Name == ram).ToList();
                        foreach (var moboout in moboOut)
                        {
                            moboFound.Add(moboout);
                        }
                    }
                    filtred = 1;
                }
                else if (ramsString != "")
                {
                    string[] ramT = ramsString.Split('_');
                    List<string> tempRam = new List<string>();
                    foreach (var ram in ramT)
                    {
                        moboOut = mobo.Where(a => a.RamType.Name == ram).ToList();
                        if (ram != "")
                        {
                            tempRam.Add(ram);
                        }
                        foreach (var moboout in moboOut)
                        {
                            moboFound.Add(moboout);
                        }
                    }
                    rams = tempRam;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                mobo.Clear();
                foreach (var add in moboFound)
                {
                    mobo.Add(add);
                }
                moboFound.Clear();
                filtred = 0;
            }
            

            if (mobo.Count() > 0)
            {
                var names = mobo.Select(a => a.Name).Distinct().ToList();
                foreach (var name in names)
                {
                    var add = mobo.Where(a => a.Name == name).Take(1).ToList();
                    moboFound.Add(add[0]);
                }
                mobo = moboFound;
            }

            List<string> emptyList = new List<string> { "" };
            if (manufacturers == null) manufacturers = emptyList;
            if (sockets == null) sockets = emptyList;
            if (rams == null) rams = emptyList;
            if (formFactor == null) formFactor = emptyList;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (mobo.Count() > pageSize) page = 1;
            MoboListViewModel moboListViewModel = new MoboListViewModel()
            {
                PagedList = mobo.ToPagedList(pageNumber, pageSize),
                MoboFormCheckedViewModel = new MoboFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    FormFactorChecked = formFactor,
                    SocketsChecked = sockets,
                    RamTypeChecked = rams
                }
            };

            return View(moboListViewModel);
        }


        [ChildActionOnly]
        public ActionResult Form(MoboFormCheckedViewModel checkd)
        {
            var mobos = context.Mobo.ToList();

            var manufacturers = mobos.OrderBy(a => a.Manufacturer.Name)
                                    .Select(a => a.Manufacturer.Name)
                                    .Distinct().ToList();

            var rams = mobos.OrderBy(a => a.RamType.Name)
                                .Select(a => a.RamType.Name)
                                .Distinct().ToList();

            var sockets = context.Socket.OrderBy(a => a.Name)
                                .Select(a => a.Name)
                                .ToList();

            var form = context.FormFactor.OrderBy(a => a.Name)
                                .Select(a => a.Name)
                                .ToList();


            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.FormFactorChecked == null) checkd.FormFactorChecked = emptyList;
            if (checkd.SocketsChecked == null) checkd.SocketsChecked = emptyList;
            if (checkd.RamTypeChecked == null) checkd.RamTypeChecked = emptyList;

            var moboFormViewModel = new MoboFormViewModel()
            {
                Manufacturers = manufacturers,
                Mobos = mobos,
                Sockets = sockets,
                RamType = rams,
                FormFactor = form,
                MoboFormCheckedViewModel = checkd
            };

            return PartialView("_Form", moboFormViewModel);
        }

        public ActionResult MoboDetails(int id, string name)
        {
            var mobos = context.Mobo.ToList();
            var mobo = mobos.Find(a => a.MoboId == id);
            var moboList = mobos.Where(a => a.Name == mobo.Name).ToList();
            List<string> prices = new List<string>();

            foreach (var m in moboList)
            {
                prices.Add(Functions.GetPrice(m));
            }


            var moboDetailsViewModel = new MoboDetailsViewModel()
            {
                Mobo = mobo,
                MoboList = moboList,
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

            return View(moboDetailsViewModel);
        }
    }
}
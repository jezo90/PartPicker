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
    public class PsuController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public PsuController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PsuList(List<string> manufacturers, List<string> formFactor, int? page, int powerMax = 0,
                                    int powerMin = 0, string manufacturersString = "", string formsString = "")
        {
            var psu = context.Psu.ToList();
            List<Psu> psuOut = new List<Psu>();
            List<Psu> psuFound = new List<Psu>();
            int filtred = 0;

            if (powerMin != 0 || powerMax != 0)
            {
                if (powerMin > powerMax && powerMin != 0 && powerMax != 0)
                {
                    var temp = powerMin;
                    powerMin = powerMax;
                    powerMax = temp;
                }
            }

            // MANUFACTURERS
            if (manufacturers != null)
            {
                foreach (var manu in manufacturers)
                {
                    psuOut = psu.Where(a => a.Manufacturer.Name == manu).ToList();
                    foreach (var psuout in psuOut)
                    {
                        psuFound.Add(psuout);
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
                    psuOut = psu.Where(a => a.Manufacturer.Name == manu).ToList();
                    if (manu != "")
                    {
                        tempManus.Add(manu);
                    }
                    foreach (var psuout in psuOut)
                    {
                        psuFound.Add(psuout);
                    }
                }
                manufacturers = tempManus;
                filtred = 1;
            }

            if (filtred == 1)
            {
                psu.Clear();
                foreach (var add in psuFound)
                {
                    psu.Add(add);
                }
                psuFound.Clear();
                filtred = 0;
            }

            // FORMFACTOR
            if (psu.Count() > 0)
            {
                if (formFactor != null)
                {
                    foreach (var form in formFactor)
                    {
                        psuOut = psu.Where(a => a.FormFactor.Name == form).ToList();
                        foreach (var psuout in psuOut)
                        {
                            psuFound.Add(psuout);
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
                        psuOut = psu.Where(a => a.FormFactor.Name == form).ToList();
                        if (form != "")
                        {
                            tempForms.Add(form);
                        }
                        foreach (var psuout in psuOut)
                        {
                            psuFound.Add(psuout);
                        }
                    }
                    formFactor = tempForms;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                psu.Clear();
                foreach (var add in psuFound)
                {
                    psu.Add(add);
                }
                psuFound.Clear();
                filtred = 0;
            }


            // ILOŚĆ RAM
            if (powerMax > 0 || powerMin > 0)
            {
                if (psu.Count() > 0)
                {
                    if (powerMax < 1) powerMax = 1000;
                    if (powerMin < 1) powerMin = 0;

                    psuOut = psu.Where(a => a.Power >= powerMin && a.Power <= powerMax).ToList();
                    foreach (var psuout in psuOut)
                    {
                        psuFound.Add(psuout);
                    }
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                psu.Clear();
                foreach (var add in psuFound)
                {
                    psu.Add(add);
                }
                psuFound.Clear();
                filtred = 0;
            }

            if (psu.Count() > 0)
            {
                var names = psu.Select(a => a.Name).Distinct().ToList();
                foreach (var name in names)
                {
                    var add = psu.Where(a => a.Name == name).Take(1).ToList();
                    psuFound.Add(add[0]);
                }
                psu = psuFound;
            }

            List<string> emptyList = new List<string> { "" };
            if (manufacturers == null) manufacturers = emptyList;
            if (formFactor == null) formFactor = emptyList;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (psu.Count() > pageSize) page = 1;
            PsuListViewModel psuListViewModel = new PsuListViewModel()
            {
                PagedList = psu.ToPagedList(pageNumber, pageSize),
                PsuFormCheckedViewModel = new PsuFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    FormFactorChecked = formFactor,
                    PowerMax = powerMax,
                    PowerMin = powerMin
                }
            };

            return View(psuListViewModel);
        }


        [ChildActionOnly]
        public ActionResult Form(PsuFormCheckedViewModel checkd)
        {
            var psus = context.Psu.ToList();

            var manufacturers = psus.OrderBy(a => a.Manufacturer.Name)
                                    .Select(a => a.Manufacturer.Name)
                                    .Distinct().ToList();

            var form = context.FormFactor.OrderBy(a => a.Name)
                                .Select(a => a.Name)
                                .ToList();


            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.FormFactorChecked == null) checkd.FormFactorChecked = emptyList;

            var psuFormViewModel = new PsuFormViewModel()
            {
                Manufacturers = manufacturers,
                FormFactor = form,
                Psus = psus,
                PsuFormCheckedViewModel = checkd
            };

            return PartialView("_Form", psuFormViewModel);
        }


        public ActionResult PsuDetails(int id, string name)
        {
            var psus = context.Psu.ToList();
            var psu = psus.Find(a => a.PsuId == id);
            var psuList = psus.Where(a => a.Name == psu.Name).ToList();
            List<string> prices = new List<string>();

            foreach (var p in psuList)
            {
                prices.Add(Functions.GetPrice(p));
            }


            var psuDetailsViewModel = new PsuDetailsViewModel()
            {
                Psu = psu,
                PsuList = psuList,
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

            return View(psuDetailsViewModel);
        }

    }
}
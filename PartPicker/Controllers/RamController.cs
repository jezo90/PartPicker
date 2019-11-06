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
    public class RamController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public RamController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ramList(List<string> manufacturers, List<string> types, int? page, 
                                     int ramMin = 0, int ramMax = 0, string manufacturersString = "", string typesString = "")
        {
            var ram = context.Ram.ToList();
            List<Ram> ramOut = new List<Ram>();
            List<Ram> ramFound = new List<Ram>();
            int filtred = 0;

            // MANUFACTURERS
            if (manufacturers != null)
            {
                foreach (var manu in manufacturers)
                {
                    ramOut = ram.Where(a => a.Manufacturer.Name == manu).ToList();
                    foreach (var ramout in ramOut)
                    {
                        ramFound.Add(ramout);
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
                    ramOut = ram.Where(a => a.Manufacturer.Name == manu).ToList();
                    if (manu != "")
                    {
                        tempManus.Add(manu);
                    }
                    foreach (var ramout in ramOut)
                    {
                        ramFound.Add(ramout);
                    }
                }
                manufacturers = tempManus;
                filtred = 1;
            }

            if (filtred == 1)
            {
                ram.Clear();
                foreach (var add in ramFound)
                {
                    ram.Add(add);
                }
                ramFound.Clear();
                filtred = 0;
            }

            // RAM TYPE
            if (ram.Count() > 0)
            {
                if (types != null)
                {
                    foreach (var type in types)
                    {
                        ramOut = ram.Where(a => a.RamType.Name == type).ToList();
                        foreach (var ramout in ramOut)
                        {
                            ramFound.Add(ramout);
                        }
                    }
                    filtred = 1;
                }
                else if (typesString != "")
                {
                    string[] typesT = typesString.Split('_');
                    List<string> tempTypes = new List<string>();
                    foreach (var type in typesT)
                    {
                        ramOut = ram.Where(a => a.RamType.Name == type).ToList();
                        if (type != "")
                        {
                            tempTypes.Add(type);
                        }
                        foreach (var ramout in ramOut)
                        {
                            ramFound.Add(ramout);
                        }
                    }
                    types = tempTypes;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                ram.Clear();
                foreach (var add in ramFound)
                {
                    ram.Add(add);
                }
                ramFound.Clear();
                filtred = 0;
            }


            if (ramMax > 0 || ramMin > 0)
            {
                if (ram.Count() > 0)
                {
                    if (ramMax < 1) ramMax = 100;
                    if (ramMin < 1) ramMin = 0;

                    ramOut = ram.Where(a => a.Size >= ramMin && a.Size <= ramMax).ToList();
                    foreach (var ramout in ramOut)
                    {
                        ramFound.Add(ramout);
                    }
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                ram.Clear();
                foreach (var add in ramFound)
                {
                    ram.Add(add);
                }
                ramFound.Clear();
                filtred = 0;
            }

            if (ram.Count() > 0)
            {
                var names = ram.Select(a => a.Name).Distinct().ToList();
                foreach (var name in names)
                {
                    var add = ram.Where(a => a.Name == name).Take(1).ToList();
                    ramFound.Add(add[0]);
                }
                ram = ramFound;
            }

            List<string> emptyList = new List<string> { "" };
            if (manufacturers == null) manufacturers = emptyList;
            if (types == null) types = emptyList;


            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (ram.Count() > pageSize) page = 1;
            RamListViewModel ramListViewModel = new RamListViewModel()
            {
                PagedList = ram.ToPagedList(pageNumber, pageSize),
                RamFormCheckedViewModel = new RamFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    TypeChecked = types,
                    AmountMaxChecked = ramMax,
                    AmountMinChecked = ramMin
                }
            };

            return View(ramListViewModel);
        }

        [ChildActionOnly]
        public ActionResult Form(RamFormCheckedViewModel checkd)
        {
            var rams = context.Ram.ToList();

            var manufacturers = rams.OrderBy(a => a.Manufacturer.Name)
                                    .Select(a => a.Manufacturer.Name)
                                    .Distinct().ToList();

            var types = rams.OrderBy(a => a.RamType.Name)
                                .Select(a => a.RamType.Name)
                                .Distinct().ToList(); 


            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.TypeChecked == null) checkd.TypeChecked = emptyList;

            var ramFormViewModel = new RamFormViewModel()
            {
                Manufacturers = manufacturers,
                Rams = rams,
                Types = types,
                RamFormCheckedViewModel = checkd
            };

            return PartialView("_Form", ramFormViewModel);
        }

        public ActionResult RamDetails(int id, string name)
        {
            var rams = context.Ram.ToList();
            var ram = rams.Find(a => a.RamId == id);
            var ramList = rams.Where(a => a.Name == ram.Name).ToList();
            List<string> prices = new List<string>();

            foreach (var m in ramList)
            {
                prices.Add(Functions.GetPrice(m));
            }


            var ramDetailsViewModel = new RamDetailsViewModel()
            {
                Ram = ram,
                RamList = ramList,
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

            return View(ramDetailsViewModel);
        }

    }
}
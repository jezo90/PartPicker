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
    public class StorageController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public StorageController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StorageList(List<string> types, List<string> interfaces, List<string> manufacturers, int? page,
                                    int capacityMin = 0, int capacityMax = 0, string typesString = "", string interfacesString = "", string manufacturersString = "")
        {
            if (capacityMin != 0 || capacityMax != 0)
            {
                if (capacityMin > capacityMax && capacityMin != 0 && capacityMax != 0)
                {
                    var temp = capacityMin;
                    capacityMin = capacityMax;
                    capacityMax = temp;
                }
            }

            var storage = context.Storage.ToList();
            List<Storage> storageOut = new List<Storage>();
            List<Storage> storageFound = new List<Storage>();
            int filtred = 0;

            if (types != null)
            {
                foreach (var type in types)
                {
                    storageOut = storage.Where(a => a.Type == type).ToList();
                    foreach (var storageout in storageOut)
                    {
                        storageFound.Add(storageout);
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
                    storageOut = storage.Where(a => a.Type == type).ToList();
                    if (type != "")
                    {
                        tempTypes.Add(type);
                    }
                    foreach (var storageout in storageOut)
                    {
                        storageFound.Add(storageout);
                    }
                }
                types = tempTypes;
                filtred = 1;
            }

            if (filtred == 1)
            {
                storage.Clear();
                foreach (var add in storageFound)
                {
                    storage.Add(add);
                }
                storageFound.Clear();
                filtred = 0;
            }

            // MANUFACTURERS
            if (storage.Count() > 0)
            {
                if (manufacturers != null)
                {
                    foreach (var manu in manufacturers)
                    {
                        storageOut = storage.Where(a => a.Manufacturer.Name == manu).ToList();
                        foreach (var storageout in storageOut)
                        {
                            storageFound.Add(storageout);
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
                        storageOut = storage.Where(a => a.Manufacturer.Name == manu).ToList();
                        if (manu != "")
                        {
                            tempManu.Add(manu);
                        }
                        foreach (var storageout in storageOut)
                        {
                            storageFound.Add(storageout);
                        }
                    }
                    manufacturers = tempManu;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                storage.Clear();
                foreach (var add in storageFound)
                {
                    storage.Add(add);
                }
                storageFound.Clear();
                filtred = 0;
            }

            // INTERFACE 
            if (storage.Count() > 0)
            {
                if (interfaces != null)
                {
                    foreach (var interf in interfaces)
                    {
                        storageOut = storage.Where(a => a.Interface.Name == interf).ToList();
                        foreach (var storageout in storageOut)
                        {
                            storageFound.Add(storageout);
                        }
                    }
                    filtred = 1;
                }
                else if (interfacesString != "")
                {
                    string[] interfacesT = interfacesString.Split('_');
                    List<string> tempInterfaces = new List<string>();
                    foreach (var interf in interfacesT)
                    {
                        storageOut = storage.Where(a => a.Interface.Name == interf).ToList();
                        if (interf != "")
                        {
                            tempInterfaces.Add(interf);
                        }
                        foreach (var storageout in storageOut)
                        {
                            storageFound.Add(storageout);
                        }
                    }
                    interfaces = tempInterfaces;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                storage.Clear();
                foreach (var add in storageFound)
                {
                    storage.Add(add);
                }
                storageFound.Clear();
                filtred = 0;
            }

            // POJEMNOŚĆ

            if (capacityMax > 0 || capacityMin > 0)
            {
                if (storage.Count() > 0)
                {
                    if (capacityMax < 1) capacityMax = 10000;
                    if (capacityMin < 1) capacityMin = 0;

                    storageOut = storage.Where(a => a.Capacity >= capacityMin && a.Capacity <= capacityMax).ToList();
                    foreach (var add in storageFound)
                    {
                        storage.Add(add);
                    }
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                storage.Clear();
                foreach (var add in storageFound)
                {
                    storage.Add(add);
                }
                storageFound.Clear();
                filtred = 0;
            }

            
            if (storage.Count() > 0)
            {
                var names = storage.Select(a => a.Name).Distinct().ToList();
                foreach (var name in names)
                {
                    var add = storage.Where(a => a.Name == name).Take(1).ToList();
                    storageFound.Add(add[0]);
                }
                storage = storageFound;
            }


            List<string> emptyList = new List<string> { "" };
            if (manufacturers == null) manufacturers = emptyList;
            if (types == null) types = emptyList;
            if (interfaces == null) interfaces = emptyList;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (storage.Count() > pageSize) page = 1;

            StorageListViewModel storageListViewModel = new StorageListViewModel()
            {
                PagedList = storage.ToPagedList(pageNumber, pageSize),
                StorageFormCheckedViewModel = new StorageFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    InterfaceChecked = interfaces,
                    CapacityMaxChecked = capacityMax,
                    CapacityMinChecked = capacityMin,
                    TypeChecked = types
                }
            };

            return View(storageListViewModel);
        }



        [ChildActionOnly]
        public ActionResult Form(StorageFormCheckedViewModel checkd)
        {
            var storages = context.Storage.ToList();

            var manufacturers = storages.OrderBy(a => a.Manufacturer.Name)
                                    .Select(a => a.Manufacturer.Name)
                                    .Distinct().ToList();

            var types = storages.OrderBy(a => a.Type)
                                .Select(a => a.Type)
                                .Distinct().ToList();

            var interfaces = context.Interface.OrderBy(a => a.Name)
                                .Select(a => a.Name)
                                .ToList();

            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.InterfaceChecked == null) checkd.InterfaceChecked = emptyList;
            if (checkd.TypeChecked == null) checkd.TypeChecked = emptyList;

            var storageFormViewModel = new StorageFormViewModel()
            {
                Manufacturers = manufacturers,
                Storages = storages,
                Types = types,
                Interfaces = interfaces,
                StorageFormCheckedViewModel = checkd
            };

            return PartialView("_Form", storageFormViewModel);
        }

        public ActionResult StorageDetails(int id, string name)
        {
            var storages = context.Storage.ToList();
            var storage = storages.Find(a => a.StorageId == id);
            var storageList = storages.Where(a => a.Name == storage.Name).ToList();
            List<string> prices = new List<string>();

            foreach (Storage s in storageList)
            {
                prices.Add(Functions.GetPrice(s));
            }


            var storageDetailsViewModel = new StorageDetailsViewModel()
            {
                Storage = storage,
                StorageList = storageList,
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

            return View(storageDetailsViewModel);
        }

    }
}
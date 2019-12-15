using PartPicker.DAL;
using PartPicker.Models;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Controllers
{
    public class PartsController : Controller
    {
        private PickerContext context = new PickerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCpu(string name, string model, string link, int cores, string frequency, string turbo, string gpu,
                                    int benchmark, int productId, int socketId, int shopId, string image)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {

                double freqD = Convert.ToDouble(frequency);
                double turboD = Convert.ToDouble(turbo);

                var cpuToAdd = new Cpu()
                {
                    Name = name,
                    Model = model,
                    Link = link,
                    Cores = cores,
                    Frequency = freqD,
                    Turbo = turboD,
                    Gpu = gpu,
                    Benchmark = benchmark,
                    ProductId = productId,
                    SocketId = socketId,
                    ShopId = shopId,
                    Image = image
                };

                context.Cpu.Add(cpuToAdd);
                context.SaveChanges();

                return RedirectToAction("CpuAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult CpuAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var products = context.Product.ToList();
                var sockets = context.Socket.ToList();
                var shops = context.Shop.ToList();

                var addCpuFormViewModel = new AddCpuFormViewModel()
                {
                    Products = products,
                    Shops = shops,
                    Sockets = sockets
                };

                return View("CpuAddForm", addCpuFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AddGpu(string name, string model, string link, int ram, string frequency, string frequencyBoost, int length,
                                    int benchmark, int productId, int gpuRamId, int shopId, string image)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {

                double freqD = Convert.ToDouble(frequency);
                double freqBoostD = Convert.ToDouble(frequencyBoost);

                var gpuToAdd = new Gpu()
                {
                    Name = name,
                    ProductId = productId,
                    Model = model,
                    Link = link,
                    Ram = ram,
                    GpuRamId = gpuRamId,
                    Frequency = freqD,
                    FrequencyBoost = freqBoostD,
                    Length = length,
                    Benchmark = benchmark,
                    Image = image,
                    ShopId = shopId
                };

                context.Gpu.Add(gpuToAdd);
                context.SaveChanges();

                return RedirectToAction("GpuAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult MoboAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var manufacturers = context.Manufacturer.ToList();
                var formFactors = context.FormFactor.ToList();
                var sockets = context.Socket.ToList();
                var ramType = context.RamType.ToList();
                var shops = context.Shop.ToList();

                var addMoboFormViewModel = new AddMoboFormViewModel()
                {
                    Manufacturers = manufacturers,
                    FormFactors = formFactors,
                    RamTypes = ramType,
                    Shops = shops,
                    Sockets = sockets
                };

                return View("MoboAddForm", addMoboFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AddMobo(string name, string model, string link, int ramSlots, int maxRam, int sataSlots,
                                    int manufacturerId, int formFactorId, int ramTypeId, int socketId, int shopId, string image)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var moboToAdd = new Mobo()
                {
                    Name = name,
                    ManufacturerId = manufacturerId,
                    Model = model,
                    Link = link,
                    FormFactorId = formFactorId,
                    SocketId = socketId,
                    RamSlots = ramSlots,
                    RamTypeId = ramTypeId,
                    MaxRam = maxRam,
                    SataSlots = sataSlots,
                    Image = image,
                    ShopId = shopId
                };

                context.Mobo.Add(moboToAdd);
                context.SaveChanges();

                return RedirectToAction("MoboAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult GpuAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var products = context.Product.ToList();
                var gpuRams = context.GpuRam.ToList();
                var shops = context.Shop.ToList();

                var addGpuFormViewModel = new AddGpuFormViewModel()
                {
                    Products = products,
                    Shops = shops,
                    GpuRams = gpuRams
                };

                return View("GpuAddForm", addGpuFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AddRam(string name, int manufacturerId, string model, string link, int ramTypeId, int amount,
                                    int size, int frequency, int cl, string image, int shopId)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var ramToAdd = new Ram()
                {
                    Name = name,
                    ManufacturerId = manufacturerId,
                    Model = model,
                    Link = link,
                    RamTypeId = ramTypeId,
                    Amount = amount,
                    Size = size,
                    Frequency = frequency,
                    Cl = cl,
                    Image = image,
                    ShopId = shopId
                };

                context.Ram.Add(ramToAdd);
                context.SaveChanges();

                return RedirectToAction("RamAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult RamAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var manufacturers = context.Manufacturer.ToList();
                var ramTypes = context.RamType.ToList();
                var shops = context.Shop.ToList();

                var addRamFormViewModel = new AddRamFormViewModel()
                {
                    RamTypes = ramTypes,
                    Shops = shops,
                    Manufacturers = manufacturers
                };

                return View("RamAddForm", addRamFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AddCase(string name, int manufacturerId, string model, string link, int formFactorId, int fans,
                                    int gpuLenght, string image, int shopId)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var caseToAdd = new Case()
                {
                    Name = name,
                    ManufacturerId = manufacturerId,
                    Model = model,
                    Link = link,
                    FormFactorId = formFactorId,
                    Fans = fans,
                    GpuLenght = gpuLenght,
                    Image = image,
                    ShopId = shopId
                };

                context.Case.Add(caseToAdd);
                context.SaveChanges();

                return RedirectToAction("CaseAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult CaseAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var manufacturers = context.Manufacturer.ToList();
                var formFactors = context.FormFactor.ToList();
                var shops = context.Shop.ToList();

                var addCaseFormViewModel = new AddCaseFormViewModel()
                {
                    FormFactors = formFactors,
                    Shops = shops,
                    Manufacturers = manufacturers
                };

                return View("CaseAddForm", addCaseFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AddStorage(string name, int manufacturerId, string model, string link, string type, int capacity, 
                                        int interfaceId, string size, string image, int shopId)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                double sizeD = Convert.ToDouble(size);
                var storageToAdd = new Storage()
                {
                    Name = name,
                    ManufacturerId = manufacturerId,
                    Model = model,
                    Link = link,
                    Type = type,
                    Capacity = capacity,
                    InterfaceId = interfaceId,
                    Size = sizeD,
                    Image = image,
                    ShopId = shopId
                };

                context.Storage.Add(storageToAdd);
                context.SaveChanges();

                return RedirectToAction("StorageAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult StorageAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var manufacturers = context.Manufacturer.ToList();
                var interfaces = context.Interface.ToList();
                var shops = context.Shop.ToList();

                var addStorageFormViewModel = new AddStorageFormViewModel()
                {
                    Interfaces = interfaces,
                    Shops = shops,
                    Manufacturers = manufacturers
                };

                return View("StorageAddForm", addStorageFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AddPsu(string name, int manufacturerId, string model, string link, int formFactorId, int power,
                                    string efficiency, string image, int shopId)
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var psuToAdd = new Psu()
                {
                    Name = name,
                    ManufacturerId = manufacturerId,
                    Model = model,
                    Link = link,
                    FormFactorId = formFactorId,
                    Power = power,
                    Efficiency = efficiency,
                    Image = image,
                    ShopId = shopId
                };

                context.Psu.Add(psuToAdd);
                context.SaveChanges();

                return RedirectToAction("PsuAddForm");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult PsuAddForm()
        {
            if (Request.IsAuthenticated && User.Identity.Name == "admin")
            {
                var manufacturers = context.Manufacturer.ToList();
                var formFactors = context.FormFactor.ToList();
                var shops = context.Shop.ToList();

                var addPsuFormViewModel = new AddPsuFormViewModel()
                {
                    Shops = shops,
                    Manufacturers = manufacturers,
                    FormFactors = formFactors
                };

                return View("PsuAddForm", addPsuFormViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

    }
}
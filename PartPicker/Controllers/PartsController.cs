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

    }
}
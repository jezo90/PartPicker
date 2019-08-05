using PartPicker.DAL;
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Controllers
{
    public class HomeController : Controller
    {
        private PickerContext db = new PickerContext();

        public ActionResult Index()
        {
            Shop sklep = new Shop { Class = "abc", ShopId = 1, Logo = "www.wp.pl", Name = "WP" };
            db.Shop.Add(sklep);
            db.SaveChanges();
            return View();
        }
    }
}
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
            var admin = db.User.ToList();

            return View();
        }

        public ActionResult Static(string name)
        {
            return View(name);
        }
    }
}
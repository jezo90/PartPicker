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
            var news = db.Build.Where(a => !a.Hidden).OrderByDescending(a => a.Date).Take(3).ToList();

            var builds = db.Build.ToList();
            int amountOfBuilds = db.Build.Count() + 1;
            int[] sum = new int[ amountOfBuilds ];
            double[] average = new double[ amountOfBuilds ];
            int[] count = new int[ amountOfBuilds ];

            for(int i=0; i<amountOfBuilds; i++)
            {
                sum[i] = 0;
                count[i] = 0;
            }

            foreach(Build b in builds)
            {
                foreach(Rate r in b.Rates)
                {
                    sum[r.BuildId] += r.Grade;
                    count[r.BuildId]++;
                }
            }

            for (int i = 0; i < amountOfBuilds; i++)
            {
                if(count[i]!=0) average[i] = sum[i] / count[i] * 1.0d;
            }

            double maxValue = average.Max();
            int maxIndex = average.ToList().IndexOf(maxValue);

            var hot = db.Build.Where(a => !a.Hidden && a.BuildId == maxIndex).ToList();

            return View();
        }

        public ActionResult Static(string name)
        {
            return View(name);
        }
    }
}
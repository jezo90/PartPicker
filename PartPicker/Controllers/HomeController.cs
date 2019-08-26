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
    public class HomeController : Controller
    {
        private PickerContext context = new PickerContext();

        public ActionResult Index()
        {
            var builds = context.Build.Where(a => !a.Hidden)
                        .ToList();

            var news = builds
                        .OrderByDescending(a => a.Date).Take(3)
                        .ToList();

            int amountOfBuilds = context.Build.Count() + 1;
            int[] sum = new int[amountOfBuilds];
            double[] average = new double[amountOfBuilds];
            int[] count = new int[amountOfBuilds];

            for (int i = 0; i < amountOfBuilds; i++)
            {
                sum[i] = 0;
                count[i] = 0;
            }

            foreach (Build b in builds)
            {
                foreach (Rate r in b.Rates)
                {
                    sum[r.BuildId] += r.Grade;
                    count[r.BuildId]++;
                }
            }

            for (int i = 0; i < amountOfBuilds; i++)
            {
                if (count[i] != 0) average[i] = sum[i] / count[i] * 1.0d;
            }

            double maxValue = average.Max();
            int maxIndex = average.ToList()
                            .IndexOf(maxValue);

            var hotBuild = builds
                            .Where(a => a.BuildId == maxIndex)
                            .ToList();

            var hotCpuId = builds
                        .GroupBy(a => a.CpuId)
                        .Select(a => new { CpuId = a.Key, count = a.Count() })
                        .OrderByDescending(o => o.count)
                        .Take(1)
                        .ToList();
            int hotCpuValue = hotCpuId[0].CpuId;
            var hotCpu = context.Cpu.Where(a => a.CpuId == hotCpuValue)
                        .ToList();

            var hotGpuId = builds
                        .GroupBy(a => a.GpuId)
                        .Select(a => new { GpuId = a.Key, count = a.Count() })
                        .OrderByDescending(o => o.count)
                        .Take(1)
                        .ToList();
            int hotGpuValue = hotGpuId[0].GpuId;
            var hotGpu = context.Gpu.Where(a => a.GpuId == hotGpuValue)
                        .ToList();

            var homeViewModel = new HomeViewModel()
            {
                New = news,
                HotBuild = hotBuild,
                HotCpu = hotCpu,
                HotGpu = hotGpu
            };
            
            return View(homeViewModel);
        }

        public ActionResult Static(string name)
        {
            return View(name);
        }
    }
}
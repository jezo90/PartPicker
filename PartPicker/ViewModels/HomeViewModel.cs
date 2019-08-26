using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Build> New { get; set; }

        public IEnumerable<Build> HotBuild { get; set; }

        public IEnumerable<Cpu> HotCpu { get; set; }

        public IEnumerable<Gpu> HotGpu { get; set; }
    }
}
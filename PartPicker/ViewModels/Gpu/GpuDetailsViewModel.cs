using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class GpuDetailsViewModel
    {
        public Gpu Gpu { get; set; }
        public List<Gpu> GpuList { get; set; }
        public List<string> Prices { get; set; }
        public int BenchmarkMax { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CpuDetailsViewModel
    {
        public Cpu Cpu { get; set; }
        public List<Cpu> CpuList { get; set; }
        public List<string> Prices { get; set; }
        public int BenchmarkMax { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
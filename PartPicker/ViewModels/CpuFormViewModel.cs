using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CpuFormViewModel
    {
        public List<string> Manufacturers { get; set; }
        public List<string> Sockets { get; set; }
        public List<string> Series { get; set; }
        public List<Cpu> Cpus { get; set; }

        public CpuFormCheckedViewModel CpuFormCheckedViewModel { get; set; }
    }
}
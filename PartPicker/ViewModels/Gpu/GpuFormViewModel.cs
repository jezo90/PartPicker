using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class GpuFormViewModel
    {
        public List<string> Manufacturers { get; set; }
        public List<string> Rams { get; set; }
        public List<string> Series { get; set; }
        public List<Gpu> Gpus { get; set; }

        public GpuFormCheckedViewModel GpuFormCheckedViewModel { get; set; }
    }
}
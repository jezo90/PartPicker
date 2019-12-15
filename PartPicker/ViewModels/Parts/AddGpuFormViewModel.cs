using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class AddGpuFormViewModel
    {
        public List<Product> Products { get; set; }
        public List<Shop> Shops { get; set; }
        public List<GpuRam> GpuRams { get; set; }
    }
}
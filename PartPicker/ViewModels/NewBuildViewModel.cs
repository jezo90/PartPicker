using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class NewBuildViewModel
    {
        public Cpu Cpu { get; set; }
        public Gpu Gpu { get; set; }
        public Ram Ram { get; set; }
        public Psu Psu { get; set; }
        public Mobo Mobo { get; set; }
        public Storage Storage { get; set; }
        public Case Case { get; set; }
    }
}
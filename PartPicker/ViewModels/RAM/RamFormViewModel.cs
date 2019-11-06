using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class RamFormViewModel
    {
        public List<Ram> Rams { get; set; }

        public List<string> Manufacturers { get; set; }
        public List<string> Types { get; set; }

        public RamFormCheckedViewModel RamFormCheckedViewModel { get; set; }
    }
}
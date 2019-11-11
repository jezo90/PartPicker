using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class PsuFormViewModel
    {
        public List<Psu> Psus { get; set; }

        public List<string> Manufacturers { get; set; }
        public List<string> FormFactor { get; set; }

        public PsuFormCheckedViewModel PsuFormCheckedViewModel { get; set; }
    }
}
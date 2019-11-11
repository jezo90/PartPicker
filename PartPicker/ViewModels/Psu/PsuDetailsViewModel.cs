using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class PsuDetailsViewModel
    {
        public Psu Psu { get; set; }
        public List<Psu> PsuList { get; set; }
        public List<string> Prices { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
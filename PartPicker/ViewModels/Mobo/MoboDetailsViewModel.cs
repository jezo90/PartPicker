using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class MoboDetailsViewModel
    {
        public Mobo Mobo { get; set; }
        public List<Mobo> MoboList { get; set; }
        public List<string> Prices { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
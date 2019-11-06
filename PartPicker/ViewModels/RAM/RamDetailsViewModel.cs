using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class RamDetailsViewModel
    {
        public Ram Ram { get; set; }
        public List<Ram> RamList { get; set; }
        public List<string> Prices { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
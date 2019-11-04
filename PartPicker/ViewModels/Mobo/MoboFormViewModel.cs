using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PartPicker.ViewModels
{
    public class MoboFormViewModel
    {
        public List<Mobo> Mobos { get; set; }
        public List<string> Manufacturers { get; set; }
        public List<string> Sockets{ get; set; }
        public List<string> FormFactor { get; set; }
        public List<string> RamType { get; set; }

        public MoboFormCheckedViewModel MoboFormCheckedViewModel { get; set; }
    }
}
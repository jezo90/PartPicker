using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class AddMoboFormViewModel
    {
        public List<Manufacturer> Manufacturers { get; set; }
        public List<FormFactor> FormFactors { get; set; }
        public List<RamType> RamTypes { get; set; }
        public List<Socket> Sockets { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
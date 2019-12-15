using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class AddPsuFormViewModel
    {
        public List<FormFactor> FormFactors { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
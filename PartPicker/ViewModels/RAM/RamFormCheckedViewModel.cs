using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class RamFormCheckedViewModel
    {
        public List<string> ManufacturersChecked { get; set; }
        public List<string> TypeChecked { get; set; }
        public int AmountMinChecked { get; set; }
        public int AmountMaxChecked { get; set; }
    }
}
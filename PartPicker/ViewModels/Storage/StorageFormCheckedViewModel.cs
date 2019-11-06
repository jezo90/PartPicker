using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class StorageFormCheckedViewModel
    {
        public List<string> ManufacturersChecked { get; set; }
        public List<string> InterfaceChecked { get; set; }
        public List<string> TypeChecked { get; set; }
        public int CapacityMinChecked { get; set; }
        public int CapacityMaxChecked { get; set; }
    }
}
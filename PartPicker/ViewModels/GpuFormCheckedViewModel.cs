using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class GpuFormCheckedViewModel
    {
        public List<string> ManufacturersChecked { get; set; }
        public List<string> RamsChecked { get; set; }
        public List<string> SeriesChecked { get; set; }
        public int RamMinChecked { get; set; }
        public int RamMaxChecked { get; set; }
        public int LengthMaxChecked { get; set; }
    }
}
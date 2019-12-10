using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildFormCheckedViewModel
    {
        public List<string> CpuManufacturersChecked { get; set; }
        public List<string> CpuSeriesChecked { get; set; }
        public List<string> GpuSeriesChecked { get; set; }
        public List<string> RamTypeChecked { get; set; }
        public List<string> StorageTypeChecked { get; set; }
    }
}
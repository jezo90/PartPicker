using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildSearchViewModel
    {
        public List<string> CpuManufacturers { get; set; }
        public List<string> CpuSeries { get; set; }
        public List<string> GpuManufacturers { get; set; }
        public List<string> RamType { get; set; }
        public List<string> StorageType { get; set; }


    }
}
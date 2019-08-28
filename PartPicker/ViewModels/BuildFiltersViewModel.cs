using PartPicker.Infrastructure;
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildFiltersViewModel
    {
        public IEnumerable<string> CpuSockets { get; set; }
        public IEnumerable<string> CpuManufacturers { get; set; }
        public IEnumerable<string> GpuManufacturers { get; set; }
        public IEnumerable<string> StorageTypes { get; set; }
        public IEnumerable<string> RamTypes { get; set; }
    }
}
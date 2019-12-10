using PartPicker.Infrastructure;
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildFormViewModel
    {
        public List<Cpu> Cpus { get; set; }
        public List<Gpu> Gpus { get; set; }
        public List<string> CpuManufacturers { get; set; }
        public List<string> CpuSeries { get; set; }
        public List<string> GpuSeries { get; set; }
        public List<string> StorageTypes { get; set; }
        public List<string> RamTypes { get; set; }

        public BuildFormCheckedViewModel BuildFormCheckedViewModel { get; set; }
    }
}
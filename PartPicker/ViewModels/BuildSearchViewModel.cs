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

        public BuildSearchViewModel()
        {
            CpuManufacturers = new List<string>();
            CpuSeries = new List<string>();
            GpuManufacturers = new List<string>();
            RamType = new List<string>();
            StorageType = new List<string>();
        }

        public BuildSearchViewModel(List<string> cpuM, List<string> cpuS, List<string> gpu,
                                    List<string> ram, List<string> storage)
        {
            if (cpuM.Count() > 0)
                CpuManufacturers = cpuM;
            else
                CpuManufacturers = new List<string>();

            if (cpuS.Count() > 0)
                CpuSeries = cpuS;
            else
                CpuSeries = new List<string>();

            if (gpu.Count() > 0)
                GpuManufacturers = gpu;
            else
                GpuManufacturers = new List<string>();

            if (ram.Count() > 0)
                RamType = ram;
            else
                RamType = new List<string>();

            if (storage.Count() > 0)
                StorageType = storage;
            else
                StorageType = new List<string>();
        }
    }
}
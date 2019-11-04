using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class GpuListViewModel
    {
        public int BenchmarkMax { get; set; }

        public PagedList.IPagedList<Gpu> PagedList { get; set; }
        public GpuFormCheckedViewModel GpuFormCheckedViewModel { get; set; }
    }
}
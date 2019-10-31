using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CpuListViewModel
    {
        public int BenchmarkMax { get; set; }

        public PagedList.IPagedList<Cpu> PagedList {get; set;}
        public CpuFormCheckedViewModel CpuFormCheckedViewModel { get; set; }
    }
}
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildListViewModel
    {
        public PagedList.IPagedList<Build> PagedList { get; set; }
        public BuildFormCheckedViewModel BuildFormCheckedViewModel { get; set; }
        public double[] Average { get; set; }
        public double[] Count { get; set; }
    }
}
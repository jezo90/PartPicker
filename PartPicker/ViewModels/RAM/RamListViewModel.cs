using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class RamListViewModel
    {
        public PagedList.IPagedList<Ram> PagedList { get; set; }
        public RamFormCheckedViewModel RamFormCheckedViewModel { get; set; }
    }
}
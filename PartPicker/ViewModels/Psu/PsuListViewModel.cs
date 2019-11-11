using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class PsuListViewModel
    {
        public PagedList.IPagedList<Psu> PagedList { get; set; }
        public PsuFormCheckedViewModel PsuFormCheckedViewModel { get; set; }
    }
}
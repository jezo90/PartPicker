using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class MoboListViewModel
    {
        public PagedList.IPagedList<Mobo> PagedList { get; set; }
        public MoboFormCheckedViewModel MoboFormCheckedViewModel { get; set; }
    }
}
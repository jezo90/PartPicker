using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class StorageListViewModel
    {
        public PagedList.IPagedList<Storage> PagedList { get; set; }
        public StorageFormCheckedViewModel StorageFormCheckedViewModel { get; set; }
    }
}
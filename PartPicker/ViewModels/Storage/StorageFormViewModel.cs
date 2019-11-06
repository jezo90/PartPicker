using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class StorageFormViewModel
    {
        public List<Storage> Storages { get; set; }

        public List<string> Manufacturers { get; set; }
        public List<string> Interfaces { get; set; }
        public List<string> Types { get; set; }

        public StorageFormCheckedViewModel StorageFormCheckedViewModel { get; set; }
    }
}
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class StorageDetailsViewModel
    {
        public Storage Storage { get; set; }
        public List<Storage> StorageList { get; set; }
        public List<string> Prices { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CaseFormCheckedViewModel
    {
        public List<string> ManufacturersChecked { get; set; }
        public List<string> FormFactorChecked { get; set; }
        public int LengthMinChecked { get; set; }
    }
}
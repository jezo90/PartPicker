using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class MoboFormCheckedViewModel
    {
        public List<string> ManufacturersChecked { get; set; }
        public List<string> SocketsChecked { get; set; }
        public List<string> FormFactorChecked { get; set; }
        public List<string> RamTypeChecked { get; set; }

    }
}
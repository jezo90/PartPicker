using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CpuFormCheckedViewModel
    {
        public List<string> ManufacturersChecked { get; set; }
        public List<string> SocketsChecked { get; set; }
        public List<string> SeriesChecked { get; set; }
        public int CoresMinChecked { get; set; }
        public int CoresMaxChecked { get; set; }
        public string GpuChecked { get; set; }
    }
}
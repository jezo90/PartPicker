using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildsListViewModel
    {
        public IEnumerable<Build> Builds { get; set; }
        public double[] Average { get; set; }
    }
}
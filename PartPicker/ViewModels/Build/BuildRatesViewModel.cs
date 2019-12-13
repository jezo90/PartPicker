using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class BuildRatesViewModel
    {
        public int BuildId { get; set; }
        public string BuildName { get; set; }
        public Rate Rate { get; set; }
    }
}
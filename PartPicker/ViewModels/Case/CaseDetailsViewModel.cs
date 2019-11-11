using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CaseDetailsViewModel
    {
        public Case Case { get; set; }
        public List<Case> CaseList { get; set; }
        public List<string> Prices { get; set; }
        public NewBuildViewModel NewBuildViewModel { get; set; }
    }
}
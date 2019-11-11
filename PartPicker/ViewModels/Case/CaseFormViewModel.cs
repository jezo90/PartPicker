using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CaseFormViewModel
    {
        public List<string> Manufacturers { get; set; }
        public List<string> FormFactor { get; set; }
        public List<Case> Cases { get; set; }

        public CaseFormCheckedViewModel CaseFormCheckedViewModel { get; set; }
    }
}
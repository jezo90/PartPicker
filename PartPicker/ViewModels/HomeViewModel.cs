using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<string> Parts { get; set; }

        public IEnumerable<Build> New { get; set; }

        public IEnumerable<Build> Hot { get; set; }
    }
}
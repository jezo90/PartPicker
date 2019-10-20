using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class NewBuild
    {
        public string Name { get; set; }

        public Cpu Cpu { get; set; }

        public Mobo Mobo { get; set; }

        public Gpu Gpu { get; set; }

        public Ram Ram { get; set; }

        public Storage Storage { get; set; }

        public Psu Psu { get; set; }

        public Case Case { get; set; }
    }
}
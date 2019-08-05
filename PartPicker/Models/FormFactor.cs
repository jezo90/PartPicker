using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class FormFactor
    {
        public int FormFactorId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name  { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }
    }
}
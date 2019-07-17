using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Shop
    {
        public int Id_shop { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(45)]
        public string Logo { get; set; }

        [Required]
        [StringLength(45)]
        public string Clas { get; set; }
    }
}
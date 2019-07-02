using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Shop
    {
        public int id_shop { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Required]
        [StringLength(45)]
        public string logo { get; set; }

        [Required]
        [StringLength(45)]
        public string clas { get; set; }
    }
}
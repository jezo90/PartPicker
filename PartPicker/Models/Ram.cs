using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Ram
    {
        public int Id_ram { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [StringLength(10)]
        public RamType RamType { get; set; }

        [Required]
        [Range(1, 9)]
        public int Amount { get; set; }

        [Required]
        [Range(1, 99)]
        public int Size { get; set; }

        [Required]
        [Range(1, 9999)]
        public string Frequency { get; set; }

        [Required]
        [Range(1, 99)]
        public int Cl { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int Shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
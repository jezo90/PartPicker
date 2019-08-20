using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Ram
    {
        public int RamId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(45)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(45)]
        public string Model { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        public int RamTypeId { get; set; }

        [Required]
        [Range(1, 9)]
        public int Amount { get; set; }

        [Required]
        [Range(1, 99)]
        public int Size { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Frequency { get; set; }

        [Required]
        [Range(1, 99)]
        public int Cl { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual RamType RamType { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
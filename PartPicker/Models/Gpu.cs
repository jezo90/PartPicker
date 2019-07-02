using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Gpu
    {
        public int id_gpu { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string link { get; set; }

        [Required]
        [Range(1,32)]
        public int ram { get; set; }

        [Required]
        public RamType ram_type { get; set; }

        [Required]
        [StringLength(5)]
        public string frequency { get; set; }

        [Required]
        [StringLength(5)]
        public string frequency_boost { get; set; }

        [Required]
        [Range(1,200)]
        public int length { get; set; }

        [Required]
        [Range(1,10000)]
        public int benchmark { get; set; }

        [Required]
        [StringLength(45)]
        public string image { get; set; }

        [Required]
        public int shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
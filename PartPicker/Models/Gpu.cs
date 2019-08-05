using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Gpu
    {
        public int GpuId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [Range(1,99)]
        public int Ram { get; set; }

        [Required]
        public int RamTypeId { get; set; }

        [Required]
        [StringLength(5)]
        public string Frequency { get; set; }

        [Required]
        [StringLength(5)]
        public string FrequencyBoost { get; set; }

        [Required]
        [Range(1,999)]
        public int Length { get; set; }

        [Required]
        [Range(1,99999)]
        public int Benchmark { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual RamType RamType { get; set; }
    }
}
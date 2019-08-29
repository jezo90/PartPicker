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
        public int ProductId { get; set; }

        [Required]
        [StringLength(45)]
        public string Model { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [Range(1,99)]
        public int Ram { get; set; }

        [Required]
        public int GpuRamId { get; set; }

        [Required]
        [Range(1, 5)]
        public double Frequency { get; set; }

        [Required]
        [Range(1, 5)]
        public double FrequencyBoost { get; set; }

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
        public virtual GpuRam GpuRam { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<Build> Builds { get; set; }

    }
}
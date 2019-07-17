﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Gpu
    {
        public int Id_gpu { get; set; }

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
        public RamType Ram_type { get; set; }

        [Required]
        [StringLength(5)]
        public string Frequency { get; set; }

        [Required]
        [StringLength(5)]
        public string Frequency_boost { get; set; }

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
        public int Shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class GpuRam
    {
        public int GpuRamId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public virtual ICollection<Gpu> Gpus { get; set; }
    }
}
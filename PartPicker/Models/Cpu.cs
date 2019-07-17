using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Cpu
    {
        public int Id_cpu { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [StringLength(10)]
        public Socket Socket { get; set; }

        [Required]
        [Range(1,99)]
        public int Cores { get; set; }

        [Required]
        [StringLength(10)]
        public string Frequency { get; set; }

        [Required]
        [StringLength(10)]
        public string Turbo { get; set; }

        [Required]
        [StringLength(45)]
        public string Gpu { get; set; }

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
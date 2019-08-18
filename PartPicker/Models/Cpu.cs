using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Cpu
    {
        public int CpuId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        public int SocketId { get; set; }

        [Required]
        [Range(1,99)]
        public int Cores { get; set; }

        [Required]
        public double Frequency { get; set; }

        [Required]
        public double Turbo { get; set; }

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
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Socket Socket { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
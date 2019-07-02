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
        public int id_cpu { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string link { get; set; }

        [Required]
        [StringLength(10)]
        public Socket socket { get; set; }

        [Required]
        [Range(1,32)]
        public int cores { get; set; }

        [Required]
        [StringLength(10)]
        public string frequency { get; set; }

        [Required]
        [StringLength(10)]
        public string turbo { get; set; }

        [Required]
        [StringLength(45)]
        public string gpu { get; set; }

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
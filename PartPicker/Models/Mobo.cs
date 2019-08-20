using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Mobo
    {
        public int MoboId { get; set; }

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
        public int FormFactorId { get; set; }

        [Required]
        public int SocketId { get; set; }

        [Required]
        [Range(1, 9)]
        public int RamSlots { get; set; }

        [Required]
        public int RamTypeId { get; set; }

        [Required]
        [Range(1, 999)]
        public int MaxRam { get; set; }

        [Required]
        [Range(1, 9)]
        public int SataSlots { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual FormFactor FormFactor { get; set; }
        public virtual RamType RamType { get; set; }
        public virtual Socket Socket { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }

    
}
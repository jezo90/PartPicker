using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Storage
    {
        public int StorageId { get; set; }

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
        [StringLength(3)]
        public string Type { get; set; }

        [Required]
        [Range(1,99999)]
        public int Capacity { get; set; }

        [Required]
        public int InterfaceId { get; set; }

        [Required]
        [Range(1, 5)]
        public double Size { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Interface Interface { get; set; }

        public virtual ICollection<Build> Builds { get; set; }

    }
}
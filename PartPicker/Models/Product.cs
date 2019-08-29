using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        
        [Required]
        public int SeriesId { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Series Series { get; set; }

        public virtual ICollection<Cpu> Cpus { get; set; }
        public virtual ICollection<Gpu> Gpus { get; set; }
    }
}
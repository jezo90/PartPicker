using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Shop
    {
        public int ShopId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Logo { get; set; }

        [Required]
        [StringLength(45)]
        public string Class { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Cpu> Cpus { get; set; }
        public virtual ICollection<Gpu> Gpus { get; set; }
        public virtual ICollection<Mobo> Mobos { get; set; }
        public virtual ICollection<Psu> Psus { get; set; }
        public virtual ICollection<Ram> Rams { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
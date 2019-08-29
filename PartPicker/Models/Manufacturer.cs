using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartPicker.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Mobo> Mobos { get; set; }
        public virtual ICollection<Psu> Psus { get; set; }
        public virtual ICollection<Ram> Rams { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
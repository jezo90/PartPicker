using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartPicker.Models
{
    public class Series
    {
        public int SeriesId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
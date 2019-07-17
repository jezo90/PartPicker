using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Mobo
    {
        public int Id_mobo { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [Range(1, 99)]
        public FormFactor Form_factor { get; set; }

        [Required]
        [StringLength(10)]
        public Socket Socket { get; set; }

        [Required]
        [Range(1, 9)]
        public string Ram_slots { get; set; }

        [Required]
        [StringLength(4)]
        public RamType Ram_type { get; set; }

        [Required]
        [Range(1, 999)]
        public string Max_ram { get; set; }

        [Required]
        [Range(1, 9)]
        public string Sata_slots { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int Shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }

    
}
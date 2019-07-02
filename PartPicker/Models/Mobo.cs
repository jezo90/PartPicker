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
        public int id_mobo { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string link { get; set; }

        [Required]
        [Range(1, 32)]
        public FormFactor form_factor { get; set; }

        [Required]
        [StringLength(10)]
        public Socket socket { get; set; }

        [Required]
        [Range(1, 8)]
        public string ram_slots { get; set; }

        [Required]
        [StringLength(4)]
        public RamType ram_type { get; set; }

        [Required]
        [Range(1, 256)]
        public string max_ram { get; set; }

        [Required]
        [Range(1, 8)]
        public string sata_slots { get; set; }

        [Required]
        [StringLength(45)]
        public string image { get; set; }

        [Required]
        public int shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }

    
}
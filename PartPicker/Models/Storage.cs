using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Storage
    {
        public int id_storage { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string link { get; set; }

        [Required]
        [StringLength(3)]
        public string type { get; set; }

        [Required]
        [Range(100,10000)]
        public int capacity { get; set; }

        [Required]
        [StringLength(45)]
        public Interface interfac { get; set; }

        [Required]
        [StringLength(3)]
        public string size { get; set; }

        [Required]
        [StringLength(45)]
        public string image { get; set; }

        [Required]
        public int shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
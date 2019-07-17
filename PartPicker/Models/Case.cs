using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Case
    {
        public int Id_psu { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        public FormFactor FormFactor { get; set; }

        [Required]
        [StringLength(45)]
        public int MoboType { get; set; }

        [Required]
        [Range(1,999)]
        public string GpuLenght { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int Shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Case
    {
        public int CaseId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        public int FormFactorId { get; set; }

        [Required]
        [StringLength(45)]
        public string MoboType { get; set; }

        [Required]
        [Range(1,999)]
        public int GpuLenght { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual FormFactor FormFactor { get; set; }

        public virtual ICollection<Build> Builds { get; set; }

    }
}
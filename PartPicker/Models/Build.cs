using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Build
    {
        public int BuildId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CpuId { get; set; }

        [Required]
        public int MoboId { get; set; }

        [Required]
        public int GpuId { get; set; }

        [Required]
        public int RamId { get; set; }

        [Required]
        public int StorageId { get; set; }

        [Required]
        public int PsuId { get; set; }

        [Required]
        public int CaseId { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public bool Hidden { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }


        public virtual User User { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual Mobo Mobo { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Psu Psu { get; set; }
        public virtual Gpu Gpu { get; set; }
        public virtual Ram Ram { get; set; }
        public virtual Case Case { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}
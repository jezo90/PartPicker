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
        public int StorageId { get; set; }

        [Required]
        public int PsuId { get; set; }

        [Required]
        public int CaseId { get; set; }

        [Required]
        [Range(1,99999)]
        public int Price { get; set; }


        public virtual User User { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual Mobo Mobo { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Psu Psu { get; set; }
        public virtual Case Case { get; set; }
    }
}
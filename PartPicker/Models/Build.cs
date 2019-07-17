using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Build
    {
        public int Id_build { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        public int Id_user { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Id_cpu { get; set; }

        [Required]
        public int Id_mobo { get; set; }

        [Required]
        public int Id_storage { get; set; }

        [Required]
        public int Id_psu { get; set; }

        [Required]
        public int Id_case { get; set; }

        [Required]
        public int Price { get; set; }


        public virtual User User { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual Mobo Mobo { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Psu Psu { get; set; }
        public virtual Case Case { get; set; }
    }
}
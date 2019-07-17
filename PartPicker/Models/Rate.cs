using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Rate
    {
        public int Id_rate { get; set; }

        [Required]
        public int Id_user { get; set; }

        [Required]
        public int Id_build { get; set; }

        [Required]
        [Range(1,9)]
        public int Grade { get; set; }

        public virtual User User { get; set; }

        public virtual Build Build { get; set; }

    }
}
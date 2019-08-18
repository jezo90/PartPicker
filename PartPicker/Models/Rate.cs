using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Rate
    {
        public int RateId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BuildId { get; set; }

        [Required]
        [Range(1,9)]
        public int Grade { get; set; }

        public virtual User User { get; set; }
        public virtual Build Build { get; set; }

    }
}
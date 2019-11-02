using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.IdentityModels;

namespace PartPicker.Models
{
    public class Rate
    {
        public int RateId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public int BuildId { get; set; }

        [Required]
        [Range(1,5)]
        public int Grade { get; set; }

        [Required]
        public DateTime Added { get; set; }

        [Required]
        [StringLength(150)]
        public string Comment { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Build Build { get; set; }

    }
}
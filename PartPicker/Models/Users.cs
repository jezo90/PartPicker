using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartPicker.Models
{
    public class Users
    {
        public int id_user { get; set; }

        [Required]
        [StringLength(45)]
        public string login { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string nickname { get; set; }

        [Required]
        public bool permission { get; set; }
    }
}
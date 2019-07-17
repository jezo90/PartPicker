﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PartPicker.Models.Enum;

namespace PartPicker.Models
{
    public class Storage
    {
        public int Id_storage { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Link { get; set; }

        [Required]
        [StringLength(3)]
        public string Type { get; set; }

        [Required]
        [Range(1,99999)]
        public int Capacity { get; set; }

        [Required]
        [StringLength(45)]
        public Interface Interfac { get; set; }

        [Required]
        [StringLength(3)]
        public string Size { get; set; }

        [Required]
        [StringLength(45)]
        public string Image { get; set; }

        [Required]
        public int Shop_id { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
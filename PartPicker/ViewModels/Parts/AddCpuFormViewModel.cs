using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class AddCpuFormViewModel
    {
        public List<Product> Products { get; set; }
        public List<Socket> Sockets { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
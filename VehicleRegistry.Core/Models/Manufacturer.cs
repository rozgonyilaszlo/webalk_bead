using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRegistry.Core.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Founded { get; set; }
    }
}

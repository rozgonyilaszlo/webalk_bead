using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRegistry.Core.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(0, 100)]
        public double Consumption { get; set; }
        
        [Required]
        public string Color { get; set; }
        
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public int Available { get; set; }

        [Required]
        [Range(0,  9999)]
        public int Year { get; set; }

        [Required]
        [Range(0,  9999)]
        public int Horsepower { get; set; }
    }
}

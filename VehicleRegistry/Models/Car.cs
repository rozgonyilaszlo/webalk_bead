using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRegistry.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Consumption { get; set; }

        public string Color { get; set; }

        public string Manufacturer { get; set; }

        public int Available { get; set; }

        public int Year { get; set; }

        public int Horsepower { get; set; }
    }
}

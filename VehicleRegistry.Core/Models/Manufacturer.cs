﻿using System;
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
        
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime Founded { get; set; }
    }
}

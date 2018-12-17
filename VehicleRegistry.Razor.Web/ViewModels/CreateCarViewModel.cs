using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Razor.Web.ViewModels
{
    public class CreateCarViewModel
    {
        public Car Car { get; set; }

        public List<string> ManufacturerName { get; set; }
    }
}

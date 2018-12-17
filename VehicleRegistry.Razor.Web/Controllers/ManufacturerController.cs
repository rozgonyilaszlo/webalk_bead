using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Razor.Web.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly DatabaseContext _context;

        public ManufacturerController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Manufacturer());
        }

        [HttpPost]
        public IActionResult Index(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();
            }

            return View(manufacturer);
        }

        [HttpGet]
        public IActionResult _Manufacturers()
        {
            return View(_context.Manufacturers.ToList());
        }
    }
}
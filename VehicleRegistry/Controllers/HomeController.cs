using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Database;
using VehicleRegistry.Models;

namespace VehicleRegistry.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Manufacturers.Add(new Manufacturer() { Id = 0, Name = "Volkswagen", Country = "Germany", Founded = new System.DateTime(1937, 05, 28) });
            _context.SaveChanges();

            return View();
        }

        public IActionResult Cars()
        {
            return View();
        }

        public IActionResult Manufacturers()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

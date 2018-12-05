using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Web.Controllers
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
            return View();
        }

        public IActionResult Car()
        {
            return View();
        }

        public IActionResult Manufacturer()
        {
            return View();
        }

        public JsonResult manufacturers()
        {
            return Json(_context.Manufacturers.ToList());
        }

        public JsonResult manufacturerNames()
        {
            return Json(_context.Manufacturers.Select(s => s.Name).ToList());
        }

        public JsonResult cars()
        {
            return Json(_context.Cars.ToList());
        }

        public JsonResult manufacturercookie()
        {
            string cookieValue;

            HttpContext.Request.Cookies.TryGetValue("name", out cookieValue);

            List<Car> cars = _context.Cars.Where(w => w.Manufacturer == cookieValue).ToList();

            return Json(cars);
        }

        [HttpPost]
        public void addCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        [HttpPost]
        public void addManufacturers(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

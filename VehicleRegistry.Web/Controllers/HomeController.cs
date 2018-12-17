using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Handlers;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Web.Controllers
{
    public class HomeController : Controller
    {
        private CarHandler carHandler;
        private ManufacturerHandler manufacturerHandler;

        public HomeController(DatabaseContext context)
        {
            carHandler = new CarHandler(context);
            manufacturerHandler = new ManufacturerHandler(context);
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
            return Json(manufacturerHandler.GetAll());
        }

        public JsonResult manufacturerNames()
        {
            return Json(manufacturerHandler.GetNames());
        }

        public JsonResult cars()
        {
            return Json(carHandler.GetAll());
        }

        public JsonResult manufacturercookie()
        {
            string cookieValue;

            HttpContext.Request.Cookies.TryGetValue("name", out cookieValue);

            List<Car> cars = carHandler.GetAll(cookieValue);

            return Json(cars);
        }

        [HttpPost]
        public void addCar(Car car)
        {
            carHandler.Create(car);
        }

        [HttpPost]
        public void addManufacturers(Manufacturer manufacturer)
        {
            manufacturerHandler.Create(manufacturer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

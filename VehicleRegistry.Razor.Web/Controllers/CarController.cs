using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Handlers;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Razor.Web.Controllers
{
    public class CarController : Controller
    {
        private CarHandler carHandler;

        public CarController(DatabaseContext context)
        {
            carHandler = new CarHandler(context);
        }

        public IActionResult Index()
        {
            return View(carHandler.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }

        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                carHandler.Create(car);
                return PartialView(new Car());
            }
            else
            {
                return PartialView(car);
            }
        }

        public IActionResult List()
        {
            return PartialView(carHandler.GetAll());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            carHandler.Dispose();
        }
    }
}
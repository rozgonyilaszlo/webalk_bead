using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Handlers;
using VehicleRegistry.Core.Models;
using VehicleRegistry.Razor.Web.ViewModels;

namespace VehicleRegistry.Razor.Web.Controllers
{
    public class CarController : Controller
    {
        private CarHandler carHandler;
        private ManufacturerHandler manufacturerHandler;

        public CarController(DatabaseContext context)
        {
            carHandler = new CarHandler(context);
            manufacturerHandler = new ManufacturerHandler(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView(new CreateCarViewModel() {
                Car = new Car(),
                ManufacturerName = manufacturerHandler.GetNames()
            });
        }

        [HttpPost]
        public IActionResult Create(CreateCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                carHandler.Create(model.Car);
                return PartialView(new CreateCarViewModel() {
                    Car = new Car(),
                    ManufacturerName = manufacturerHandler.GetNames()
                });
            }
            else
            {
                model.ManufacturerName = manufacturerHandler.GetNames();
                return PartialView(model);
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            return PartialView(carHandler.GetAll());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            carHandler.Dispose();
            manufacturerHandler.Dispose();
        }
    }
}
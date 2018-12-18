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
    public class ManufacturerController : Controller
    {
        private ManufacturerHandler manufacturerHandler;
        private CarHandler carHandler;

        public ManufacturerController(DatabaseContext context)
        {
            manufacturerHandler = new ManufacturerHandler(context);
            carHandler = new CarHandler(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new Manufacturer());
        }

        [HttpPost]
        public IActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerHandler.Create(manufacturer);
                return PartialView(new Manufacturer());
            }
            else
            {
                return PartialView(manufacturer);
            }
        }

        [HttpGet]
        public JsonResult Cars()
        {
            string cookieValue;

            HttpContext.Request.Cookies.TryGetValue("name", out cookieValue);

            return Json(carHandler.GetAll(cookieValue));
        }

        [HttpGet]
        public IActionResult List()
        {
            return PartialView(manufacturerHandler.GetAll());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            manufacturerHandler.Dispose();
            carHandler.Dispose();
        }
    }
}
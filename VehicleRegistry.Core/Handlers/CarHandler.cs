using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Core.Handlers
{
    public class CarHandler : IDisposable
    {
        private readonly DatabaseContext _context;

        public CarHandler(DatabaseContext context)
        {
            _context = context;
        }
        
        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public List<Car> GetAll(string name)
        {
            return _context.Cars.Where(w => w.Manufacturer == name).ToList();
        }

        public void Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

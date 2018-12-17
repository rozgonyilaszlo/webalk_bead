using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleRegistry.Core.Database;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Core.Handlers
{
    public class ManufacturerHandler : IDisposable
    {
        private readonly DatabaseContext _context;

        public ManufacturerHandler(DatabaseContext context)
        {
            _context = context;
        }

        public List<Manufacturer> GetAll()
        {
            return _context.Manufacturers.ToList();
        }

        public void Create(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
        }

        public object GetNames()
        {
            return _context.Manufacturers.Select(s => s.Name).ToList();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
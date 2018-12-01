using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRegistry.Models;

namespace VehicleRegistry.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}

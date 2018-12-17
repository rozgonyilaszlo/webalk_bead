using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Core.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext() : base() { }

        public static void UploadData(DatabaseContext context)
        {
            if (context != null)
            {
                if (!context.Cars.Any() || !context.Manufacturers.Any())
                {
                    context.Manufacturers.Add(new Manufacturer() { Name = "Opel", Country = "Germany", Founded = new DateTime(1862, 01, 21) });
                    context.Manufacturers.Add(new Manufacturer() { Name = "Volkswagen", Country = "Germany", Founded = new DateTime(1937, 05, 28) });
                    context.Manufacturers.Add(new Manufacturer() { Name = "Toyota", Country = "Japan", Founded = new DateTime(1937, 08, 28) });
                    context.Manufacturers.Add(new Manufacturer() { Name = "Skoda", Country = "Czech", Founded = new DateTime(1895, 12, 18) });
                    context.Manufacturers.Add(new Manufacturer() { Name = "Ford", Country = "USA", Founded = new DateTime(1903, 07, 16) });
                    context.Manufacturers.Add(new Manufacturer() { Name = "Tesla", Country = "USA", Founded = new DateTime(2003, 06, 01) });

                    context.Cars.Add(new Car() { Name = "Corolla", Available = 1, Color = "Gray", Consumption = 7, Horsepower = 100, Manufacturer = "Toyota", Year = 2003 });
                    context.Cars.Add(new Car() { Name = "Astra", Available = 3, Color = "Gold", Consumption = 9, Horsepower = 86, Manufacturer = "Opel", Year = 1996 });
                    context.Cars.Add(new Car() { Name = "Focus", Available = 7, Color = "Blue", Consumption = 7.5, Horsepower = 120, Manufacturer = "Ford", Year = 2013 });
                    context.Cars.Add(new Car() { Name = "Superb", Available = 1, Color = "White", Consumption = 5.6, Horsepower = 160, Manufacturer = "Skoda", Year = 2016 });
                    context.Cars.Add(new Car() { Name = "Octavia", Available = 5, Color = "White", Consumption = 4.9, Horsepower = 140, Manufacturer = "Skoda", Year = 2014 });
                    context.Cars.Add(new Car() { Name = "Golf 4", Available = 1, Color = "Black", Consumption = 8.9, Horsepower = 101, Manufacturer = "Volkswagen", Year = 1998 });
                    context.Cars.Add(new Car() { Name = "Passat", Available = 1, Color = "Dark gray", Consumption = 7.2, Horsepower = 131, Manufacturer = "Volkswagen", Year = 2001 });

                    context.SaveChanges();
                }
            }
        }
    }
}

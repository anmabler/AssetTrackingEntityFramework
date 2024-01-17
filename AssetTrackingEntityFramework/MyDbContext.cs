using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEntityFramework
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = EFAssetTracking; Integrated Security = True";

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add Offices first to db
            modelBuilder.Entity<Office>().HasData(new Office { Id = 1, Country = "Sweden", Currency = "SEK", CurrencyRate = 10.46f }); 
            modelBuilder.Entity<Office>().HasData(new Office { Id = 2, Country = "USA", Currency = "USD", CurrencyRate = 1.0f });
            modelBuilder.Entity<Office>().HasData(new Office { Id = 3, Country = "Iceland", Currency = "ISK", CurrencyRate = 137.4f });

            modelBuilder.Entity<Computer>().HasData(
                new Computer
                {
                    Id = 1,
                    Brand = "Apple",
                    Model = "MacBook",
                    PurchaseDate = new DateTime(2020, 12, 26),
                    Price = 1500,
                    EndOfLife = new DateTime(2023, 12, 26),
                    OfficeId = 1
                }

                );
            modelBuilder.Entity<Computer>().HasData(new Computer
            {
                Id = 2,
                Brand = "Asus",
                Model = "ROG 550",
                PurchaseDate = new DateTime(2022, 05, 15),
                Price = 900,
                EndOfLife = new DateTime(2025, 05, 15),
                OfficeId = 2
            });
            modelBuilder.Entity<Computer>().HasData(
                new Computer
                {
                    Id = 3,
                    Brand = "Lenovo",
                    Model = "D300",
                    PurchaseDate = new DateTime(2021, 03, 10),
                    Price = 750,
                    EndOfLife = new DateTime(2024, 03, 10),
                    OfficeId = 3
                });

            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    Brand = "Apple",
                    Model = "IPhone 14",
                    PurchaseDate = new DateTime(2023, 10, 14),
                    Price = 1400,
                    EndOfLife = new DateTime(2026, 10, 14),
                    OfficeId = 2
                });
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 2,
                    Brand = "Samsung",
                    Model = "Galaxy S20+",
                    PurchaseDate = new DateTime(2019, 08, 01),
                    Price = 1000,
                    EndOfLife = new DateTime(2022, 08, 01),
                    OfficeId = 3
                });
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 3,
                    Brand = "Nokia",
                    Model = "3310",
                    PurchaseDate = new DateTime(2021, 10, 14),
                    Price = 100,
                    EndOfLife = new DateTime(2024, 10, 14),
                    OfficeId = 1
                });
        }
    }
}

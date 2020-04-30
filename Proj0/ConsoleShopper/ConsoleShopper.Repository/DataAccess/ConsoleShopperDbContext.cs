﻿using ConsoleShopper.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShopper.Repository.DataAccess
{
    public class ConsoleShopperDbContext : DbContext
    {
        public ConsoleShopperDbContext(DbContextOptions<ConsoleShopperDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreLocation> StoreLocations { get; set; }
        public DbSet<Admin> Admins { get; set; }

        #region Seeding User Types
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        #endregion

        /// <summary>
        /// Only needed for the migration to work, as the app takes its database connection from appsettings.json
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Alternate connection string for windows authenticated connection 
            // Server=.;Database=consoleShopperDb;Trusted_Connection=True;MultipleActiveResultSets=true
            // DefaultConnection string for passworded sa connection
            // Server=.;Database=ConsoleShopperDb;User Id=sa;Password=abc123;MultipleActiveResultSets=true
            optionsBuilder.UseSqlServer("Server=.;Database=ConsoleShopperDb;User Id=sa;Password=abc123;MultipleActiveResultSets=true", b => b.MigrationsAssembly("ConsoleShopper.Repository"));
        }
    }

    /// <summary>
    /// Only needed for the migration to work, as the app takes its database connection from appsettings.json
    /// </summary>
    public class ConsoleShopperDbContextFactory : IDesignTimeDbContextFactory<ConsoleShopperDbContext>
    {
        public ConsoleShopperDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsoleShopperDbContext>();

            // Alternate connection string for windows authenticated connection 
            // Server=.;Database=consoleShopperDb;Trusted_Connection=True;MultipleActiveResultSets=true
            // DefaultConnection string for passworded sa connection
            // Server=.;Database=ConsoleShopperDb;User Id=sa;Password=abc123;MultipleActiveResultSets=true
            optionsBuilder.UseSqlServer("Server=.;Database=ConsoleShopperDb;User Id=sa;Password=abc123;MultipleActiveResultSets=true");

            return new ConsoleShopperDbContext(optionsBuilder.Options);
        }
    }
}

using ConsoleShopper.Domain;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ConsoleShopperDb;User Id=sa;Password=abc123;MultipleActiveResultSets=true", b => b.MigrationsAssembly("ConsoleShopper.Repository"));
        }
    }

    public class ConsoleShopperDbContextFactory : IDesignTimeDbContextFactory<ConsoleShopperDbContext>
    {
        public ConsoleShopperDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsoleShopperDbContext>();
            optionsBuilder.UseSqlServer("Server =.; Database = ConsoleShopperDb; User Id = sa; Password = abc123; MultipleActiveResultSets = true");

            return new ConsoleShopperDbContext(optionsBuilder.Options);
        }
    }
}

using ConsoleShopper.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShopper.Repository.DataAccess
{
  
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed UserType data
            modelBuilder.Entity<UserType>().HasData(
                new UserType { Id = 1, Type = "Admin" },
                new UserType { Id = 2, Type = "Customer" }
                );
            // Seed Customer data
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Sulav", LastName = "Aryal", Password = "password", UserTypeId = 1 },
                new Customer { Id = 2, FirstName = "Danyelle", LastName = "Tsosie", Password = "password", UserTypeId = 2 },
                new Customer { Id = 3, FirstName = "Brigitte", LastName = "Laufer", Password = "password", UserTypeId = 2 },
                new Customer { Id = 4, FirstName = "Bettie", LastName = "Turek", Password = "password", UserTypeId = 2 },
                new Customer { Id = 5, FirstName = "Kenneth", LastName = "Windsor", Password = "password", UserTypeId = 2 },
                new Customer { Id = 6, FirstName = "Maribeth", LastName = "Fontenot", Password = "password", UserTypeId = 2 },
                new Customer { Id = 7, FirstName = "Barret", LastName = "Waltrip", Password = "password", UserTypeId = 2 },
                new Customer { Id = 8, FirstName = "Jeana", LastName = "Dunston", Password = "password", UserTypeId = 2 },
                new Customer { Id = 9, FirstName = "Mirian", LastName = "Stroda", Password = "password", UserTypeId = 2 },
                new Customer { Id = 10, FirstName = "Beverley", LastName = "Digangi", Password = "password", UserTypeId = 2 },
                new Customer { Id = 11, FirstName = "Lucilla", LastName = "Chang", Password = "password", UserTypeId = 2 },
                new Customer { Id = 12, FirstName = "Gigi", LastName = "Degree", Password = "password", UserTypeId = 2 },
                new Customer { Id = 13, FirstName = "Taneka", LastName = "Ord", Password = "password", UserTypeId = 2 },
                new Customer { Id = 14, FirstName = "Moises", LastName = "Meche", Password = "password", UserTypeId = 2 },
                new Customer { Id = 15, FirstName = "Hans", LastName = "Spurgin", Password = "password", UserTypeId = 2 },
                new Customer { Id = 16, FirstName = "Mireya", LastName = "Pierro", Password = "password", UserTypeId = 2 },
                new Customer { Id = 17, FirstName = "Susy", LastName = "Argo", Password = "password", UserTypeId = 2 },
                new Customer { Id = 18, FirstName = "Althea", LastName = "Dent", Password = "password", UserTypeId = 2 },
                new Customer { Id = 19, FirstName = "Rosana", LastName = "Purvis", Password = "password", UserTypeId = 2 },
                new Customer { Id = 20, FirstName = "Serena", LastName = "San", Password = "password", UserTypeId = 2 }
            );
        }
    }
}

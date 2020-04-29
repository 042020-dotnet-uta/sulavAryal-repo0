using ConsoleShopper.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShopper.Repository.DataAccess
{

    static class ConsoleShopperSeed
    {
        /// <summary>
        /// Seed data for initial setup 
        /// Eventually gotta get deleted. 
        /// </summary>
        /// <returns></returns>
        internal static List<Customer> DataSource()
        {

            return new List<Customer>()
             {
                new Customer() {Id = 1, FirstName = "Rosalinda", LastName = "Hope"},
                new Customer() {Id = 2, FirstName = "Danyelle", LastName = "Tsosie"},
                new Customer() {Id = 3, FirstName = "Brigitte", LastName = "Laufer"},
                new Customer() {Id = 4, FirstName = "Bettie", LastName = "Turek"},
                new Customer() {Id = 5, FirstName = "Kenneth", LastName = "Windsor"},
                new Customer() {Id = 6, FirstName = "Maribeth", LastName = "Fontenot"},
                new Customer() {Id = 7, FirstName = "Barrett", LastName = "Waltrip"},
                new Customer() {Id = 8, FirstName = "Jeana", LastName = "Dunston"},
                new Customer() {Id = 9, FirstName = "Mirian", LastName = "Strode"},
                new Customer() {Id = 10, FirstName = "Beverley", LastName = "Digangi"},
                new Customer() {Id = 11, FirstName = "Lucilla", LastName = "Chang"},
                new Customer() {Id = 12, FirstName = "Gigi", LastName = "Degree"},
                new Customer() {Id = 13, FirstName = "Taneka", LastName = "Ord"},
                new Customer() {Id = 14, FirstName = "Moises", LastName = "Meche"},
                new Customer() {Id = 15, FirstName = "Hans", LastName = "Spurgin"},
                new Customer() {Id = 16, FirstName = "Mireya", LastName = "Pierro"},
                new Customer() {Id = 17, FirstName = "Susy", LastName = "Argo"},
                new Customer() {Id = 18, FirstName = "Althea", LastName = "Dent"},
                new Customer() {Id = 19, FirstName = "Rosana", LastName = "Purvis"},
                new Customer() {Id = 20, FirstName = "Serena", LastName = "San"}
            };

        }
    }
}

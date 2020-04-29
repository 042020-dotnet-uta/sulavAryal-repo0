using ConsoleShopper.Domain;
using ConsoleShopper.Repository.DataAccess;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleShopper.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ILogger<ICustomerRepository> _logger;
        private IList<Customer> _dataSource { get; set; } = ConsoleShopperSeed.DataSource();

        public CustomerRepository(ILogger<ICustomerRepository> logger)
        {
            _logger = logger;
        }


        public List<Customer> GetAllCustomers()
        {
            return _dataSource.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _dataSource.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool IsCustomer(string firstName, string lastName)
        {
            var customer = _dataSource.Where(x => x.FirstName == firstName && x.LastName == lastName).ToList();
            if (customer != null)
            {
                return true;
            }
            return false;
        }

        #region Commented DataSource
        //private List<Customer> DataSource()
        //{

        //    return new List<Customer>()
        //     {
        //        new Customer() {Id = 1, FirstName = "Rosalinda", LastName = "Hope"},
        //        new Customer() {Id = 2, FirstName = "Danyelle", LastName = "Tsosie"},
        //        new Customer() {Id = 3, FirstName = "Brigitte", LastName = "Laufer"},
        //        new Customer() {Id = 4, FirstName = "Bettie", LastName = "Turek"},
        //        new Customer() {Id = 5, FirstName = "Kenneth", LastName = "Windsor"},
        //        new Customer() {Id = 6, FirstName = "Maribeth", LastName = "Fontenot"},
        //        new Customer() {Id = 7, FirstName = "Barrett", LastName = "Waltrip"},
        //        new Customer() {Id = 8, FirstName = "Jeana", LastName = "Dunston"},
        //        new Customer() {Id = 9, FirstName = "Mirian", LastName = "Strode"},
        //        new Customer() {Id = 10, FirstName = "Beverley", LastName = "Digangi"},
        //        new Customer() {Id = 11, FirstName = "Lucilla", LastName = "Chang"},
        //        new Customer() {Id = 12, FirstName = "Gigi", LastName = "Degree"},
        //        new Customer() {Id = 13, FirstName = "Taneka", LastName = "Ord"},
        //        new Customer() {Id = 14, FirstName = "Moises", LastName = "Meche"},
        //        new Customer() {Id = 15, FirstName = "Hans", LastName = "Spurgin"},
        //        new Customer() {Id = 16, FirstName = "Mireya", LastName = "Pierro"},
        //        new Customer() {Id = 17, FirstName = "Susy", LastName = "Argo"},
        //        new Customer() {Id = 18, FirstName = "Althea", LastName = "Dent"},
        //        new Customer() {Id = 19, FirstName = "Rosana", LastName = "Purvis"},
        //        new Customer() {Id = 20, FirstName = "Serena", LastName = "San"}
        //    };

        //}
        #endregion
    }
}

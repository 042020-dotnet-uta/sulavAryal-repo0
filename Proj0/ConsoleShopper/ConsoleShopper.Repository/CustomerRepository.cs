using ConsoleShopper.Domain;
using ConsoleShopper.Repository.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleShopper.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ILogger<ICustomerRepository> _logger;
        private readonly ConsoleShopperDbContext _dbContext;

        // Disabled Seed data as database connection is working now. 
        //private IList<Customer> _dataSource { get; set; } = ConsoleShopperSeed.DataSource();

        public CustomerRepository(ILogger<CustomerRepository> logger, ConsoleShopperDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #region Get Customer Data (DQL)
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var result = _dbContext.Customers.Select(x => x).AsNoTracking();
            return await result.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            //return _dataSource.Where(x => x.Id == id).FirstOrDefault();
            return await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        #endregion

        #region Insert, Update, Delete Data (DML)

        public async Task InsertCustomerAsync(Customer customerToInsert)
        {
            _dbContext.Customers.Add(customerToInsert);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customerToUpdate)
        {
            
             _dbContext.Customers.Update(customerToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Customer customerToDelete)
        {
            _dbContext.Customers.Remove(customerToDelete);
            await _dbContext.SaveChangesAsync();
        }

        #endregion


        public bool IsCustomer(string firstName, string lastName)
        {
            // var customer = _dataSource.Where(x => x.FirstName == firstName && x.LastName == lastName).ToList();
            var customer = _dbContext.Customers.Where(x => x.FirstName == firstName && x.LastName == lastName).ToList();

            if (customer != null)
            {
                return true;
            }
            return false;
        }
    }
}

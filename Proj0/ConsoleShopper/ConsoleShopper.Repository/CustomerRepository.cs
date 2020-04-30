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
            try
            {
                return await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
            //return _dataSource.Where(x => x.Id == id).FirstOrDefault();

        }
        #endregion

        #region Insert, Update, Delete Data (DML)

        public async Task InsertCustomerAsync(Customer customerToInsert)
        {
            try
            {
                _dbContext.Customers.Add(customerToInsert);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task UpdateCustomerAsync(Customer customerToUpdate)
        {
            try
            {
                _dbContext.Customers.Update(customerToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public async Task DeleteCustomerAsync(Customer customerToDelete)
        {
            try
            {
                _dbContext.Customers.Remove(customerToDelete);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        #endregion


        public bool IsCustomer(string firstName, string lastName, int userTypeId)
        {
            var customer = _dbContext.Customers.Where(x => x.FirstName == firstName && x.LastName == lastName && x.UserTypeId == userTypeId ).ToList();

            if (customer != null)
            {
                return true;
            }
            return false;
        }
    }
}

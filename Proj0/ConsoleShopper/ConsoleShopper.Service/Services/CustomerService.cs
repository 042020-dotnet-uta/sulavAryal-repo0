using ConsoleShopper.Domain;
using ConsoleShopper.Repository;
using ConsoleShopper.Repository.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleShopper.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers =  await _customerRepository.GetAllCustomersAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerIdAsync(int id)
        {

            var repo = await _customerRepository.GetCustomerByIdAsync(id);
            if (repo != null)
            {
                //Console.WriteLine($"\u001b[31mStart of Logging\u001b[0m");
                //_logger.LogInformation("LogInformation = Hello. My name is Log LogInformation");
                //_logger.LogWarning("LogWarning = At {time} Now I'm Loggy McLoggerton", DateTime.Now);
                //_logger.LogCritical("LogCritical = As of now, I'm Scrog McLog");
                //_logger.LogDebug("Log Debug");//not printed to console
                //_logger.LogError("LogError");
                //_logger.LogTrace("Log Trace = Tracing my way back home.");//not printed to console
                //Console.WriteLine($"\u001b[31mEnd of Logging\u001b[0m\n");

                return repo;
            }
            return null;
        }

        public async Task InsertCustomerAsync(Customer customerToInsert)
        {
            await _customerRepository.InsertCustomerAsync(customerToInsert);
        }

        public async Task<bool> IsAdmin(string username, string password)
        {
            return await _customerRepository.IsAdmin(username, password);   
        }

        public async Task UpdateCustomerAsync(Customer customerToUpdate)
        {
            await _customerRepository.UpdateCustomerAsync(customerToUpdate);
        }

        public async Task DeleteCustomerAsync(Customer customerToDelete)
        {
            await _customerRepository.DeleteCustomerAsync(customerToDelete);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersBySearchStringAsync(string searchString)
        {
           return await _customerRepository.GetCustomerBySearchStringAsync(searchString);
        }
    }
}

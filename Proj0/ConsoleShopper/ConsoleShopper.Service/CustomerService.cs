using ConsoleShopper.Domain;
using ConsoleShopper.Repository;
using Microsoft.Extensions.Logging;
using System;

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

        public Customer GetCustomerId(int id)
        {

            var repo = _customerRepository.GetCustomerById(id);
            if (repo != null) 
            {
                Console.WriteLine($"\u001b[31mStart of Logging\u001b[0m");
                _logger.LogInformation("LogInformation = Hello. My name is Log LogInformation");
                _logger.LogWarning("LogWarning = At {time} Now I'm Loggy McLoggerton", DateTime.Now);
                _logger.LogCritical("LogCritical = As of now, I'm Scrog McLog");
                _logger.LogDebug("Log Debug");//not printed to console
                _logger.LogError("LogError");
                _logger.LogTrace("Log Trace = Tracing my way back home.");//not printed to console
                Console.WriteLine($"\u001b[31mEnd of Logging\u001b[0m\n");

                return repo;
            }
            return null;
        }
    }
}

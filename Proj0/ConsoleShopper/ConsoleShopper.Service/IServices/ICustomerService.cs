using ConsoleShopper.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleShopper.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<IEnumerable<Customer>> GetAllCustomersBySearchStringAsync(string searchString);
        Task<Customer> GetCustomerIdAsync(int id);
        Task InsertCustomerAsync(Customer customerToInsert);
        Task UpdateCustomerAsync(Customer customerToUpdate);
        Task DeleteCustomerAsync(Customer customerToDelete);
        Task<bool> IsAdmin(string username, string password);

    }
}
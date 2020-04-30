using ConsoleShopper.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleShopper.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task InsertCustomerAsync(Customer customerToInsert);
        Task UpdateCustomerAsync(Customer customerToUpdate);
        Task DeleteCustomerAsync(Customer customerToDelete);
        Task<bool> IsCustomer(string username, string password);
    }
}
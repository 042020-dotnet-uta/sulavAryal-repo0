using ConsoleShopper.Domain;
using System.Collections.Generic;

namespace ConsoleShopper.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        bool IsCustomer(string firstName, string lastName);
    }
}
﻿using ConsoleShopper.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleShopper.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerIdAsync(int id);
        Task InsertCustomerAsync(Customer customerToInsert);
        Task UpdateCustomerAsync(Customer customerToUpdate);
        Task DeleteCustomerAsync(Customer customerToDelete);
        bool IsCustomer(string firstName, string lastName, int userTypeId);

    }
}
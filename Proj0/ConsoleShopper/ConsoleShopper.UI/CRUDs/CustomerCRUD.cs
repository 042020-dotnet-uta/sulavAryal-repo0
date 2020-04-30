using ConsoleShopper.Domain;
using ConsoleShopper.Service;
using ConsoleShopper.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleShopper.UI
{
    public class CustomerCRUD
    {
        // Bringing in DI container built from ContainerBuilder.cs. 
        static readonly IServiceProvider Container = ContainerBuilder.Build();
        // flag to allow or disallow GetCustomerByIdAsync to display message. 
        bool flag = true;
        /// <summary>
        /// Gets Customer by Id asynchronously 
        /// </summary>
        /// <param name="customerIdStringParm">Optional</param>
        /// <returns>Customer or null if customer not found</returns>
        public async Task<Customer> GetCustomerByIdAsync(string customerIdStringParm = "")
        {
            int customerId = 0;
            // checks if have anything coming from parameter
            if (!string.IsNullOrEmpty(customerIdStringParm))
            {

                // static helper function ParseString.ToInt
                // returns 0 if it fails to Parse String to Int .
                int customerIdInt = ParseString.ToInt(customerIdStringParm);

                // check for that 0
                if (customerIdInt != 0)
                {
                    customerId = customerIdInt;
                }

            }

            // if not asks for user's input
            else
            {
                Console.Write("\nEnter the Id of customer: ");
                var customerIdString = Console.ReadLine();

                // static helper function Converts.ToInt
                // returns 0 if it fails to Parse string into Int .
                int customerIdInt = ParseString.ToInt(customerIdString);

                if (customerIdInt != 0)
                {
                    customerId = customerIdInt;
                }
            }

            // Brings in Interface for CustomerServer through DI Container
            var customerService = Container.GetService<ICustomerService>();

            // brings-in Customer specific to the Id provided awaits till then. 
            var customer = await customerService.GetCustomerIdAsync(customerId);
            // if the customer with provided Id does exits
            if (customer != null)
            {
                // Prints the Customer's Details
                Console.WriteLine(customer);
                if (!string.IsNullOrEmpty(customerIdStringParm))
                {
                    return customer;
                }
                return null;
            }
            // if the customer with provided Id does not exit
            else
            {
                if (flag)
                {
                    // Prints Customer not found message to the console 
                    //Console.WriteLine("Customer not found");
                    // and returns null 
                    Console.WriteLine("Customer not found");
                    flag = false;
                    return null;
                }
               
                
                return null;
            }
        }

        public async Task CreateACustomerAsync()
        {
            Console.WriteLine("************************* Welcome to the customer create menu ******************************\n");
            Console.WriteLine("Your first name will be used as the username.");
            Console.Write("\nEnter your first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter your preferred password: ");
            var password = Console.ReadLine();


            if (!string.IsNullOrEmpty(firstName) &&
                !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(password))
            {
                Console.WriteLine($"Welcome {firstName} {lastName}");
                // Create a customer from user inserted strings
                var customer = new Customer { FirstName = firstName, LastName = lastName, Password = password };

                // conjure up an interface to service layer 
                var insertCustomer = Container.GetService<ICustomerService>();

                // pass the customer up the chain through DI injected dbcontext to the service layer
                await insertCustomer.InsertCustomerAsync(customer);
                Console.WriteLine("Customer Created");
            }

        }

        public async Task UpdateTheCustomerAsync()
        {
            // Customer updatedCustomer, string updatedFirstName, string updatedLastName

            Console.WriteLine("************************* Welcome to the  customer update menu ******************************\n");
            Console.Write("\nEnter Id of the Customer you want update: ");
            var customerId = Console.ReadLine();
            Program p = new Program();

            var customerToUpdate = await GetCustomerByIdAsync(customerId);
            if (customerToUpdate != null)
            {
                Console.WriteLine($"You sure want to Update {customerToUpdate.FirstName} {customerToUpdate.LastName} 's details from db? ");
                Console.Write("Write yes and press enter to continue:");
                var result = Console.ReadLine();
                if (result.ToLower().Trim() != "yes")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Write the updated first name: ");
                    var updatedFirstName = Console.ReadLine();
                    Console.WriteLine("Write the updated last name: ");
                    var updatedLastName = Console.ReadLine();

                    customerToUpdate.FirstName = updatedFirstName;
                    customerToUpdate.LastName = updatedLastName;
                    var customerService = Container.GetService<ICustomerService>();
                    await customerService.UpdateCustomerAsync(customerToUpdate);
                }
            }
        }

        public async Task DeleteCustomerAsync()
        {
            Console.WriteLine("************************* Welcome to the customer delete menu ******************************\n");

            // Check if the current user is admin or not 
            Program p = new Program();
            Console.Write("\nEnter your username: ");
            var username = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            if (!await IsAdmin(username, password))
            {
                Console.WriteLine("Sorry you don't have the authority to do this.");
                return;
            }
            // Asks for the Customer's Id whom should be deleted. 
            Console.Write("Enter Id of the Customer you want delete: ");

            var customerId = Console.ReadLine();

            // flag to disallow GetCustomerByIdAsync method to display message. 
            flag = false;
            // Note : customerId of type string gets converted to int inside GetCustomerByIdAsync method 
            var customerToDelete = await GetCustomerByIdAsync(customerId);
        

            var customerService = Container.GetService<ICustomerService>();
            if (customerToDelete != null)
            {
                Console.WriteLine($"You sure want to delete {customerToDelete.FirstName} {customerToDelete.LastName} from db? ");
                var result = Console.ReadLine();
                if (result.ToLower() == "yes")
                {
                    await customerService.DeleteCustomerAsync(customerToDelete);
                    Console.WriteLine($"{customerToDelete.FirstName} {customerToDelete.LastName} deleted.");
                }
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        /// <summary>
        /// Tests for users authorization level 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> IsAdmin(string username, string password)
        {
            var validCustomer = Container.GetService<ICustomerService>();
            var validity = await validCustomer.IsAdmin(username, password);
            return validity;
        }
    }
}

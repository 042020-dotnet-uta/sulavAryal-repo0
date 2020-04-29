using ConsoleShopper.Domain;
using ConsoleShopper.Service;
using ConsoleShopper.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleShopper
{
    class Program
    {


        // Bringing in DI container built from ContainerBuilder.cs. 
        public static readonly IServiceProvider Container = ContainerBuilder.Build();

        public static async Task Main(string[] args)
        {


            Console.Title = "Shoppoholic";

            string title = @"
     __      __                .__                                          
/  \    /  \ ____     _____|  |__   ____ ______     ____   ______  _  __
\   \/\/   // __ \   /  ___/  |  \ /  _ \\____ \   /    \ /  _ \ \/ \/ /
 \        /\  ___/   \___ \|   Y  (  <_> )  |_> > |   |  (  <_> )     / 
  \__/\  /  \___  > /____  >___|  /\____/|   __/  |___|  /\____/ \/\_/  
       \/       \/       \/     \/       |__|          \/               
";
            Console.WriteLine(title);
            // Create an instance of the Program object

            Program p = new Program();
            while (true)
            {

                Console.Write("Press 1 to get to the main menu, Press any other key to exit: ");
                var input = Console.ReadLine();
                if (input != "1")
                {

                    // works well on windows 10 only. 
                    Console.WriteLine("\u001b[31mAborting Shopping now...!\u001b[0m");
                    Console.Read();
                    break;
                }
                else
                {
                    Console.WriteLine("********************Welcome to the main menu************************");

                    Console.WriteLine("Press 1 for Customer by Id, Press 2 to insert a Customer, Press 3 to Update the customer, Press 4 to Delete the customer");
                    Console.Write("Enter your Choice: ");
                    input = Console.ReadLine();

                    if (input == "1")
                    {
                        // Gives back detail of the customer whos Id is provided. 
                        await p.GetCustomerByIdAsync();
                    }
                    else if (input == "2")
                    {
                        // Creates a Customer
                        await p.CreateACustomerAsync();
                    }
                    else if (input == "3")
                    {
                        // Updates a Customer 
                        await p.UpdateTheCustomerAsync();

                    }
                    else if (input == "4")
                    {
                        // Deletes a Customer
                        await p.DeleteCustomerAsync();
                    }
                    else { break; }

                }
            }
        }

        /// <summary>
        /// Gets Customer by Id asynchronously 
        /// </summary>
        /// <param name="customerIdStringParm">Optional</param>
        /// <returns>Customer or null if customer not found</returns>
        private async Task<Customer> GetCustomerByIdAsync(string customerIdStringParm = "")
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
                Console.Write("Enter the Id of customer: ");
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
                // Prints Customer not found message to the console 
                Console.WriteLine("Customer not found");
                // and returns null 
                return null;
            }
        }

        private async Task CreateACustomerAsync()
        {
            Console.WriteLine("************************* Welcome to the customer create menu ******************************\n");
            Console.Write("Enter your first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            var lastName = Console.ReadLine();

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine($"Welcome {firstName} {lastName}");
                // Create a customer from user inserted strings
                var customer = new Customer { FirstName = firstName, LastName = lastName };

                // conjure up an interface to service layer 
                var insertCustomer = Container.GetService<ICustomerService>();

                // pass the customer up the chain through DI injected dbcontext to the service layer
                await insertCustomer.InsertCustomerAsync(customer);
                Console.WriteLine("Customer Created");
            }

        }

        private async Task UpdateTheCustomerAsync()
        {
            // Customer updatedCustomer, string updatedFirstName, string updatedLastName

            Console.WriteLine("************************* Welcome to the  customer update menu ******************************\n");
            Console.Write("Enter Id of the Customer you want update: ");
            var customerId = Console.ReadLine();
            Program p = new Program();

            var customerToUpdate = await p.GetCustomerByIdAsync(customerId);
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

        private async Task DeleteCustomerAsync()
        {
            Console.WriteLine("************************* Welcome to the customer delete menu ******************************\n");
            // Asks for the Customer's Id whom should be deleted. 
            Console.WriteLine("Enter Id of the Customer you want delete.");

            var customerId = Console.ReadLine();

            Program p = new Program();

            // Note : customerId of type string gets converted to int inside GetCustomerByIdAsync method 
            var customerToDelete = await p.GetCustomerByIdAsync(customerId);

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
    }

}

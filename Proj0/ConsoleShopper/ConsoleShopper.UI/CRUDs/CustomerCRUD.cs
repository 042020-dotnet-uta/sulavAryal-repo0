using ConsoleShopper.Domain;
using ConsoleShopper.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleShopper.UI
{
    public class CustomerCRUD
    {
        // Bringing in DI container built from ContainerBuilder.cs. 
        static readonly IServiceProvider Container = ContainerBuilder.Build();
        // flag to allow or disallow GetCustomerByIdAsync to display message. 
        bool flag = true;
        bool isAdmin = false;

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
                // calling code sets this flag false if they want to suppress
                // the message coming in from here. 
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

        public async Task<IEnumerable<Customer>> GetCustomerBySearchStringAsync(string searchString = "")
        {
            Console.Write("\nEnter Customer's First Name or Last Name: ");
            var searchTerm = Console.ReadLine();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var customerService = Container.GetService<ICustomerService>();
                var customers = await customerService.GetAllCustomersBySearchStringAsync(searchTerm);
                Console.Write("******************************************\n");
                int count = 0;
                foreach (Customer c in customers)
                {
                    count++;
                    Console.Write($"{count}. {c.FirstName} {c.LastName}\n");
                }
                if (count == 0)
                {
                    string text = "\nSorry this search yeilded no result, no customer with that First Name or Last Name found in the record\n";
                    foreach (char c in text)
                    {
                        Console.Write(c);
                        Thread.Sleep(40);
                    }
                   
                    Console.Write("\n******************************************");
                    return null;
                }

                Console.Write("******************************************");

            }

            return null;
        }
        public async Task CreateACustomerAsync()
        {
            Console.WriteLine("************************* Welcome to the Customer Creation menu ******************************\n");

            //Check if the current user is admin or not 

           

            //Console.Write("\nEnter your username: ");
            //var username = Console.ReadLine();
            //Console.Write("Enter your password: ");
            //var password = Console.ReadLine();

            Console.WriteLine("Your first name will be used as the username.");
            Console.Write("\nEnter your first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter your preferred password: ");
            var password = Console.ReadLine();
            while (true) 
            {
                Console.Write("Enter your password again for confirmation: ");
                var password2 = Console.ReadLine();
                if (password != password2) 
                {
                    Console.WriteLine("Sorry your password didn't match");
                    continue; 
                }
                else { break; }
            }
         

            Console.Write("Are you one our staff members? Type yes and press enter if you are, otherwise press any other key to continue : ");
            string staffCheck = "";
            staffCheck = Console.ReadLine();
            if (staffCheck.Trim().ToLower() == "yes")
            {
                if (!await IdendityValidator.IsAdmin())
                {
                    string text = "\nUsername and or password failed...\nPlease enter your username and password carefully next time.\nExiting to main menu now....\nAny unauthorized attempts to subvert the system will be logged and reported to the relevant authority.\n";
                    foreach (char c in text)
                    {
                        Console.Write(c);
                        Thread.Sleep(40);
                    }
                    return;
                }
                else
                { isAdmin = true; }
            }
            
            if (!string.IsNullOrEmpty(firstName) &&
                !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(password))
            {
               
                // Create a customer from user inserted strings
                
                var customer = new Customer { FirstName = firstName, LastName = lastName, Password = password, UserTypeId = isAdmin ? 1: 2 };

                // conjure up an interface to service layer 
                var insertCustomer = Container.GetService<ICustomerService>();

                // pass the customer up the chain through DI injected dbcontext to the service layer
                await insertCustomer.InsertCustomerAsync(customer);
                Console.WriteLine("Customer Creation successful");
                Console.WriteLine($"Welcome to the Console Shopper family {firstName} {lastName}");
                if (isAdmin) { isAdmin = false; }
            }

        }

        public async Task UpdateTheCustomerAsync()
        {
            // Customer updatedCustomer, string updatedFirstName, string updatedLastName

            Console.WriteLine("************************* Welcome to the  Customer Update menu ******************************\n");

            // Check if the current user is admin or not 
            if (!await IdendityValidator.IsAdmin())
            {
                string text = "\nUsername and or password failed...\nPlease enter your username and password carefully next time.\nExiting to main menu now....\nAny unauthorized attempts to subvert the system will be logged and reported to the relevant authority.\n";
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
                return;
            }

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
            Console.WriteLine("************************* Welcome to the Customer delete menu ******************************\n");

            // Check if the current user is admin or not 
            if (!await IdendityValidator.IsAdmin())
            {
                string text = "\nUsername and or password failed...\nPlease enter your username and password carefully next time.\nExiting to main menu now....\nAny unauthorized attempts to subvert the system will be logged and reported to the relevant authority.\n";
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(40);
                }
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

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
        // public static readonly IServiceProvider Container = ContainerBuilder.Build();

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

            CustomerCRUD customerCRUD = new CustomerCRUD();
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
                        await customerCRUD.GetCustomerByIdAsync();
                    }
                    else if (input == "2")
                    {
                        // Creates a Customer
                        await customerCRUD.CreateACustomerAsync();
                    }
                    else if (input == "3")
                    {
                        // Updates a Customer 
                        await customerCRUD.UpdateTheCustomerAsync();

                    }
                    else if (input == "4")
                    {
                        // Deletes a Customer
                        await customerCRUD.DeleteCustomerAsync();
                    }
                    else { break; }

                }
            }
        }
    }

}

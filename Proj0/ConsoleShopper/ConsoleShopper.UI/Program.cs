using ConsoleShopper.Domain;
using ConsoleShopper.Service;
using ConsoleShopper.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleShopper
{


    class Program
    {

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


            CustomerCRUD customerCRUD = new CustomerCRUD();


            while (true)
            {

                Console.Write("\nPress 1 to get to the main menu, Press any other key to exit: ");
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
                    Console.WriteLine("\n********************Welcome to the Main menu************************");

                    Console.WriteLine("\nPress 1 to Search for Customer,\nPress 2 to Register as a Customer, \nPress 3 to Update Customer Details, \nPress 4 to Delete the Customer");
                    Console.Write("\nEnter your Choice: ");

                    input = Console.ReadLine();

                    if (input == "1")
                    {
                        //  Gives back detail of the customer whos Id is provided. 
                        
                        Console.WriteLine("\n*****************************Welcome to the Search menu ********************************* ");
                        Console.WriteLine("\nPress 1 to search for Customer by Id,\nPress 2 to search Customers by Name");

                        Console.Write("\nEnter your Choice: ");

                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            try
                            {

                                await customerCRUD.GetCustomerByIdAsync();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else if (input == "2")
                        {
                            try
                            {
                                await customerCRUD.GetCustomerBySearchStringAsync();
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine(e.Message);
                            }
                        }
                        else { continue; }


                    }
                    else if (input == "2")
                    {
                        // Creates a Customer
                        try
                        {
                            await customerCRUD.CreateACustomerAsync();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }

                    }
                    else if (input == "3")
                    {
                        // Updates a Customer 
                        try
                        {
                            await customerCRUD.UpdateTheCustomerAsync();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }
                    }
                    else if (input == "4")
                    {
                        // Deletes a Customer
                        try
                        {
                            await customerCRUD.DeleteCustomerAsync();
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }

                    }
                    else { break; }

                }
            }
        }
    }

}

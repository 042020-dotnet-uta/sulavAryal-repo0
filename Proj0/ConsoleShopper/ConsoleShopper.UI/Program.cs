using ConsoleShopper.Domain;
using ConsoleShopper.Service;
using ConsoleShopper.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ConsoleShopper
{
    class Program
    {

        // We need to do this specificly for dotnet core console DI to work. 
        public static readonly IServiceProvider Container = ContainerBuilder.Build();

        static void Main(string[] args)
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

            //using ServiceProvider serviceProvider = RegisterServices(args);
            //IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            //ILogger logger = serviceProvider.GetService<ILogger<Program>>();
            //logger.LogInformation("Github api url is: {githubApiUrl}", configuration["github:apiUrl"]);
            while (true)
            {

                Console.Write("Press 1 for Customer Details, Press any other key to exit: ");
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

                    Console.Write("Enter the Id of customer: ");
                    var custid = Console.ReadLine();
                    Program p = new Program();
                    var customer = p.GetCustomer(custid);
                    if (customer != null)
                    {
                        Console.WriteLine(customer);
                    }
                    else
                    {
                        Console.WriteLine("Customer not found");
                    }

                }
            }
        }

        private Customer GetCustomer(string custid)
        {
            int id;
            if (Int32.TryParse(custid, out id))
            {

                var repo = Container.GetService<ICustomerService>();
                var result = repo.GetCustomerId(id);
                return result;
            }

            return null;
        }


        //private static ServiceProvider RegisterServices(string[] args)
        //{
        //    IConfiguration configuration = SetupConfiguration(args);
        //    var serviceCollection = new ServiceCollection();

        //    serviceCollection.AddLogging(cfg => cfg.AddConsole());
        //    serviceCollection.AddSingleton(configuration);

        //    return serviceCollection.BuildServiceProvider();
        //}

        //private static IConfiguration SetupConfiguration(string[] args)
        //{
        //    return new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .AddEnvironmentVariables()
        //        .AddCommandLine(args)
        //        .Build();
        //}
    }
}

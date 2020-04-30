using ConsoleShopper.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using ConsoleShopper.Repository.DataAccess;
using System.IO;



namespace ConsoleShopper.UI
{
    public static class ContainerBuilder
    {

        //private static IConfiguration SetupConfiguration()
        //{
        //    return new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false)
        //        .AddEnvironmentVariables()
        //        //.AddCommandLine(args)
        //        .Build();
        //}
        public static IServiceProvider Build()
        {
            // Create a list of dependencies
            // You need to install Microsoft.Extensions.DependencyInjection through nuget to be able to use it.
            var services = new ServiceCollection();


            // Build configuration to access appsettings.json file 
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();

            // remove this line, this is for debugging only. 
            var test = configuration.GetSection("Logging");


            // from this point onwards dependencies can be added to the DI container via service collection. 
            // service collection is the bucket/container that holds all the dependencies we inject here. 

            // Here we are injecting Logging service into it. 
            //  services.AddDbContext<ConsoleShopperDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))

            // Adding DbContext into DI Container.
            services.AddDbContext<ConsoleShopperDbContext>(options => options
                // Use DefaultConnection for passworded sa connection 
                // Use AlternativeConnection for windows authenticated connection
                .UseSqlServer(configuration.GetConnectionString("AlternateConnection")));

            // Adding Repository Layer dependencies into DI Container
            services.AddRepositoryLayerServices();

            // Adding Service Layer dependencies into DI Container
            services.AddServiceLayerServices();

            // Adding Configuration into DI Container
            services.AddSingleton<IConfiguration>(configuration);

            // Adding Logging into DI Container
            //services.AddLogging((configure) =>
            // {
            //     configure.ClearProviders();
            //     configure.AddConsole();
            //     //configure.AddConfiguration(configuration.GetSection("Logging"));
            //     configure.SetMinimumLevel(LogLevel.Trace);
            // });

            //services.AddLogging();
            //AddConfiguration(configuration.GetSection("Logging"))

            services.AddLogging((configure) =>
            {
                configure.ClearProviders();
                configure.AddConfiguration(configuration.GetSection("Logging")).AddConsole();
                configure.SetMinimumLevel(LogLevel.Trace);
            });


            return services.BuildServiceProvider();
        }

    }
}

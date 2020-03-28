﻿// Copyright (c) 2020 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Threading.Tasks;
using BookApp;
using BookApp.HelperExtensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Test.Chapter05Listings
{
    public class ExampleProgram
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //After the setup of the services etc have been done we call code to handle 
            host.MigrateDatabase();
            await host.SetupDatabaseAsync();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x&view=aspnetcore-3.0#how-to-add-providers
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); //Clear logging providers to improve performance
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
    /**********************************************************
    #A The recommended way to run any startup code is to add it to the end of the BuildWebHost in the ASP.NET Core Program file
    * ********************************************************/
}
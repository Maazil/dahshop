using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dahshop.Data;
using Dahshop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dahshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Get our database context from the service provider
                var db = services.GetRequiredService<ApplicationDbContext>();
                
                // Get the UserManager and RoleManager also from the service provider
                var um = services.GetRequiredService<UserManager<ApplicationUser>>();
                var rm = services.GetRequiredService<RoleManager<IdentityRole>>();

                // Get the environment so we can check if this is running in development or otherwise
                var environment = services.GetService<IWebHostEnvironment>();

                // Initialise the database using the initializer from Data/ExampleDbInitializer.cs
                ApplicationDbInitializer.Initialize(db, um, rm, environment.IsDevelopment());
            }
            
            host.Run();       
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

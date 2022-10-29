using System;
using System.Linq;
using commandService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService.Data
{
    public static class PrepareDb
    {
        public static void PopulateData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Commands.Any())
            {
                Console.WriteLine("Adding seed data");
                context.Commands.AddRange
                (
                    new Command() { Name = "Dotnet", Publisher = "Microsoft", Cost = "Free" },
                    new Command() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Command() { Name = "DB2", Publisher = "IBM", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already data in place");
            }
        }
    }
}
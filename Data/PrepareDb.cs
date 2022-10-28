using PlatformService.Models;

namespace PlatformService.Data
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
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Adding seed data");
                context.Platforms.AddRange
                (
                    new Platform() { Name = "Dotnet", Publisher = "Micrpspft", Cost = "Free" },
                    new Platform() { Name = "Sql Server Express", Publisher = "Micrpspft", Cost = "Free" },
                    new Platform() { Name = "DB2", Publisher = "IBM", Cost = "Free" }
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
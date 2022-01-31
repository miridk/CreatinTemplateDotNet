using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using webapiApiService.Models;

namespace webapiApiService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.webapiApis.Any())
            {
                Console.WriteLine("--> Seeding data...");

                //Example test data                                    
                context.webapiApis.AddRange(
                    //new webapiApi() { FirstName = "Anders", LastName = "Jensen", PhoneNo = "22461458", Email = "Free@andersen.com" },
                    //new webapiApi() { FirstName = "Henry", LastName = "Davidsen", PhoneNo = "88462433", Email = "hen@block.com" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
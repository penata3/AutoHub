using AutoHub.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutoHub.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "AutomobilesAndJeeps" });
            await dbContext.Categories.AddAsync(new Category { Name = "Buses" });
            await dbContext.Categories.AddAsync(new Category { Name = "Trucks" });
            await dbContext.Categories.AddAsync(new Category { Name = "Motorcycles" });
            await dbContext.Categories.AddAsync(new Category { Name = "Boats" });

            await dbContext.SaveChangesAsync();
        }
    }
}

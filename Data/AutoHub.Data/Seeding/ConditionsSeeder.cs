namespace AutoHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;

    public class ConditionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Conditions.Any())
            {
                return;
            }

            await dbContext.Conditions.AddAsync(new Condition() { Name = "Употребяван" });
            await dbContext.Conditions.AddAsync(new Condition() { Name = "Нов" });
            await dbContext.Conditions.AddAsync(new Condition() { Name = "За части" });

            await dbContext.SaveChangesAsync();
        }
    }
}

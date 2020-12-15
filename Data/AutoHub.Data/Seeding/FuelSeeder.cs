namespace AutoHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;

    public class FuelSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Fuels.Any())
            {
                return;
            }

            await dbContext.Fuels.AddAsync(new Fuel() { Name = "Бензин" });
            await dbContext.Fuels.AddAsync(new Fuel() { Name = "Дизел" });
            await dbContext.Fuels.AddAsync(new Fuel() { Name = "Електрически" });
            await dbContext.Fuels.AddAsync(new Fuel() { Name = "Хибрид" });
            await dbContext.Fuels.AddAsync(new Fuel() { Name = "Метан" });

            await dbContext.SaveChangesAsync();
        }
    }
}

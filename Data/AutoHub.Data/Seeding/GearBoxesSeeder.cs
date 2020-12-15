namespace AutoHub.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;

    public class GearBoxesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.GearBoxes.Any())
            {
                return;
            }

            await dbContext.GearBoxes.AddAsync(new GearBox { Name = "Автоматична" });
            await dbContext.GearBoxes.AddAsync(new GearBox { Name = "Ръчна" });
            await dbContext.GearBoxes.AddAsync(new GearBox { Name = "Полуавтоматична" });
            await dbContext.GearBoxes.AddAsync(new GearBox { Name = "Вариаторна" });
            await dbContext.GearBoxes.AddAsync(new GearBox { Name = "Роботизирана" });
            await dbContext.GearBoxes.AddAsync(new GearBox { Name = "Робот с два съединителя (DSG)" });

            await dbContext.SaveChangesAsync();
        }
    }
}

namespace AutoHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;

    public class ColorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Colors.Any())
            {
                return;
            }

            await dbContext.Colors.AddAsync(new Color { Name = "Blue" });
            await dbContext.Colors.AddAsync(new Color { Name = "Red" });
            await dbContext.Colors.AddAsync(new Color { Name = "Purple" });
            await dbContext.Colors.AddAsync(new Color { Name = "White" });
            await dbContext.Colors.AddAsync(new Color { Name = "Grey" });
            await dbContext.Colors.AddAsync(new Color { Name = "Black" });
            await dbContext.Colors.AddAsync(new Color { Name = "Yellow" });
            await dbContext.Colors.AddAsync(new Color { Name = "Green" });
            await dbContext.Colors.AddAsync(new Color { Name = "Silver" });

            await dbContext.SaveChangesAsync();
        }
    }
}

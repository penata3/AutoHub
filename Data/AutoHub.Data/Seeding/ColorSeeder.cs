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

            await dbContext.Colors.AddAsync(new Color { Name = "Син" });
            await dbContext.Colors.AddAsync(new Color { Name = "Червен" });
            await dbContext.Colors.AddAsync(new Color { Name = "Лилав" });
            await dbContext.Colors.AddAsync(new Color { Name = "Бял" });
            await dbContext.Colors.AddAsync(new Color { Name = "Сив" });
            await dbContext.Colors.AddAsync(new Color { Name = "Черен" });
            await dbContext.Colors.AddAsync(new Color { Name = "Жълт" });
            await dbContext.Colors.AddAsync(new Color { Name = "Зелен" });
            await dbContext.Colors.AddAsync(new Color { Name = "Сребърен" });
            await dbContext.Colors.AddAsync(new Color { Name = "Металик" });
            await dbContext.Colors.AddAsync(new Color { Name = "Тютюн" });
            await dbContext.Colors.AddAsync(new Color { Name = "Графит" });
            await dbContext.Colors.AddAsync(new Color { Name = "Вишнев" });
            await dbContext.Colors.AddAsync(new Color { Name = "Бордо" });
            await dbContext.Colors.AddAsync(new Color { Name = "Бронз" });
            await dbContext.Colors.AddAsync(new Color { Name = "Златист" });
            await dbContext.Colors.AddAsync(new Color { Name = "Кремав" });
            await dbContext.Colors.AddAsync(new Color { Name = "Керемиден" });
            await dbContext.Colors.AddAsync(new Color { Name = "Оранжев" });

            await dbContext.SaveChangesAsync();
        }
    }
}

namespace AutoHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;

    public class CoupesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Coupes.Any())
            {
                return;
            }

            await dbContext.Coupes.AddAsync(new Coupe { Name = "Ван" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Джип" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Кабрио" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Комби" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Купе" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Миниван" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Пикап" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Седан" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Стреч лимузина" });
            await dbContext.Coupes.AddAsync(new Coupe { Name = "Хечбек" });

            await dbContext.SaveChangesAsync();
        }
    }
}

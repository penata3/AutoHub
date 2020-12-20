namespace AutoHub.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;
    using AutoHub.Data.Seeding.RegionTownsDto;
    using Newtonsoft.Json;

    public class MakeModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any() || dbContext.Models.Any())
            {
                return;
            }

            var jsonAsString = File.ReadAllText(@"C:\Users\HP\OneDrive\Desktop\AutoHub\AutoHub\Data\AutoHub.Data\Seeding\JsonFiles\car-models.json");

            var jsonData = JsonConvert.DeserializeObject<MakeModelsDto[]>(jsonAsString);
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var item in jsonData)
            {
                if (!dictionary.ContainsKey(item.Brand))
                {
                    dictionary.Add(item.Brand, new List<string>());
                }

                foreach (var model in item.Models)
                {
                    dictionary[item.Brand].Add(model);
                }
            }

            foreach (var make in dictionary)
            {
                var newMake = new Make() { Name = make.Key };
                await dbContext.Makes.AddAsync(newMake);
                await dbContext.SaveChangesAsync();

                foreach (var model in make.Value)
                {
                    await dbContext.Models.AddAsync(new Model() { Name = model, MakeId = newMake.Id });
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}


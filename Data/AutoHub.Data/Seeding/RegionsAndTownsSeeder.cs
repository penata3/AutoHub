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

    public class RegionsAndTownsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Regions.Any() || dbContext.Towns.Any())
            {
                return;
            }

            var jsonAsString = File.ReadAllText(@"C:\Users\HP\OneDrive\Desktop\AutoHub\AutoHub\Data\AutoHub.Data\Seeding\JsonFiles\towns.json");

            var json = JsonConvert.DeserializeObject<TownRegionDto[]>(jsonAsString);

            var regionsTowns = new Dictionary<string, List<string>>();

            foreach (var item in json)
            {
                if (!regionsTowns.ContainsKey(item.Region))
                {
                    regionsTowns.Add(item.Region, new List<string>());
                }

                regionsTowns[item.Region].Add(item.Name);
            }

            foreach (var reg in regionsTowns)
            {
                var region = new Region() { Name = reg.Key };
                await dbContext.Regions.AddAsync(region);
                await dbContext.SaveChangesAsync();

                foreach (var town in reg.Value)
                {
                    await dbContext.Towns.AddAsync(new Town() { Name = town, RegionId = region.Id });
                }

                await dbContext.SaveChangesAsync();

            }
        }
    }
}

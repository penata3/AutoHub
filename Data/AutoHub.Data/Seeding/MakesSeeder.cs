namespace AutoHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using AutoHub.Data.Models;

    public class MakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            var config = Configuration.Default.WithDefaultLoader();
            var context = new BrowsingContext(config);

            var document = await context
                            .OpenAsync("https://www.autotrader.co.uk/search-form?moreOptions=visible&radius=5&make=AUDI&model=ALLROAD&year-to=2020&onesearchad=Used&onesearchad=Nearly%20New&onesearchad=New&advertising-location=at_cars");

            var test = document.QuerySelectorAll("#make > optgroup > option");

            foreach (var item in test)
            {
                await dbContext.Makes.AddAsync(new Make { Name = item.TextContent.Split(" (")[0] });
            }
        }
    }
}

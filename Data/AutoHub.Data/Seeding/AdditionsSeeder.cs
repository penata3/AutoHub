namespace AutoHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using AutoHub.Data.Models;

    public class AdditionsSeeder : ISeeder
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;

        public AdditionsSeeder()
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Additions.Any())
            {
                return;
            }

            var document = await this.context.OpenAsync("https://www.auto.bg/search");

            var additions = document.QuerySelectorAll("#searchTechOptions > ul > li > label > span");

            foreach (var addition in additions)
            {
                await dbContext.Additions.AddAsync(new Addition() { Name = addition.TextContent });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}

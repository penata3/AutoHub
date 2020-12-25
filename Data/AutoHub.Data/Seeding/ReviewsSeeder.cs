namespace AutoHub.Data.Seeding
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;
    using AutoHub.Data.Seeding.Dto_s;
    using Newtonsoft.Json;

    public class ReviewsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Reviews.Any())
            {
                return;
            }

            var reviewsAsString = File.ReadAllText(@"C:\Users\HP\OneDrive\Desktop\AutoHub\AutoHub\Data\AutoHub.Data\Seeding\JsonFiles\reviews.json");
            var json = JsonConvert.DeserializeObject<ReviewDto[]>(reviewsAsString);

            foreach (var item in json)
            {
                var review = new Review()
                {
                    Title = item.Title,
                    Description = item.Description,
                    VideoUrl = item.VideoUrl,
                };

                await dbContext.Reviews.AddAsync(review);
                await dbContext.SaveChangesAsync();

                var image = new Image()
                {
                    RemoteImageUrl = item.ImageUrl,
                    ReviewId = review.Id,
                    CarId = null,
                };

                await dbContext.Images.AddAsync(image);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

namespace AutoHub.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Services.Data.Implementations;
    using AutoHub.Web.ViewModels.Reviews;
    using Moq;
    using Xunit;

    public class ReviewsServiceTests
    {
        [Fact]
        public void ChekIfReturnCountWorksCorrect()
        {
            var repository = new Mock<IDeletableEntityRepository<Review>>();

            repository.Setup(x => x.AllAsNoTracking()).Returns(this.GetData());

            var reviewsService = new ReviewsService(repository.Object);

            Assert.Equal(2, reviewsService.GetCount());
        }

        [Fact]
        public void IsGetByIdWorkingCorrect()
        {
            var repo = new Mock<IDeletableEntityRepository<Review>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(this.GetData());

            var reviewsService = new ReviewsService(repo.Object);

            Review  revieww = reviewsService.GetReviewById<Review>(1);

            Assert.Equal(0, reviewsService.GetCount());
        }

        public IQueryable<Review> GetData()
        {
            var review = new Review
            {
                Id = 1,
                Title = "TestTitle",
                Description = "Used for testing pourpose",
                VideoUrl = "www.google.com",
                Images = new List<Image>(),
            };

            var review2 = new Review
            {
                Id = 2,
                Title = "TestTitle2",
                Description = "Used for testing pourpose2",
                VideoUrl = "www.google.com2",
                Images = new List<Image>(),
            };

            var reviews = new List<Review> { review, review2 };
            return reviews.AsQueryable();
        }
    }
}

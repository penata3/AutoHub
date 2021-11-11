namespace AutoHub.Services.Data.Implementations
{

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoHub.Web.ViewModels.Reviews;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;

        public ReviewsService(IDeletableEntityRepository<Review> reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public async Task CreateAsync(AddReviewInputModel model, string imagePath,string userId)
        {
            var review = new Review()
            {
                Title = model.Title,
                Description = model.Description,
                VideoUrl = model.VideoUrl,
            };

            Directory.CreateDirectory($"{imagePath}/reviews/");

            foreach (var image in model.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                var img = new Image()
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };

                review.Images.Add(img);

                var path = $"{imagePath}/reviews/{img.Id}.{extension}";
                using Stream fileStream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.reviewsRepository.AddAsync(review);
            await this.reviewsRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var review = this.reviewsRepository.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            this.reviewsRepository.Delete(review);
            await this.reviewsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllReviews<T>(int page, int itemsPerPage)
        {
            var reviews = this.reviewsRepository.AllAsNoTracking()
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();

            return reviews;
        }

        public IEnumerable<T> GetAllReviewsWithDeleted<T>(int page, int itemsPerPage)
        {
            var reviews = this.reviewsRepository.AllWithDeleted()
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();

            return reviews;
        }

        public int GetCount()
        {
            return this.reviewsRepository.AllAsNoTracking().Count();
        }

        public int GetCountWithDeleted()
        {
            return this.reviewsRepository.AllWithDeleted().Count();
        }

        public IEnumerable<T> GetLatestFiveReviews<T>()
        {
            return this.reviewsRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(5)
                .To<T>()
                .ToList();
        }

        public T GetReviewById<T>(int id)
        {
            return this.reviewsRepository.AllAsNoTracking().Where(r => r.Id == id)
                 .To<T>()
                 .FirstOrDefault();
        }
    }
}

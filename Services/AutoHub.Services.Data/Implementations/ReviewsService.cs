namespace AutoHub.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;

        public ReviewsService(IDeletableEntityRepository<Review> reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public IEnumerable<T> GetAllReviews<T>(int page, int itemsPerPage)
        {
            var reviews = this.reviewsRepository.AllAsNoTracking()
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();

            return reviews;
        }

        public int GetCount()
        {
            return this.reviewsRepository.AllAsNoTracking().Count();
        }

        public T GetReviewById<T>(int id)
        {
            return this.reviewsRepository.AllAsNoTracking().Where(r => r.Id == id)
                 .To<T>()
                 .FirstOrDefault();
        }
    }
}

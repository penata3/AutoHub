using System.Collections.Generic;

namespace AutoHub.Services.Data
{
    public interface IReviewsService
    {
        IEnumerable<T> GetAllReviews<T>();
    }
}

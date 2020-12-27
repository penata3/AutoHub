namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReviewsService
    {
        IEnumerable<T> GetAllReviews<T>(int page, int itemsPerPage);

        int GetCount();

        T GetReviewById<T>(int id);
    }
}

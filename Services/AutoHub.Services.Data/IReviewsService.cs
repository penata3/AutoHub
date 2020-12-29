namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Web.ViewModels.Reviews;

    public interface IReviewsService
    {
        IEnumerable<T> GetAllReviews<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllReviewsWithDeleted<T>(int page, int itemsPerPage);

        IEnumerable<T> GetLatestFiveReviews<T>();

        int GetCount();

        int GetCountWithDeleted();

        T GetReviewById<T>(int id);

        Task CreateAsync(AddReviewInputModel model, string imagePath, string userId);

        Task Delete(int id);
    }
}

namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Web.ViewModels.Reviews;

    public interface IReviewsService
    {
        IEnumerable<T> GetAllReviews<T>(int page, int itemsPerPage);

        int GetCount();

        T GetReviewById<T>(int id);

        Task CreateAsync(AddReviewInputModel model, string imagePath, string userId);
    }
}

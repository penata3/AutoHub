namespace AutoHub.Web.ViewComponents
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;

    public class SideBarViewComponent : ViewComponent
    {
        private readonly IReviewsService reviewsService;

        public SideBarViewComponent(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        public IViewComponentResult Invoke()
        {
            var latestReviews = new ReviewListViewModel()
            {
                Reviews = this.reviewsService.GetLatestFiveReviews<ReviewInListViewModel>(),
            };

            return this.View(latestReviews);
        }
    }
}

namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private readonly IReviewsService reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        [HttpGet]
        public IActionResult AllReviews(int id = 1)
        {
            const int ItemsPerPage = 10;

            var model = new ReviewListViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                Reviews = this.reviewsService.GetAllReviews<ReviewInListViewModel>(id, ItemsPerPage),
                ItemsCount = this.reviewsService.GetCount(),
            };

            return this.View(model);
        }


        public IActionResult ReviewById(int id)
        {
            var viewModel = this.reviewsService.GetReviewById<SingleReviewViewModel>(id);
            return this.View(viewModel);
        }
    }
}

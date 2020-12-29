namespace AutoHub.Web.Controllers
{
    using AutoHub.Common;
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
                ActionName = nameof(this.AllReviews),
            };

            return this.View(model);
        }


        public IActionResult ReviewById(int id)
        {
            var viewModel = this.reviewsService.GetReviewById<SingleReviewViewModel>(id);
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.reviewsService.Delete(id);
            return this.RedirectToAction(nameof(this.AllReviews));
        }
    }
}

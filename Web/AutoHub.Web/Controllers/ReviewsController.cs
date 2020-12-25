namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private readonly IReviewsService reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            //var model = this.
            return this.View();
        }
    }
}

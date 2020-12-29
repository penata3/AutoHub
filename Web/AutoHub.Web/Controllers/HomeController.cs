namespace AutoHub.Web.Controllers
{
    using System.Diagnostics;
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels;
    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Home;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICarsService carsService;
        private readonly IReviewsService reviewsService;

        public HomeController(
            ICarsService carsService,
            IReviewsService reviewsService)
        {
            this.carsService = carsService;
            this.reviewsService = reviewsService;
        }
        public IActionResult Index()
        {
            var latestCarViewModel = new LatestCarsAndReviewsList()
            {
                PageNumber = 1,
                ItemsPerPage = 5,
                Cars = this.carsService.GetLatestFiveCars<CarInListViewModel>(),
                Reviews = this.reviewsService.GetLatestFiveReviews<ReviewInListViewModel>(),
                ItemsCount = 5,
                ActionName = nameof(this.Index),
            };             
            return this.View(latestCarViewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

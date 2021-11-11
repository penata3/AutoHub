namespace AutoHub.Web.Controllers
{
    using System.Diagnostics;

    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels;
    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Home;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class HomeController : BaseController
    {
        private readonly ICarsService carsService;
        private readonly IReviewsService reviewsService;
        private readonly IConfiguration configuration;

        public HomeController(
            ICarsService carsService,
            IReviewsService reviewsService,
            IConfiguration configuration)
        {
            this.carsService = carsService;
            this.reviewsService = reviewsService;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            var latestCarViewModel = new LatestCarsList()
            {
                Cars = this.carsService.GetLatestFiveCars<CarInListViewModel>(),
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

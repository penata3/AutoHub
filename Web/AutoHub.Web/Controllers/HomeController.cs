namespace AutoHub.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels;
    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Home;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using SendGrid;
    using SendGrid.Helpers.Mail;

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

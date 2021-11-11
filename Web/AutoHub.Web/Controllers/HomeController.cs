namespace AutoHub.Web.Controllers
{
    using System.Diagnostics;

    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels;
    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICarsService carsService;

        public HomeController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public IActionResult Index()
        {
            var latestCarViewModel = new LatestCarsList()
            {
                Cars = this.carsService.GetLatestFiveCars<BasicCarViewModel>(),
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

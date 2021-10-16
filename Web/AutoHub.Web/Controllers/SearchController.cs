namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : Controller
    {
        private readonly IAdditionsService additionsService;
        private readonly ICarsService carsService;

        public SearchController(
            IAdditionsService additionsService,
            ICarsService carsService)
        {
            this.additionsService = additionsService;
            this.carsService = carsService;
        }

        public IActionResult Index()
        {
            var additionsList = new AllAdditionsListViewModel()
            {
                Additions = this.additionsService.GetAllAditions(),
            };
            return this.View(additionsList);
        }


        [HttpGet]
        public IActionResult List(ChekedAdditionsList input)
        {
            var model = new CarsListViewModel()
            {
                Cars = this.carsService.GetAllByAdditions<CarInListViewModel>(input.Additions),
            };

            return this.View(model);
        }

    }
}

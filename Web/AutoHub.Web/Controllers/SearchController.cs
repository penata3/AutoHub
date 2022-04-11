namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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

        public async Task<IActionResult> AdvanedSearch()
        {
            var input = new AdvancedSearchViewModel();
            await this.carsService.AddSelectListValuesForAdvancedSearchModel(input);

            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> AdvanedSearch(AdvancedSearchViewModel model)
        {
            ;
            return this.View(model);
        }

        [HttpGet]
        public IActionResult List(AdvancedSearchViewModel input)
        {
            var model = new CarsListViewModel()
            {
                Cars = this.carsService.GetAllBySearchingCriteria<SemiDetailedCarViewModel>(input),
            };

            return this.View(model);
        }

        //[HttpGet]
        //public IActionResult List(ChekedAdditionsList input)
        //{
        //    var model = new CarsListViewModel()
        //    {
        //        Cars = this.carsService.GetAllByAdditions<SemiDetailedCarViewModel>(input.Additions),
        //    };

        //    return this.View(model);
        //}
    }
}

namespace AutoHub.Web.Controllers
{
    using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var model = new SearchInputModel();
            await this.carsService.AddSelectListValuesForAdvancedSearchModel(model);
            model.Additions = this.additionsService.GetAllAditions();
            return this.View(model);
        }

        //public async Task<IActionResult> AdvanedSearch()
        //{
        //    var model = new SearchInputModel();
        //    await this.carsService.AddSelectListValuesForAdvancedSearchModel(model);
        //    model.Additions = this.additionsService.GetAllAditions();

        //    return this.View(model);
        //}

        [HttpGet]
        public async Task<IActionResult> List(SearchingOptions input, ChekedAdditionsList additionsList)
        {
            var model = new CarsListViewModel()
            {
                Cars = await this.carsService.GetAllBySearchOptions<SemiDetailedCarViewModel>(input, additionsList.Additions),
            };

            return this.View(model);
        }
    }
}
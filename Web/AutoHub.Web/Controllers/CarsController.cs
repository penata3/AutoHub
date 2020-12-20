namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Vehicles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CarsController : Controller
    {
        private readonly IMakeService makeService;
        private readonly IColorService colorService;
        private readonly ICoupesService coupesService;
        private readonly IConditionsService conditionsService;
        private readonly IGearBoxesService gearBoxesService;
        private readonly IRegionsServices regionsServices;
        private readonly IFuelsServices fuelsServices;

        public CarsController(
            IMakeService makeService,
            IColorService colorService,
            ICoupesService coupesService,
            IConditionsService conditionsService,
            IGearBoxesService gearBoxesService,
            IRegionsServices regionsServices,
            IFuelsServices fuelsServices)
        {
            this.makeService = makeService;
            this.colorService = colorService;
            this.coupesService = coupesService;
            this.conditionsService = conditionsService;
            this.gearBoxesService = gearBoxesService;
            this.regionsServices = regionsServices;
            this.fuelsServices = fuelsServices;
        }

        [Authorize]
        public async Task<IActionResult> AddCar()
        {
            var viewModel = new AddCarInputModel();
            viewModel.MakesItems = this.makeService.GetAllMakes();
            viewModel.Colors = this.colorService.GetAllColors();
            viewModel.CoupeTypes = this.coupesService.GetAllCoupes();
            viewModel.Conditions = await this.conditionsService.GetAllConditionsAsync();
            viewModel.GearBoxes = await this.gearBoxesService.GetAllGearBoxesAsync();
            viewModel.Regions = await this.regionsServices.GetAllRegionsAsync();
            viewModel.Fuels = await this.fuelsServices.GetAllFuelTypesAsync();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCar(AddCarInputModel model)
        {
            return this.Json(model);
        }
    }
}

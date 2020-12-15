namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Vehicles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class CarsController : Controller
    {
        private readonly IMakeService makeService;
        private readonly IColorService colorService;
        private readonly ICoupesService coupesService;

        public CarsController(
            IMakeService makeService,
            IColorService colorService,
            ICoupesService coupesService)
        {
            this.makeService = makeService;
            this.colorService = colorService;
            this.coupesService = coupesService;
        }

        [Authorize]
        public IActionResult AddCar()
        {
            var viewModel = new AddCarInputModel();
            viewModel.MakesItems = this.makeService.GetAllMakes();
            viewModel.Colors = this.colorService.GetAllColors();
            viewModel.CoupeTypes = this.coupesService.GetAllCoupes();
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

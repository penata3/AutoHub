namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Vehicles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class VehiclesController : Controller
    {
        private readonly IMakeService makeService;
        private readonly IColorService colorService;

        public VehiclesController(
            IMakeService makeService,
            IColorService colorService)
        {
            this.makeService = makeService;
            this.colorService = colorService;
        }

        [Authorize]
        public IActionResult AddVehicle()
        {
            var viewModel = new AddVehicleInputModel();
            viewModel.MakesItems = this.makeService.GetAllMakes();
            viewModel.Colors = this.colorService.GetAllColors();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddVehicle(AddVehicleInputModel model)
        {
            return this.Json(model);
        }
    }
}

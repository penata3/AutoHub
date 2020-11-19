namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Vehicles;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    public class VehiclesController : Controller
    {
        private readonly ICategoriesService categoryService;
        private readonly IMakeService makeService;
        private readonly IColorService colorService;

        public VehiclesController(
            ICategoriesService categoryService,
            IMakeService makeService,
            IColorService colorService)
        {
            this.categoryService = categoryService;
            this.makeService = makeService;
            this.colorService = colorService;
        }

        public IActionResult AddVehicle()
        {
            var viewModel = new AddVehicleInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllCategories();
            viewModel.MakesItems = this.makeService.GetAllMakes();
            viewModel.Colors = this.colorService.GetAllColors();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult AddVehicle(AddVehicleInputModel model)
        {
            return this.Json(model);
        }
    }
}

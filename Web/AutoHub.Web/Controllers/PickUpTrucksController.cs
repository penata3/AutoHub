namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class PickUpTrucksController : Controller
    {
        private readonly ICarsService carsService;

        public PickUpTrucksController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 8;
            const string coupeType = "Пикап";
            var carListViewModel = new CarsListViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                Cars = this.carsService.GetAllByCoupeType<CarInListViewModel>(id, ItemsPerPage, coupeType),
                ItemsCount = this.carsService.GetCounForCoupeType(coupeType),
            };
            return this.View(carListViewModel);
        }
    }
}

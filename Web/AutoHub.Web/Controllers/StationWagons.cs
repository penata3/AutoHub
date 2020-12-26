using AutoHub.Services.Data;
using AutoHub.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Web.Controllers
{
    public class StationWagons : Controller
    {
        private readonly ICarsService carsService;

        public StationWagons(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 8;
            const string coupeType = "Комби";
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

namespace AutoHub.Web.Controllers
{
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class MiniVansController : Controller
    {
        private readonly ICarsService carsService;

        public MiniVansController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 8;
            const string coupeType = "Миниван";
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

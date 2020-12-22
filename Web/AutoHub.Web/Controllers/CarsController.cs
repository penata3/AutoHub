namespace AutoHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        [Authorize]
        public async Task<IActionResult> AddCar()
        {
            var input = new AddCarInputModel();
            await this.carsService.AddAllSelectListValuesForCarInputModel(input);
            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCar(AddCarInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                await this.carsService.AddAllSelectListValuesForCarInputModel(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.carsService.CreateAsync(model, userId);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 8;

            var viewModel = new CarsListViewModel()
            {
                PageNumber = id,
                Cars = this.carsService.GetAllCars<CarInListViewModel>(id, ItemsPerPage),
                ItemsCount = this.carsService.GetCount(),
                ItemsPerPage = ItemsPerPage,
            };

            return this.View(viewModel);
        }
    }
}

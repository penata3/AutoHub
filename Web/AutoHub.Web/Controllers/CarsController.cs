namespace AutoHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoHub.Common;
    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IWebHostEnvironment environment;
        private readonly IMakeService makeService;

        public CarsController(
            ICarsService carsService,
            IWebHostEnvironment environment,
            IMakeService makeService)
        {
            this.carsService = carsService;
            this.environment = environment;
            this.makeService = makeService;
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
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var imagePath = this.environment.WebRootPath;
            await this.carsService.CreateAsync(model, userId, imagePath);

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
                ActionName = nameof(this.All),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var carModel = this.carsService.GetById<SingleCarViewModel>(id);
            return this.View(carModel);
        }

        public IActionResult AllByCoupeType(string data, int id = 1)
        {
            const int ItemsPerPage = 8;
            var coupeType = data;

            var carListViewModel = new CarsListViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                Cars = this.carsService.GetAllByCoupeType<CarInListViewModel>(id, ItemsPerPage, coupeType),
                ItemsCount = this.carsService.GetCounForCoupeType(data),
            };
            return this.View(carListViewModel);
        }

        public IActionResult AllByFuelType(string data, int id = 1)
        {
            const int ItemsPerPage = 8;

            var fuelType = data;

            var carListViewModel = new CarsListViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                Cars = this.carsService.GetAllByFuelType<CarInListViewModel>(id, ItemsPerPage, fuelType),
                ItemsCount = this.carsService.GetCountForFuelType(data),
            };
            return this.View(carListViewModel);
        }

        public IActionResult AllByMakeName(string data, int id = 1)
        {
            const int ItemsPerPage = 8;
            var makeName = data;

            var viewModel = new CarsListViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                Cars = this.carsService.GetAllByMakeName<CarInListViewModel>(id, ItemsPerPage, makeName),
                ItemsCount = this.carsService.GetCountForCarsPerMake(makeName),
            };

            return this.View(viewModel);
        }

        [Authorize]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id)
         {
            var model = this.carsService.GetById<EditCarInputModel>(id);
            await this.carsService.AddAllSelectListValuesForCarEditInputModel(model);
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditCarInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                await this.carsService.AddAllSelectListValuesForCarEditInputModel(model);
                return this.View(model);
            }

            await this.carsService.UpdateAsync(id, model);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.carsService.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        [Authorize]
        public IActionResult ContactUs()
        {
            return this.View();
        }
    }
}

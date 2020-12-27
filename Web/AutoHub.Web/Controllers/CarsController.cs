﻿namespace AutoHub.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IWebHostEnvironment environment;

        public CarsController(
            ICarsService carsService,
            IWebHostEnvironment environment)
        {
            this.carsService = carsService;
            this.environment = environment;
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
            var imagePath = this.environment.WebRootPath;
            await this.carsService.CreateAsync(model, userId, imagePath);

            return this.RedirectToAction("ThankYou");

            //return this.Json(model.Additions.Where(x => x.IsCheked == true));
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
    }
}
    
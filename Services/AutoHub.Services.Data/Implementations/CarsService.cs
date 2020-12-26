namespace AutoHub.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoHub.Web.ViewModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly IModelsService modelsService;
        private readonly IMakeService makeService;
        private readonly IColorService colorService;
        private readonly ICoupesService coupesService;
        private readonly IConditionsService conditionsService;
        private readonly IGearBoxesService gearBoxesService;
        private readonly IRegionsServices regionsServices;
        private readonly IFuelsServices fuelsServices;
        private readonly IAdditionsService additionsService;
        private readonly ITonwsService tonwsService;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IDeletableEntityRepository<Addition> additionsRepository;

        public CarsService(
            IModelsService modelsService,
            IMakeService makeService,
            IColorService colorService,
            ICoupesService coupesService,
            IConditionsService conditionsService,
            IGearBoxesService gearBoxesService,
            IRegionsServices regionsServices,
            IFuelsServices fuelsServices,
            IAdditionsService additionsService,
            ITonwsService tonwsService,
            IDeletableEntityRepository<Car> carsRepository,
            IDeletableEntityRepository<Addition> additionsRepository)
        {
            this.modelsService = modelsService;
            this.makeService = makeService;
            this.colorService = colorService;
            this.coupesService = coupesService;
            this.conditionsService = conditionsService;
            this.gearBoxesService = gearBoxesService;
            this.regionsServices = regionsServices;
            this.fuelsServices = fuelsServices;
            this.additionsService = additionsService;
            this.tonwsService = tonwsService;
            this.carsRepository = carsRepository;
            this.additionsRepository = additionsRepository;
        }

        public async Task AddAllSelectListValuesForCarInputModel(AddCarInputModel input)
        {
            input.MakesItems = this.makeService.GetAllMakes();
            input.Colors = this.colorService.GetAllColors();
            input.CoupeTypes = this.coupesService.GetAllCoupes();
            input.Conditions = await this.conditionsService.GetAllConditionsAsync();
            input.GearBoxes = await this.gearBoxesService.GetAllGearBoxesAsync();
            input.Regions = await this.regionsServices.GetAllRegionsAsync();
            input.Fuels = await this.fuelsServices.GetAllFuelTypesAsync();
            input.Additions = this.additionsService.GetAllAditions();
        }

        public async Task CreateAsync(AddCarInputModel input, string userId, string imagePath)
        {
            var car = new Car()
            {
                Title = input.Title,
                ConditionId = input.ConditionId,
                MakeId = input.MakeId,
            };

            if (this.modelsService.GetModelByName(input.ModelAsString) == null)
            {
                await this.modelsService.CreateModel(input.ModelAsString, input.MakeId);
            }

            car.ModelId = this.modelsService.GetModelByName(input.ModelAsString).Id;

            car.CoupeId = input.CoupeId;
            car.Milage = input.Milage;
            car.ManufactureDate = DateTime.Parse("Jan 1, " + input.ManufactureDate);
            car.ColorId = input.ColorId;
            car.Price = input.Price;
            car.RegionId = input.RegionId;

            if (this.tonwsService.GetTownByNameAndRegionId(input.TownAsString, input.RegionId) == null)
            {
                await this.tonwsService.Create(input.TownAsString, input.RegionId);
            }

            car.TownId = this.tonwsService.GetTownByNameAndRegionId(input.TownAsString, input.RegionId).Id;
            car.TechDataUrl = input.TechDataUrl;
            car.FuelId = input.FuelId;
            car.GearBoxId = input.GearBoxId;
            car.Description = input.Description;
            car.AddedByUserId = userId;

            Directory.CreateDirectory($"{imagePath}/cars/");

            foreach (var img in input.Images)
            {
                var extension = Path.GetExtension(img.FileName).TrimStart('.');

                var dbImage = new Image()
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };

                car.Images.Add(dbImage);

                var path = $"{imagePath}/cars/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(path, FileMode.Create);
                await img.CopyToAsync(fileStream);
            }

            foreach (var add in input.Additions)
            {
                var addition = this.additionsRepository.AllAsNoTracking().FirstOrDefault(a => a.Id == add.Id);

                if (add.IsCheked)
                {
                    car.Additions.Add(new CarAddition()
                    {
                        AdditionId = addition.Id,
                    });
                }
              
            }

            await this.carsRepository.AddAsync(car);
            await this.carsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllCars<T>(int page, int itemsPerPage = 10)
        {
            return this.carsRepository.AllAsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                 .To<T>()
                 .ToList();
        }

        public T GetById<T>(int id)
        {
            var car = this.carsRepository.AllAsNoTracking().Where(c => c.Id == id)
                .To<T>()
                .FirstOrDefault();

            return car;
        }

        public int GetCount()
        {
            return this.carsRepository.AllAsNoTracking().Count();
        }
    }
}

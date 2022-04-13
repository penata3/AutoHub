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
    using AutoHub.Web.ViewModels.Search;

    public class CarsService : ICarsService
    {
        private readonly IMakeService makeService;
        private readonly IColorService colorService;
        private readonly ICoupesService coupesService;
        private readonly IConditionsService conditionsService;
        private readonly IGearBoxesService gearBoxesService;
        private readonly IRegionsServices regionsServices;
        private readonly IFuelsServices fuelsServices;
        private readonly IAdditionsService additionsService;
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
            this.makeService = makeService;
            this.colorService = colorService;
            this.coupesService = coupesService;
            this.conditionsService = conditionsService;
            this.gearBoxesService = gearBoxesService;
            this.regionsServices = regionsServices;
            this.fuelsServices = fuelsServices;
            this.additionsService = additionsService;
            this.carsRepository = carsRepository;
            this.additionsRepository = additionsRepository;
        }

        public async Task AddAllSelectListValuesForCarInputModel(AddCarInputModel input)
        {
            input.MakesItems = await this.makeService.GetAllMakes();
            input.Colors = await this.colorService.GetAllColors();
            input.CoupeTypes = await this.coupesService.GetAllCoupes();
            input.Conditions = await this.conditionsService.GetAllConditionsAsync();
            input.GearBoxes = await this.gearBoxesService.GetAllGearBoxesAsync();
            input.Regions = await this.regionsServices.GetAllRegionsAsync();
            input.Fuels = await this.fuelsServices.GetAllFuelTypesAsync();
            input.Additions = this.additionsService.GetAllAditions();
        }

        // TODO: REFACTOR

        public async Task AddAllSelectListValuesForCarEditInputModel(EditCarInputModel input)
        {
            input.MakesItems = await this.makeService.GetAllMakes();
            input.Colors = await this.colorService.GetAllColors();
            input.CoupeTypes = await this.coupesService.GetAllCoupes();
            input.Conditions = await this.conditionsService.GetAllConditionsAsync();
            input.GearBoxes = await this.gearBoxesService.GetAllGearBoxesAsync();
            input.Regions = await this.regionsServices.GetAllRegionsAsync();
            input.Fuels = await this.fuelsServices.GetAllFuelTypesAsync();

            // input.Additions = this.additionsService.GetAllAditions();
        }

        public async Task CreateAsync(AddCarInputModel input, string userId, string imagePath)
        {
            var car = new Car()
            {
                Title = input.Title,
                ConditionId = input.ConditionId,
                MakeId = input.MakeId,
                ModelId = input.ModelId,
                CoupeId = input.CoupeId,
                Milage = input.Milage,
                ManufactureDate = input.ManufactureDate,
                ColorId = input.ColorId,
                Price = input.Price,
                RegionId = input.RegionId,
                TownId = input.TownId,
                TechDataUrl = input.TechDataUrl,
                FuelId = input.FuelId,
                GearBoxId = input.GearBoxId,
                Description = input.Description,
                AddedByUserId = userId,
                HorsePower = input.HorsePower,
            };

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

        public IEnumerable<T> GetAllByCoupeType<T>(int page, int itemsPerPage, string coupeType)
        {
            return this.carsRepository.AllAsNoTracking()
                .Where(x => x.Coupe.Name == coupeType)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllByFuelType<T>(int page, int itemsPerPage, string fuelType)
        {
            return this.carsRepository.AllAsNoTracking()
                .Where(x => x.Fuel.Name == fuelType)
                 .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                 .To<T>()
                 .ToList();
        }

        public IEnumerable<T> GetAllByMakeName<T>(int page, int itemsPerPage, string makeName)
        {
            return this.carsRepository.AllAsNoTracking()
                .Where(x => x.Make.Name == makeName)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllCars<T>(int page, int itemsPerPage)
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

        public int GetCounForCoupeType(string coupeType)
        {
            return this.carsRepository.AllAsNoTracking().Where(x => x.Coupe.Name == coupeType).Count();
        }

        public int GetCount()
        {
            return this.carsRepository.AllAsNoTracking().Count();
        }

        public int GetCountForCarsPerMake(string makeName)
        {
            return this.carsRepository.AllAsNoTracking().Where(x => x.Make.Name == makeName).Count();
        }

        public int GetCountForFuelType(string fuelType)
        {
            return this.carsRepository.AllAsNoTracking().Where(x => x.Fuel.Name == fuelType).Count();
        }

        public async Task UpdateAsync(int id, EditCarInputModel model)
        {
            var car = this.carsRepository.All().FirstOrDefault(c => c.Id == id);

            car.Title = model.Title;
            car.Price = model.Price;
            car.Milage = model.Milage;
            car.ManufactureDate = model.ManufactureDate;
            car.MakeId = model.MakeId;
            car.ModelId = model.ModelId;
            car.Description = model.Description;
            car.ColorId = model.ColorId;
            car.CoupeId = model.CoupeId;
            car.TechDataUrl = model.TechDataUrl;
            car.ConditionId = model.ConditionId;
            car.GearBoxId = model.GearBoxId;
            car.RegionId = model.RegionId;
            car.TownId = model.TownId;
            car.FuelId = model.FuelId;
            car.HorsePower = model.HorsePower;

            await this.carsRepository.SaveChangesAsync();


            //Color,coupe,techData,ConditionId,GearBoxId,RegionId,TownId,FuelId,HorsePower,
        }

        public void IncreaseView(int id)
        {

            var carToUpdate = this.carsRepository.All().Where(c => c.Id == id).FirstOrDefault();
            carToUpdate.Views++;

            this.carsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetLatestFiveCars<T>()
        {
            return this.carsRepository.All()
                 .OrderByDescending(x => x.CreatedOn)
                 .Take(5)
                 .To<T>()
                 .ToList();
        }

        public async Task Delete(int id)
        {
            var car = this.carsRepository.AllAsNoTracking().Where(x => x.Id == id)
                  .FirstOrDefault();

            this.carsRepository.Delete(car);
            await this.carsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllByAdditions<T>(IEnumerable<int> aditionsIds)
        {
            var query = this.carsRepository.All().AsQueryable();

            foreach (var aditionId in aditionsIds)
            {
                query = query.Where(x => x.Additions.Any(i => i.AdditionId == aditionId));
            }

            return query.To<T>().ToList();
        }

        public Task AddSelectListValuesForCarCreateOrEditModel<T>(T input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetCarsFromPriceDescending<T>(int page, int itemsPerPage)
        {
            return this.carsRepository.AllAsNoTracking()
               .OrderByDescending(x => x.Price)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>()
               .ToList();
        }

        public IEnumerable<T> GetCarsFromPriceAscenging<T>(int page, int itemsPerPage)
        {
            return this.carsRepository.AllAsNoTracking()
               .OrderBy(x => x.Price)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>()
               .ToList();
        }

        public IEnumerable<T> GetAllCarsFromLatest<T>(int page, int itemsPerPage)
        {
            return this.carsRepository.AllAsNoTracking()
          .OrderBy(x => x.CreatedOn)
          .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
          .To<T>()
          .ToList();
        }

        public IEnumerable<T> GetAllCarsFromOldest<T>(int page, int itemsPerPage)
        {
            return this.carsRepository.AllAsNoTracking()
           .OrderByDescending(x => x.CreatedOn)
           .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
           .To<T>()
           .ToList();
        }

        public async Task AddSelectListValuesForAdvancedSearchModel(AdvancedSearchViewModel input)
        {
            input.MakesItems = await this.makeService.GetAllMakes();
            input.Colors = await this.colorService.GetAllColors();
            input.GearBoxes = await this.gearBoxesService.GetAllGearBoxesAsync();
            input.Regions = await this.regionsServices.GetAllRegionsAsync();
            input.Fuels = await this.fuelsServices.GetAllFuelTypesAsync();
        }

        public IEnumerable<T> GetAllBySearchingCriteria<T>(AdvancedSearchViewModel model)
        {
            //var query = this.carsRepository.All().AsQueryable();

            //query = query.Where(x => x.ModelId == model.ModelId && x.MakeId == model.ModelId
            //&& x.ColorId == model.ColourId
            //&& x.RegionId == model.RegionId
            //&& x.FuelId == model.FuelId
            //&& x.GearBoxId == model.GearBoxId);

            //return query.To<T>().ToList();

            return this.carsRepository.AllAsNoTracking().Where(x => x.ModelId == model.ModelId || x.MakeId == model.MakeId
           || x.ColorId == model.ColourId
            || x.RegionId == model.RegionId
            || x.FuelId == model.FuelId
           || x.GearBoxId == model.GearBoxId).To<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllBySearchOptions<T>(AdvancedSearchViewModel model)
        {
            //var query = this.carsRepository.All().AsQueryable();

            //foreach (var aditionId in aditionsIds)
            //{
            //    query = query.Where(x => x.Additions.Any(i => i.AdditionId == aditionId));
            //}

            //return query.To<T>().ToList();

            var query = this.carsRepository.All().AsQueryable();

            if (model.MakeId != 0)
            {
                query = query
                .Where(x => x.MakeId == model.MakeId);
            }

            if (model.ModelId != 0)
            {
                query = query
                  .Where(x => x.ModelId == model.ModelId);
            }
            if (model.ColourId != 0)
            {
                query = query
                .Where(x => x.ColorId == model.ColourId);
            }

            if (model.RegionId != 0)
            {
                query = query
                .Where(x => x.RegionId == model.RegionId);
            }

            if (model.FuelId != 0)
            {
                query = query
                .Where(x => x.FuelId == model.FuelId);
            }

            if (model.GearBoxId != 0)
            {
                query = query
                .Where(x => x.GearBoxId == model.GearBoxId);
            }

            return query.To<T>().ToList();
        }
    }
}

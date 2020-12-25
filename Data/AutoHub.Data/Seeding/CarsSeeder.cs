namespace AutoHub.Data.Seeding
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp.Text;
    using AutoHub.Data.Models;
    using AutoHub.Data.Seeding.Dto_s;
    using Newtonsoft.Json;

    public class CarsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cars.Any())
            {
                return;
            }

            var jsonAsString = File.ReadAllText(@"C:\Users\HP\OneDrive\Desktop\AutoHub\AutoHub\Data\AutoHub.Data\Seeding\JsonFiles\cars.json");

            var jsonData = JsonConvert.DeserializeObject<CarDto[]>(jsonAsString);

            foreach (var item in jsonData)
            {
                var car = new Car();

                car.Title = item.Title;
                car.OriginalUrl = item.OriginalUrl;

                if (dbContext.Makes.FirstOrDefault(x => x.Name == item.Make) == null)
                {
                    var make = new Make() { Name = item.Make };
                    await dbContext.Makes.AddAsync(make);
                    await dbContext.SaveChangesAsync();
                }

                car.MakeId = dbContext.Makes.FirstOrDefault(x => x.Name == item.Make).Id;

                if (dbContext.Models.FirstOrDefault(x => x.Name == item.Model) == null)
                {
                    var model = new Model()
                    {
                        Name = item.Model,
                        MakeId = dbContext.Makes.FirstOrDefault(x => x.Name == item.Make).Id,
                    };
                    await dbContext.Models.AddAsync(model);
                    await dbContext.SaveChangesAsync();
                }

                car.ModelId = dbContext.Models.FirstOrDefault(x => x.Name == item.Model).Id;

                car.Price = item.Price;
                car.ConditionId = dbContext.Conditions.FirstOrDefault(x => x.Name == item.Condition).Id;
                car.CoupeId = dbContext.Coupes.FirstOrDefault(x => x.Name == item.CoupeType).Id;

                car.ManufactureDate = DateTime.Parse("Jan 1, " + item.ManifactureDate);
                car.HorsePower = item.HorsePower;
                car.GearBoxId = dbContext.GearBoxes.FirstOrDefault(g => g.Name == item.GearBox).Id;

                if (dbContext.Colors.FirstOrDefault(c => c.Name == item.Color) == null)
                {
                    var color = new Color() { Name = item.Color };
                    await dbContext.Colors.AddAsync(color);
                    await dbContext.SaveChangesAsync();
                }

                car.ColorId = dbContext.Colors.FirstOrDefault(x => x.Name == item.Color).Id;
                car.Milage = item.Milage;
                car.Description = item.Description;
                car.TechDataUrl = item.TechDataUrl;
                car.FuelId = dbContext.Fuels.FirstOrDefault(x => x.Name == item.Fuel).Id;

                await dbContext.Cars.AddAsync(car);
                await dbContext.SaveChangesAsync();

                foreach (var add in item.Additions)
                {
                    var addition = dbContext.Additions.FirstOrDefault(a => a.Name == add);

                    var carAddition = new CarAddition()
                    {
                        AdditionId = addition.Id,
                        CarId = car.Id,
                    };
                    car.Additions.Add(carAddition);
                }

                var image = new Image()
                {
                    CarId = car.Id,
                    RemoteImageUrl = item.ImageUrl,
                };

                await dbContext.Images.AddAsync(image);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

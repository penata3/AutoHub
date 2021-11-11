namespace AutoHub.Web.ViewModels.Cars
{
    using System;
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoMapper;

    public class BasicCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string ImageUrl { get; set; }

        public string FuelName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string TownName { get; set; }

        public decimal Milage { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, BasicCarViewModel>()
             .ForMember(x => x.ImageUrl, opt =>
             opt.MapFrom(x =>
             x.Images.FirstOrDefault().RemoteImageUrl != null ?
             x.Images.FirstOrDefault().RemoteImageUrl :
             "/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}

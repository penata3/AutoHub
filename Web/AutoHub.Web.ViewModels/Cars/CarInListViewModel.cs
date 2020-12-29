namespace AutoHub.Web.ViewModels.Cars
{
    using System;
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoMapper;

    public class CarInListViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string ImageUrl { get; set; }

        public string FuelName { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarInListViewModel>()
            .ForMember(x => x.ImageUrl, opt =>
            opt.MapFrom(x =>
            x.Images.FirstOrDefault().RemoteImageUrl != null ?
            x.Images.FirstOrDefault().RemoteImageUrl :
            "/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
            .ForMember(x => x.Description, opt =>
            opt.MapFrom(x => x.Description.Substring(0, 50)));
        }
    }
}

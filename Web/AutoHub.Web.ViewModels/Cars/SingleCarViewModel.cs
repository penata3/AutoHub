namespace AutoHub.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoHub.Web.ViewModels.Additions;
    using AutoMapper;

    public class SingleCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string Price { get; set; }

        public string CoupeName { get; set; }

        public string ConditionName { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string AddedByUserEmail { get; set; }

        public string Description { get; set; }

        public string TechDataUrl { get; set; }

        public string RegionName { get; set; }

        public string TownName { get; set; }

        public int HorsePower { get; set; }

        public string FuelName { get; set; }

        public string OriginalUrl { get; set; }

        public string ImageUrl { get; set; }

        public string ColorName { get; set; }

        public string GearBoxName { get; set; }

        public decimal Milage { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<AdditionsForSingleCarViewModel> Additions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, SingleCarViewModel>()
            .ForMember(x => x.ImageUrl, opt =>
            opt.MapFrom(x =>
            x.Images.FirstOrDefault().RemoteImageUrl != null ?
            x.Images.FirstOrDefault().RemoteImageUrl :
            "/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}

namespace AutoHub.Web.ViewModels.Cars
{
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoMapper;

    public class SemiDetailedCarViewModel : BasicCarViewModel
    {
        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string ShortDescription { get; set; }

        public int HorsePower { get; set; }

        public override void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, SemiDetailedCarViewModel>()
            .ForMember(x => x.ImageUrl, opt =>
             opt.MapFrom(x =>
             x.Images.FirstOrDefault().RemoteImageUrl != null ?
             x.Images.FirstOrDefault().RemoteImageUrl :
             "/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
            .ForMember(x => x.ShortDescription, opt =>
            opt.MapFrom(x => x.Description.Substring(0, 100)));
        }
    }
}

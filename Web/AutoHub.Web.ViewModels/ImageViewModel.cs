namespace AutoHub.Web.ViewModels
{
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoHub.Web.ViewModels.Cars;
    using AutoMapper;

    public class ImageViewModel : IMapFrom<Image>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Image, ImageViewModel>()
            .ForMember(x => x.ImageUrl, opt =>
            opt.MapFrom(x =>
            x.RemoteImageUrl != null ?
            x.RemoteImageUrl :
            "/cars/" + x.Id + "." + x.Extension));
        }
    }
}

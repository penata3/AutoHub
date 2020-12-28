namespace AutoHub.Web.ViewModels.Reviews
{
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoMapper;

    public class ReviewInListViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VieoUrl { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Review, ReviewInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                x.Images.FirstOrDefault().RemoteImageUrl :
                 "/reviews/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));

        }
    }
}

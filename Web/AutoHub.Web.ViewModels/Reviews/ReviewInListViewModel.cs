namespace AutoHub.Web.ViewModels.Reviews
{
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoMapper;
    using AutoHub.Data.Models;
    using System.Linq;


    public class ReviewInListViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string VieoUrl { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Review, ReviewInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl));
        }
    }
}

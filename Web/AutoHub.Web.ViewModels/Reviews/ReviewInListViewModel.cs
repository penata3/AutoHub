namespace AutoHub.Web.ViewModels.Reviews
{
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoMapper;

    public class ReviewInListViewModel : ReviewWithoutDescriptionViewModel
    {
        public string Description { get; set; }

        public string SortDescription { get; set; }

        public override void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Review, ReviewInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                x.Images.FirstOrDefault().RemoteImageUrl :
                 "/reviews/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
                .ForMember(x => x.SortDescription, opt =>
                  opt.MapFrom(x => x.Description.Substring(0, 50) + "...."));
        }
    }
}

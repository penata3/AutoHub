namespace AutoHub.Web.ViewModels.Reviews
{
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;

    public class SingleReviewViewModel : IMapFrom<Review>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }
    }
}

namespace AutoHub.Web.ViewModels.Reviews
{
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using System;

    public class ReviewInListForAdminViewModel : IMapFrom<Review>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

    }
}

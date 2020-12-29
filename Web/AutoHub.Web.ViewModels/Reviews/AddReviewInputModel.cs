namespace AutoHub.Web.ViewModels.Reviews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class AddReviewInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Url]
        [Required]
        public string VideoUrl { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}

namespace AutoHub.Web.ViewModels.Reviews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class AddReviewInputModel
    {
        [Required]
        [MaxLength(5)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10)]
        public string Description { get; set; }

        [Url]
        [Required]
        public string VideoUrl { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}

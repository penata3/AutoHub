namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.Images = new HashSet<Image>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}

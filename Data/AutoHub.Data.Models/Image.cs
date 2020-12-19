namespace AutoHub.Data.Models
{
    using System;

    using AutoHub.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int? CarId { get; set; }

        public virtual Car Car { get; set; }

        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}

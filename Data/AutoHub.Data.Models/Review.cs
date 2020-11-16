namespace AutoHub.Data.Models
{
    using AutoHub.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

    }
}

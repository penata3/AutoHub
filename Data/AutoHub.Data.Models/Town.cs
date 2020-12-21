namespace AutoHub.Data.Models
{
    using AutoHub.Data.Common.Models;

    public class Town : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}

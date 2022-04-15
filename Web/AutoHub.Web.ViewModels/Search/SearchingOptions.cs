namespace AutoHub.Web.ViewModels.Search
{
    using System.ComponentModel.DataAnnotations;

    public class SearchingOptions
    {
        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public int? FuelId { get; set; }

        public int? GearBoxId { get; set; }

        public int? ColourId { get; set; }

        public int? RegionId { get; set; }
    }
}

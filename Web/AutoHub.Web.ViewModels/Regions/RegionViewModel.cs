namespace AutoHub.Web.ViewModels.Regions
{
    using System.Collections.Generic;

    public class RegionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TownViewModel> Towns { get; set; }
    }
}

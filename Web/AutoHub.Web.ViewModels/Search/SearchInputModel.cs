namespace AutoHub.Web.ViewModels.Search
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoHub.Web.ViewModels.Additions;

    public class SearchInputModel
    {
        [Display(Name = "Make")]
        public int MakeId { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public int FuelId { get; set; }

        public int GearBoxId { get; set; }

        public int ColourId { get; set; }

        public int RegionId { get; set; }

        public AdditionViewModel[] Additions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Fuels { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearBoxes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Colors { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }
    }
}

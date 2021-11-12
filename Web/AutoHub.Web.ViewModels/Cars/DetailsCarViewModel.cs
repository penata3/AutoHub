namespace AutoHub.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoHub.Data.Models;
    using AutoHub.Web.ViewModels.Additions;
    using AutoMapper;

    public class DetailsCarViewModel : SemiDetailedCarViewModel
    {
        public string CoupeName { get; set; }

        public string ConditionName { get; set; }

        public string AddedByUserEmail { get; set; }

        public string Description { get; set; }

        public string TechDataUrl { get; set; }

        public string RegionName { get; set; }

        public string OriginalUrl { get; set; }

        public string ColorName { get; set; }

        public string GearBoxName { get; set; }

        public int Views { get; set; }

        public string AddedByUserId { get; set; }

        public double AverageVote { get; set; }

        public ImageViewModel[] Images { get; set; }

        public IEnumerable<AdditionsForSingleCarViewModel> Additions { get; set; }

        //public override void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Car, DetailsCarViewModel>()
        //       .ForMember(x => x.AverageVote, opt =>
        //       opt.MapFrom(x => x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value)));
        //    base.CreateMappings(configuration);
        //}
    }
}

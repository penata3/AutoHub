namespace AutoHub.Web.ViewModels.Additions
{
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;

    public class AdditionsForSingleCarViewModel : IMapFrom<CarAddition>
    {
        public string AdditionName { get; set; }
    }
}

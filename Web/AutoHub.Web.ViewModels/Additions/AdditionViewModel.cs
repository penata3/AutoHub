namespace AutoHub.Web.ViewModels.Additions
{
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;

    public class AdditionViewModel : IMapFrom<Addition>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCheked { get; set; }
    }
}

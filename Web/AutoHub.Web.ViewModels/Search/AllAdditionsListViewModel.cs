namespace AutoHub.Web.ViewModels.Search
{
    using AutoHub.Web.ViewModels.Additions;
    using System.Collections.Generic;

    public class AllAdditionsListViewModel
    {
        public IEnumerable<AdditionViewModel> Additions { get; set; }
    }
}

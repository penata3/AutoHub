namespace AutoHub.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AutoHub.Web.ViewModels.Cars;

    public class LatestCarsList
    {
        public IEnumerable<BasicCarViewModel> Cars { get; set; }
    }
}

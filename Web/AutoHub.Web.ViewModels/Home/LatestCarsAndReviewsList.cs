namespace AutoHub.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Reviews;

    public class LatestCarsAndReviewsList : PaginationViewModel
    {
        public IEnumerable<CarInListViewModel> Cars { get; set; }

        public IEnumerable<ReviewInListViewModel> Reviews { get; set; }
    }
}

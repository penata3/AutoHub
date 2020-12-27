namespace AutoHub.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class ReviewListViewModel : PaginationViewModel
    {
        public IEnumerable<ReviewInListViewModel> Reviews { get; set; }
    }
}

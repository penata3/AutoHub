namespace AutoHub.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class ReviewListForAdminViewModel : PaginationViewModel
    {
        public IEnumerable<ReviewInListForAdminViewModel> Reviews { get; set; }
    }
}

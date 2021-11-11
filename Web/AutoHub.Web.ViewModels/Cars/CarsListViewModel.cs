namespace AutoHub.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class CarsListViewModel : PaginationViewModel
    {
        public IEnumerable<SemiDetailedCarViewModel> Cars { get; set; }
    }
}

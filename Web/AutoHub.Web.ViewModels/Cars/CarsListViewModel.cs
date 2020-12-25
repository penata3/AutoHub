namespace AutoHub.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class CarsListViewModel : PaginationViewModel
    {
        public IEnumerable<CarInListViewModel> Cars { get; set; }
    }
}

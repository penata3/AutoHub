namespace AutoHub.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class CarListingViewModel
    {
       public IEnumerable<SemiDetailedCarViewModel> Cars { get; set; }
    }
}

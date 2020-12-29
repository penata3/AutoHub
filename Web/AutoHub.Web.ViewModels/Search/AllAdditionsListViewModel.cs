using AutoHub.Web.ViewModels.Additions;
using System.Collections.Generic;

namespace AutoHub.Web.ViewModels.Search
{
   public class AllAdditionsListViewModel
    {
        public IEnumerable<AdditionViewModel> Additions { get; set; }
    }
}

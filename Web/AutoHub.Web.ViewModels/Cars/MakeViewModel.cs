namespace AutoHub.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class MakeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ModelViewModel> Models { get; set; }
    }
}

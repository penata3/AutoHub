namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

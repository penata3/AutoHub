namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class Fuel : BaseDeletableModel<int>
    {
        public Fuel()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}

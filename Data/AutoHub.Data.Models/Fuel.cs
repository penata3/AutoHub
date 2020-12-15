namespace AutoHub.Data.Models
{
    using AutoHub.Data.Common.Models;
    using System.Collections.Generic;


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

namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class DealerShip : BaseDeletableModel<int>
    {
        public DealerShip()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Location { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}

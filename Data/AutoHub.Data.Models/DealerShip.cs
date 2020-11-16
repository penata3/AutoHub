namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class DealerShip : BaseDeletableModel<int>
    {
        public DealerShip()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

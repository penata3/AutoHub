namespace AutoHub.Data.Models
{
    using System;
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;
    using AutoHub.Data.Models.Enums;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Images = new HashSet<Image>();
            this.Additions = new HashSet<CarAddition>();
        }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int Price { get; set; }

        public int CoupeId { get; set; }

        public virtual Coupe Coupe { get; set; }

        public int GearBoxId { get; set; }

        public virtual GearBox GearBox { get; set; }

        public decimal Milage { get; set; }

        public CarCondition Condition { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int? DealerShipId { get; set; }

        public virtual DealerShip DealerShip { get; set; }

        public int? RegionId { get; set; }

        public virtual Region Region { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

        public int FuelId { get; set; }

        public virtual Fuel Fuel { get; set; }

        public virtual IEnumerable<CarAddition> Additions { get; set; }
    }
}

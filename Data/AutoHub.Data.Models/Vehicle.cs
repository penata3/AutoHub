namespace AutoHub.Data.Models
{
    using System;

    using AutoHub.Data.Common.Models;
    using AutoHub.Data.Models.Enums;

    public class Vehicle : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int Price { get; set; }

        public CoupeType Type { get; set; }

        public GearBox GearBox { get; set; }

        public decimal Milage { get; set; }

        public Condition Condition { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int? DealerShipId { get; set; }

        public virtual DealerShip DealerShip { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

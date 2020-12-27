namespace AutoHub.Data.Models
{
    using System;
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Images = new HashSet<Image>();
            this.Additions = new HashSet<CarAddition>();
            this.Votes = new HashSet<Vote>();
        }

        public string Title { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }
        
        public int Price { get; set; }

        public int CoupeId { get; set; }

        public virtual Coupe Coupe { get; set; }

        public int GearBoxId { get; set; }

        public virtual GearBox GearBox { get; set; }

        public decimal Milage { get; set; }

        public int ConditionId { get; set; }

        public virtual Condition Condition { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public string TechDataUrl { get; set; }

        public int? DealerShipId { get; set; }

        public virtual DealerShip DealerShip { get; set; }

        public int? RegionId { get; set; }

        public virtual Region Region { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public int HorsePower { get; set; }

        public int FuelId { get; set; }

        public virtual Fuel Fuel { get; set; }

        public string OriginalUrl { get; set; }

        public virtual ICollection<CarAddition> Additions { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public int Views { get; set; }
    }
}

namespace AutoHub.Web.ViewModels.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoHub.Data.Models.Enums;

    public class AddVehicleInputModel
    {
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        [Required]
        public int Price { get; set; }

        public CoupeType Type { get; set; }

        public GearBox GearBox { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal Milage { get; set; }

        public Condition Condition { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime ManufactureDate { get; set; }

        public int MakeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public int? DealerShipId { get; set; }

        public int ColorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Colors { get; set; }
    }
}



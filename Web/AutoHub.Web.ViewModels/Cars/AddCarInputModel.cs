namespace AutoHub.Web.ViewModels.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddCarInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal Milage { get; set; }

        [Required]
        public string ManufactureDate { get; set; }

        public int MakeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }

        [Required]
        public string ModelAsString { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public int ColorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Colors { get; set; }

        public int CoupeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CoupeTypes { get; set; }

        public string TechDataUrl { get; set; }

        public int ConditionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Conditions { get; set; }

        public int GearBoxId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearBoxes { get; set; }

        public int RegionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public int FuelId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Fuels { get; set; }
    }
}

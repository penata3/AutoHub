﻿namespace AutoHub.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;

    public class EditCarInputModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal Milage { get; set; }

        [Display(Name = "Year of manifacture")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }

        [Display(Name = "Make")]
        public int MakeId { get; set; }

        [Required]
        [Display(Name = "Model")]
        public int ModelId { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Display(Name = "Color")]
        public int ColorId { get; set; }

        [Display(Name = "Coupe Type")]
        public int CoupeId { get; set; }

        [System.ComponentModel.DataAnnotations.Url]
        public string TechDataUrl { get; set; }

        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public int GearBoxId { get; set; }

        [Display(Name = "Region")]
        [Required]
        public int RegionId { get; set; }

        [Display(Name = "Town")]
        [Required]
        public int TownId { get; set; }

        [Display(Name = "Fuel Type")]
        [Required]
        public int FuelId { get; set; }

        [Required]
        [Display(Name = "Horse Power")]
        public int HorsePower { get; set; }

        //public int AdditionId { get; set; }

        //public AdditionViewModel[] Additions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Fuels { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearBoxes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Conditions { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CoupeTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Colors { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }
    }
}

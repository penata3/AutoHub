﻿namespace AutoHub.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoHub.Data.Models;

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

        [Display(Name = "Year of manifacture")]
        public string ManufactureDate { get; set; }


        [Display(Name = "Make")]
        public int MakeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string ModelAsString { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Color")]
        public int ColorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Colors { get; set; }

        [Display(Name = "Coupe Type")]
        public int CoupeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CoupeTypes { get; set; }

        public string TechDataUrl { get; set; }

        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Conditions { get; set; }

        public int GearBoxId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearBoxes { get; set; }

        [Display(Name = "Region")]
        public int RegionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Town Name")]
        public string TownAsString { get; set; }

        [Display(Name = "Fuel Type")]
        public int FuelId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Fuels { get; set; }

        public int AdditionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Additions { get; set; }
    }
}

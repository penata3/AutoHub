namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class YearValidatorAttribute : ValidationAttribute
    {

        private DateTime lowestDatePossible = new DateTime(1990, 1, 1);
        private DateTime latestDatePossible = DateTime.UtcNow;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var dateValue = value as DateTime? ?? new DateTime();

            if (dateValue < this.lowestDatePossible || dateValue > this.latestDatePossible) 
            {
                return new ValidationResult($"Manifacture date should be between 1990 and {this.latestDatePossible.Year}");
            }

            return ValidationResult.Success;
        }
    }
}

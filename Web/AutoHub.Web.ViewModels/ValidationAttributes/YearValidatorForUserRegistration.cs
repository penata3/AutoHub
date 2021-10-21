namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class YearValidatorForUserRegistration : ValidationAttribute
    {
        private readonly int minimumAge;
        private readonly DateTime minumumYearOfBirth;

        public YearValidatorForUserRegistration(int minimumAge)
        {
            this.minimumAge = minimumAge;
            this.minumumYearOfBirth = new DateTime(1900, 1, 1);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;

            if (DateTime.TryParse(value.ToString(), out date))
            {
                if (date < this.minumumYearOfBirth)
                {
                    return new ValidationResult("Are you seriousli that old?");
                }

                if (date.AddYears(this.minimumAge) <= DateTime.Now)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"Users under {this.minimumAge} are not allowed!");
            }

            return new ValidationResult("Invalid date format");
        }
    }
}

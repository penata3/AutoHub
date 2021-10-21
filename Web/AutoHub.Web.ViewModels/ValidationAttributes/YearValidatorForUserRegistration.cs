namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class YearValidatorForUserRegistration : ValidationAttribute
    {
        private readonly int minimumAge;
        private readonly DateTime minimumAllowedYearOfBirth = new DateTime(1990, 1, 1);

        public YearValidatorForUserRegistration(int minimumAge)
        {
            this.minimumAge = minimumAge;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                if (date < this.minimumAllowedYearOfBirth)
                {
                    return new ValidationResult("I think you are too old to sell a car mate");
                }
                else if (date.AddYears(this.minimumAge) <= DateTime.Now)
                {
                    return ValidationResult.Success;
                }

                else if (date.AddYears(this.minimumAge) > DateTime.Now)
                {
                    return new ValidationResult("You are not even born mate");
                }
                
            }

            return new ValidationResult("You are too young to register in or sitee");
            
        }

     
    }
}

namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class UrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Url is required");
            }

            Regex regex = new Regex(@"(http://)?(www\.)?\w+\.(com|net|edu|org)");

            if (!regex.IsMatch(value.ToString()))
            {
                return new ValidationResult("This is not valid ulr");
            }

            return ValidationResult.Success;

        }
    }
}

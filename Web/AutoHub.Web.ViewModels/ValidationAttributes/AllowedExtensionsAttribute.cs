namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions = new[] { ".jpg", ".png" };

        public string GetErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as IEnumerable<IFormFile>;

            foreach (var file in files)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!this.extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(this.GetErrorMessage());
                    }
                }
            }

            return ValidationResult.Success;
        }

    }
}

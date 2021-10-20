namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class FormFileValidatorAttribute : ValidationAttribute
    {
        private readonly string[] extensions = new[] { ".jpg", ".png" };
        private readonly int maxFileSize = 5 * 1024 * 1024;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as IEnumerable<IFormFile>;

            if (files == null)
            {
               return new ValidationResult("At least one image is required!");
            }

            foreach (var file in files)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var fileSize = file.Length;

                    if (fileSize > this.maxFileSize)
                    {
                        return new ValidationResult("File is too big");
                    }

                    if (!this.extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult("This photo extension is not allowed!");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}

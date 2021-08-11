namespace AutoHub.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UrlAttribute : ValidationAttribute
    {
        public UrlAttribute() { }

        public override bool IsValid(object value)
        {
            //may want more here for https, etc
            Regex regex = new Regex(@"(http://)?(www\.)?\w+\.(com|net|edu|org)");

            if (value == null)
            {
                return false;
            }

            if (!regex.IsMatch(value.ToString())) 
            {
                return false;
            }

            return true;
        }
    }
}

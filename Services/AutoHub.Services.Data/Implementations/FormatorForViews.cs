namespace AutoHub.Services.Data.Implementations
{
    public class FormatorForViews : IFormatorForViews
    {
        public string FormatDecimalNumberForDisplay(decimal number)
        {
            var numberAsInt = decimal.ToInt32(number);
            return this.FormatIntegerForDisplay(numberAsInt);
        }

        public string FormatIntegerForDisplay(int price)
        {
            var priceAsString = price.ToString();

            string result = string.Empty;

            if (priceAsString.Length == 4)
            {
                result = $"{priceAsString.Substring(0, 1)}  {priceAsString.Substring(1, 3)}";
            }
            else if (priceAsString.Length == 5)
            {
                result = $"{priceAsString.Substring(0, 2)}  {priceAsString.Substring(1, 3)}";
            }
            else if (priceAsString.Length == 6)
            {
                result = $"{priceAsString.Substring(0, 3)}  {priceAsString.Substring(1, 3)}";
            }
            else if (priceAsString.Length == 7)
            {
                result = $"{priceAsString.Substring(0, 1)}  {priceAsString.Substring(1, 3)}  {priceAsString.Substring(5, 3)}";
            }
            else
            {
                result = priceAsString;
            }

            return result;
        }
    }
}

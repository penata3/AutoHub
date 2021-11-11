namespace AutoHub.Services.Data
{
    public interface IFormatorForViews
    {
        string FormatIntegerForDisplay(int price);

        string FormatDecimalNumberForDisplay(decimal number);
    }
}

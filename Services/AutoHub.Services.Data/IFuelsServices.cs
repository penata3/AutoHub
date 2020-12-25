namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFuelsServices
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllFuelTypesAsync();
    }
}

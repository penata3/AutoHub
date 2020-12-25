namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IConditionsService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllConditionsAsync();
    }
}

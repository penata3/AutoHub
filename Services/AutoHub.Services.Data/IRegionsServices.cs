namespace AutoHub.Services.Data
{
    using System.Collections.Generic;

    using System.Threading.Tasks;

    public interface IRegionsServices
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegionsAsync();
    }
}

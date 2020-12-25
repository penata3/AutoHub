namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGearBoxesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllGearBoxesAsync();
    }
}

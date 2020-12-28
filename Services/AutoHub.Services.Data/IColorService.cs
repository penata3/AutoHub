namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IColorService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllColors();
    }
}

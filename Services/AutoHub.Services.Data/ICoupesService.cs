namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICoupesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllCoupes();
    }
}

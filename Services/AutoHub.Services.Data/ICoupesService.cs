namespace AutoHub.Services.Data
{
    using System.Collections.Generic;

    public interface ICoupesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllCoupes();
    }
}

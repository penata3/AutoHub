namespace AutoHub.Services.Data
{
    using System.Collections.Generic;

    public interface IMakeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllMakes();
    }
}

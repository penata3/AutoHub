namespace AutoHub.Services.Data
{
    using System.Collections.Generic;

    public interface IColorService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllColors();
    }
}

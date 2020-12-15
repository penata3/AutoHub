namespace AutoHub.Services.Data
{
    using System.Collections.Generic;

    public interface IModelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllModels();

    }
}

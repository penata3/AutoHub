namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;

    public interface IModelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllModels();

        Model GetModelByName(string name);

        Task CreateModel(string name, int makeId);
    }
}

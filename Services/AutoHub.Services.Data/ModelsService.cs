namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class ModelsService : IModelsService
    {
        private readonly IDeletableEntityRepository<Model> modelsReposirtory;

        public ModelsService(IDeletableEntityRepository<Model> modelsReposirtory)
        {
            this.modelsReposirtory = modelsReposirtory;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllModels()
        {
            return this.modelsReposirtory.All().Select(m => new
            {
                m.Id,
                m.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

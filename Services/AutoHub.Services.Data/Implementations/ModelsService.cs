namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class ModelsService : IModelsService
    {
        private readonly IDeletableEntityRepository<Model> modelsReposirtory;

        public ModelsService(IDeletableEntityRepository<Model> modelsReposirtory)
        {
            this.modelsReposirtory = modelsReposirtory;
        }

        public async Task CreateModel(string name, int makeId)
        {
            var model = new Model()
            {
                Name = name,
                MakeId = makeId,
            };

            await this.modelsReposirtory.AddAsync(model);
            await this.modelsReposirtory.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllModels()
        {
            return this.modelsReposirtory.AllAsNoTracking().Select(m => new
            {
                m.Id,
                m.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public Model GetModelByName(string name)
        {
            return this.modelsReposirtory.AllAsNoTracking().Where(m => m.Name == name).FirstOrDefault();
        }
    }
}

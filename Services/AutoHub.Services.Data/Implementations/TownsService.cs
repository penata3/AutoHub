namespace AutoHub.Services.Data.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class TownsService : ITonwsService
    {
        private readonly IDeletableEntityRepository<Town> townsRepository;

        public TownsService(IDeletableEntityRepository<Town> townsRepository)
        {
            this.townsRepository = townsRepository;
        }

        public async Task Create(string name, int regionId)
        {
            var town = new Town()
            {
                Name = name,
                RegionId = regionId,
            };

            await this.townsRepository.AddAsync(town);
            await this.townsRepository.SaveChangesAsync();

        }

        public Town GetTownByNameAndRegionId(string name, int regiondId)
        {
            return this.townsRepository.AllAsNoTracking().Where(t => t.Name == name && t.RegionId == regiondId).FirstOrDefault();
        }
    }
}

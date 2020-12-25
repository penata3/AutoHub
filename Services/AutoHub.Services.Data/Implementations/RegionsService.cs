namespace AutoHub.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RegionsService : IRegionsServices
    {
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public RegionsService(IDeletableEntityRepository<Region> regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegionsAsync()
        {
            var regions = new List<KeyValuePair<string, string>>();

            regions = await this.regionsRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .ToListAsync();

            return regions;
        }
    }
}

namespace AutoHub.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FuelsServices : IFuelsServices
    {
        private readonly IDeletableEntityRepository<Fuel> fuelsRepository;

        public FuelsServices(IDeletableEntityRepository<Fuel> fuelsRepository)
        {
            this.fuelsRepository = fuelsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllFuelTypesAsync()
        {
            var fuels = new List<KeyValuePair<string, string>>();

            fuels = await this.fuelsRepository.AllAsNoTracking()
                .Select(f => new KeyValuePair<string, string>(f.Id.ToString(), f.Name))
                .ToListAsync();

            return fuels;
        }
    }
}

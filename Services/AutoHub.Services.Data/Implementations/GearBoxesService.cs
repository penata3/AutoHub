namespace AutoHub.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GearBoxesService : IGearBoxesService
    {
        private readonly IDeletableEntityRepository<GearBox> gearBoxesRepository;

        public GearBoxesService(IDeletableEntityRepository<GearBox> gearBoxesRepository)
        {
            this.gearBoxesRepository = gearBoxesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllGearBoxesAsync()
        {
            var gearBoxes = new List<KeyValuePair<string, string>>();

            gearBoxes = await this.gearBoxesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .ToListAsync();

            return gearBoxes;
        }
    }
}

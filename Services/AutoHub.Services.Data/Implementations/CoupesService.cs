namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CoupesService : ICoupesService
    {
        private readonly IDeletableEntityRepository<Coupe> coupesRepository;

        public CoupesService(IDeletableEntityRepository<Coupe> coupesRepository)
        {
            this.coupesRepository = coupesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllCoupes()
        {
            var coupes = new List<KeyValuePair<string, string>>();

            coupes = await this.coupesRepository.All().Select(c => new
            {
                c.Id,
                c.Name,
            })
            .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), c.Name)).ToListAsync();

            return coupes;
        }
    }
}

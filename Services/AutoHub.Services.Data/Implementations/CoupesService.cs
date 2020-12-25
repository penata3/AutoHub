namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class CoupesService : ICoupesService
    {
        private readonly IDeletableEntityRepository<Coupe> coupesRepository;

        public CoupesService(IDeletableEntityRepository<Coupe> coupesRepository)
        {
            this.coupesRepository = coupesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCoupes()
        {
            return this.coupesRepository.All().Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

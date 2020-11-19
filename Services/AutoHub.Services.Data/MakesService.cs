namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class MakesService : IMakeService
    {
        private readonly IDeletableEntityRepository<Make> makesRepository;

        public MakesService(IDeletableEntityRepository<Make> makesRepository)
        {
            this.makesRepository = makesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllMakes()
        {
            return this.makesRepository.All().Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

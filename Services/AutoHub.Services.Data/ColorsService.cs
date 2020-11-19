namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class ColorsService : IColorService
    {
        private readonly IDeletableEntityRepository<Color> colorsRepository;

        public ColorsService(IDeletableEntityRepository<Color> colorsRepository)
        {
            this.colorsRepository = colorsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllColors()
        {
            return this.colorsRepository.All().Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

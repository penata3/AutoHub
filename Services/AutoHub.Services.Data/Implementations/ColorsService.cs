namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ColorsService : IColorService
    {
        private readonly IDeletableEntityRepository<Color> colorsRepository;

        public ColorsService(IDeletableEntityRepository<Color> colorsRepository)
        {
            this.colorsRepository = colorsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllColors()
        {
            var colors = new List<KeyValuePair<string, string>>();

            colors = await this.colorsRepository.AllAsNoTracking().Select(c => new
            {
                c.Id,
                c.Name,
            }).Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToListAsync();


            return colors;
        }
    }
}

namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Web.ViewModels.Cars;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<MakeViewModel>> GetMakeWithModelsAsync(int id)
        {
            var data = await this.makesRepository.All()
                .Where(x => x.Id == id)
                .Include(x => x.Models)
                .ToListAsync();

            var viewModelList = data.Select(x => new MakeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Models = x.Models.Select(m => new ModelViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                }),
            });

            return viewModelList;
        }
    }
}

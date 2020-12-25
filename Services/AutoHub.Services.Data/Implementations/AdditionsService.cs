namespace AutoHub.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Services.Mapping;
    using AutoHub.Web.ViewModels.Additions;
    using Microsoft.EntityFrameworkCore;

    public class AdditionsService : IAdditionsService
    {
        private readonly IDeletableEntityRepository<Addition> additionsRepository;

        public AdditionsService(IDeletableEntityRepository<Addition> additionsRepository)
        {
            this.additionsRepository = additionsRepository;
        }

        public AdditionViewModel[] GetAllAditions()
        {
            return this.additionsRepository.AllAsNoTracking()
                .To<AdditionViewModel>()
                .ToArray();
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAditionsAsKeyValuePairAsync()
        {
            var aditions = new List<KeyValuePair<string, string>>();

            aditions = await this.additionsRepository.AllAsNoTracking()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToListAsync();

            return aditions;
        }
    }
}

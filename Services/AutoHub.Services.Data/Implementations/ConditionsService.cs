namespace AutoHub.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ConditionsService : IConditionsService
    {
        private readonly IDeletableEntityRepository<Condition> conditionsRepository;

        public ConditionsService(IDeletableEntityRepository<Condition> conditionsRepository)
        {
            this.conditionsRepository = conditionsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllConditionsAsync()
        {
            var conditions = new List<KeyValuePair<string, string>>();

            conditions = await this.conditionsRepository.AllAsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new KeyValuePair<string, string>(c.Id.ToString(), c.Name)).ToListAsync();
            conditions.Insert(0, new KeyValuePair<string, string>("Select condition", null));
            return conditions;
        }
    }
}

namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCategories()
        {
            return this.categoriesRepository.All().Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

﻿namespace AutoHub.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Web.ViewModels.Regions;
    using Microsoft.EntityFrameworkCore;

    public class RegionsService : IRegionsServices
    {
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public RegionsService(IDeletableEntityRepository<Region> regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegionsAsync()
        {
            var regions = new List<KeyValuePair<string, string>>();

            regions = await this.regionsRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .ToListAsync();
            regions.Insert(0, new KeyValuePair<string, string>("Select regions", null));
            return regions;
        }

        public async Task<IEnumerable<RegionViewModel>> GetAllTownsForRegion(int id)
        {
            var data = await this.regionsRepository.All()
            .Where(x => x.Id == id)
            .Include(x => x.Towns)
            .ToArrayAsync();

            var selectList = data.Select(x => new RegionViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Towns = x.Towns.Select(t => new TownViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                }),
            });

            return selectList;
        }
    }
}

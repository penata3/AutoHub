namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Web.ViewModels.Regions;

    public interface IRegionsServices
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllRegionsAsync();

        Task<IEnumerable<RegionViewModel>> GetAllTownsForRegion(int id);
    }
}

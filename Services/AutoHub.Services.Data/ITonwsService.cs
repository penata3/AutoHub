namespace AutoHub.Services.Data
{
    using AutoHub.Data.Models;

    using System.Threading.Tasks;

    public interface ITonwsService
    {
        Task Create(string name, int regionId);

        Town GetTownByNameAndRegionId(string name, int regionId);
    }
}

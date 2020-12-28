namespace AutoHub.Services.Data
{
    using AutoHub.Web.ViewModels.Cars;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMakeService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllMakes();

        Task<IEnumerable<MakeViewModel>> GetMakeWithModelsAsync(int id);
    }
}

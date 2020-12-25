namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Data.Models;
    using AutoHub.Web.ViewModels.Additions;

    public interface IAdditionsService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAditionsAsKeyValuePairAsync();

        AdditionViewModel[] GetAllAditions();
    }
}

namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task CreateAsync(AddCarInputModel input, string userId, string imagePath);

        Task AddAllSelectListValuesForCarInputModel(AddCarInputModel input);

        IEnumerable<T> GetAllCars<T>(int page, int itemsPerPage);

        int GetCount();

        int GetCounForCoupeType(string coupeType);

        T GetById<T>(int id);

        IEnumerable<T> GetAllByCoupeType<T>(int page, int itemsPerPage, string coupeType);
    }
}

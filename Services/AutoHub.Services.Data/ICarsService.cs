namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task CreateAsync(AddCarInputModel input, string userId, string imagePath);

        Task AddAllSelectListValuesForCarInputModel(AddCarInputModel input);

        Task AddAllSelectListValuesForCarEditInputModel(EditCarInputModel input);

        IEnumerable<T> GetAllCars<T>(int page, int itemsPerPage);

        int GetCount();

        int GetCounForCoupeType(string coupeType);

        int GetCountForFuelType(string fuelType);

        int GetCountForCarsPerMake(string makeName);

        void IncreaseView(int id);

        T GetById<T>(int id);

        IEnumerable<T> GetAllByCoupeType<T>(int page, int itemsPerPage, string coupeType);

        IEnumerable<T> GetAllByFuelType<T>(int page, int itemsPerPage, string fuelType);

        IEnumerable<T> GetAllByMakeName<T>(int page, int itemsPerPage, string makeName);

        Task UpdateAsync(int id, EditCarInputModel model);


        IEnumerable<T> GetLatestFiveCars<T>();
    }
}

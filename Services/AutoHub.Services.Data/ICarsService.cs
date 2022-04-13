namespace AutoHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoHub.Web.ViewModels.Cars;
    using AutoHub.Web.ViewModels.Search;

    public interface ICarsService
    {
        Task CreateAsync(AddCarInputModel input, string userId, string imagePath);

        Task AddAllSelectListValuesForCarInputModel(AddCarInputModel input);

        Task AddSelectListValuesForAdvancedSearchModel(AdvancedSearchViewModel input);

        Task AddAllSelectListValuesForCarEditInputModel(EditCarInputModel input);

        Task AddSelectListValuesForCarCreateOrEditModel<T>(T input);

        IEnumerable<T> GetAllCars<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllCars<T>();

        IEnumerable<T> GetCarsFromPriceDescending<T>(int page, int itemsPerPage);

        IEnumerable<T> GetCarsFromPriceAscenging<T>(int page, int itemsPerPage);

        IEnumerable<T> GetCarsFromPriceDescending<T>();

        IEnumerable<T> GetCarsFromPriceAscenging<T>();

        IEnumerable<T> GetAllCarsFromLatest<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllCarsFromOldest<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllBySearchingCriteria<T>(AdvancedSearchViewModel model);

        int GetCount();

        int GetCounForCoupeType(string coupeType);

        int GetCountForFuelType(string fuelType);

        int GetCountForCarsPerMake(string makeName);

        void IncreaseView(int id);

        T GetById<T>(int id);

        IEnumerable<T> GetAllByCoupeType<T>(int page, int itemsPerPage, string coupeType);

        IEnumerable<T> GetAllByFuelType<T>(int page, int itemsPerPage, string fuelType);

        IEnumerable<T> GetAllByMakeName<T>(int page, int itemsPerPage, string makeName);

        IEnumerable<T> GetAllByAdditions<T>(IEnumerable<int> aditionsIds);

        Task UpdateAsync(int id, EditCarInputModel model);

        Task Delete(int id);

        IEnumerable<T> GetLatestFiveCars<T>();
    }
}

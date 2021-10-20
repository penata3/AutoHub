namespace AutoHub.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CarModelsController : BaseController
    {
        private readonly IMakeService makesService;

        public CarModelsController(IMakeService makesService)
        {
            this.makesService = makesService;
        }

        public async Task<IActionResult> GetModels(int id)
        {
            if (id != 0)
            {
                var data = await this.makesService.GetMakeWithModelsAsync(id);
                var result = data.FirstOrDefault(x => x.Id == id).Models;
                return this.Json(result);
            };

            return null;
              
        }
    }
}

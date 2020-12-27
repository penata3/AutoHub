namespace AutoHub.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class RegionTownsController : BaseController
    {
        private readonly IRegionsServices regionsService;

        public RegionTownsController(IRegionsServices regionsService)
        {
            this.regionsService = regionsService;
        }

        public async Task<IActionResult> GetTowns(int id)
        {
            var data = await this.regionsService.GetAllTownsForRegion(id);

            var result = data.FirstOrDefault(x => x.Id == id).Towns;

            return this.Json(result);
        }
    }
}

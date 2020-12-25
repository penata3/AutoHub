using AutoHub.Data;
using AutoHub.Data.Models;
namespace AutoHub.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class TownsController : BaseController
    {
        private readonly ApplicationDbContext db;

        public TownsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet("api/towns/{regionId}")]
        public IEnumerable<Town> Towns(int regionId)
        {
            return this.db.Towns.Where(t => t.RegionId == regionId).ToList();
        }
    }
}

namespace AutoHub.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoHub.Data;
    using AutoHub.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ModelsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public ModelsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("api/models")]
        [Authorize]
        public IEnumerable<Model> AllModels()
        {
            var models = this.dbContext.Models.ToList();

            return models;
        }
    }
}

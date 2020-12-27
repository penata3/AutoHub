namespace AutoHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoHub.Services.Data;
    using AutoHub.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.votesService.SetVoteAsync(input.CarId, userId, input.Value);
            var averageVotes = this.votesService.GetAverageVotes(input.CarId);
            return new PostVoteResponseModel { AverageVote = averageVotes };
        }
    }
}

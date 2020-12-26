namespace AutoHub.Services.Data.Implementations
{
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int carId)
        {
            return this.votesRepository.All().Where(x => x.CarId == carId).Average(x => x.Value);

        }

        public async Task SetVoteAsync(int carId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(v => v.CarId == carId && v.UserId == userId);

            if (vote == null)
            {
                vote = new Vote()
                {
                    CarId = carId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}

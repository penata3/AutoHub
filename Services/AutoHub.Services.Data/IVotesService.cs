namespace AutoHub.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService 
    {
        Task SetVoteAsync(int carId, string userId, byte value);

        double GetAverageVotes(int carId);
    }
}

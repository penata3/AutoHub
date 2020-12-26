using System.ComponentModel.DataAnnotations;

namespace AutoHub.Web.ViewModels.Votes
{
    public class PostVoteInputModel
    {
        public int CarId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}

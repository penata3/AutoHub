namespace AutoHub.Data.Models
{
    using AutoHub.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}

namespace AutoHub.Data.Models
{
    public class CarAddition
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public int AdditionId { get; set; }

        public virtual Addition Addition { get; set; }
    }
}

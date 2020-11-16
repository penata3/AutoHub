namespace AutoHub.Data.Models
{
    using AutoHub.Data.Common.Models;

    public class Model : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}

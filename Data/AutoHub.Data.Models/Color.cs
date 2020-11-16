namespace AutoHub.Data.Models
{
    using AutoHub.Data.Common.Models;

    public class Color : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}

namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class Addition : BaseDeletableModel<int>
    {
        public Addition()
        {
            this.Cars = new HashSet<CarAddition>();
        }

        public string Name { get; set; }

        public virtual ICollection<CarAddition> Cars { get; set; }
    }
}

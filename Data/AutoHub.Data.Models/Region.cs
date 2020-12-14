namespace AutoHub.Data.Models
{
    using System.Collections.Generic;

    using AutoHub.Data.Common.Models;

    public class Region : BaseDeletableModel<int>
    {
        public Region()
        {
            this.Towns = new HashSet<Town>();
        }

        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}

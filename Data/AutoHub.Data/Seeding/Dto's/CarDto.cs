namespace AutoHub.Data.Seeding.Dto_s
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarDto
    {
        public CarDto()
        {
            this.Additions = new HashSet<string>();
        }

        public string OriginalUrl { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Condition { get; set; }

        public string CoupeType { get; set; }

        public string ManifactureDate { get; set; }

        public int HorsePower { get; set; }

        public string GearBox { get; set; }

        public string Color { get; set; }

        public string Fuel { get; set; }

        public int Milage { get; set; }

        public string Description { get; set; }

        public string TechDataUrl { get; set; }

        public ICollection<string> Additions { get; set; }
    }
}

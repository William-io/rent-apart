using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Domain.Entities
{
    [Table("Renting")]
    public class Renting : Entity
    {
        //public string Name { get; set; }
        public string Description { get; set; }
        public int Ranting { get; set; }
        public double Rooms { get; set; }
        public double Bookings { get; set; }
        public decimal Price { get; set; }
        public bool Gym { get; set; }
        public bool Pool { get; set; }
        public bool Availability { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool Active { get; set; } = true;

    }
}

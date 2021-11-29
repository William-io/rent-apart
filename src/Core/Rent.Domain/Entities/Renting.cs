namespace Rent.Domain.Entities
{
    public class Renting : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ranting { get; set;}
        public double Rooms { get; set;}
        public double Bookings { get; set; }
        public bool Gym { get; set; }
        public bool Pool { get; set; }

        public Category Category { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool Availability { get; set; }

    }
}

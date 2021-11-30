namespace Rent.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        // IEquatable<Entity>
        // public bool Equals(Entity other)
        // {
        //     return Id == other.Id;
        // }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EditedBy { get; set; }
        public DateTime EditedOn { get; set; }
    }
}

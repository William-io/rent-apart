namespace Rent.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity> 
    {

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}

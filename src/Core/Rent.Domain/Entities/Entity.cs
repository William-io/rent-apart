using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity> 
    {

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get;  set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}

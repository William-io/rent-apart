using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Domain.Entities
{
    [Table("Category")]
    public class Category : Entity
    {      
        public bool Active { get; set; } = true;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Domain.Entities
{
    [Table("Category")]
    public class Category : Entity
    {
        [Required]
        public string Type { get; set; } //Name

        public IList<Renting> Rentings {get; set;}

    }
}

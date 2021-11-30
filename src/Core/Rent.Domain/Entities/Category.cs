using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;

namespace Rent.Domain.Entities
{
    [Table("Category")]
    public class Category : Entity
    {
        public bool Active { get; set; }

        public Category(string name)
        {
            //Contract
            var contract = new Contract<Category>()
                .IsNotNull(name, "Name", "Nome é obrigatório!"); //name not null
            AddNotifications(contract); //pass contract to AddNotifications

            Name = name;
            Active = true;
        }
    }
}

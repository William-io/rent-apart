using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;

namespace Rent.Domain.Entities
{
    [Table("Category")]
    public class Category : Entity
    {
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public Category(string name, string createdBy, string editedBy)
        {
            //Contract

            Name = name;
            Active = true;
            CreatedBy = createdBy;
            EditedBy = editedBy;
            CreatedOn = DateTime.Now;
            EditedOn = DateTime.Now;

            Validate();

        }

        private void Validate()
        {
            var contract = new Contract<Category>()
                .IsNotNullOrEmpty(Name, "Name", "Titulo é obrigatório!")
                .IsGreaterOrEqualsThan(Name, 3, "Name")
                .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
                .IsNotNullOrEmpty(EditedBy, "EditedBy");
            AddNotifications(contract);
        }

        public void EditInfo(string name, bool active)
        {
            Active = active;
            Name = name;

            var contract = new Contract<Category>()
                .IsNotNullOrEmpty(Name, "Name", "Titulo é obrigatório!") //name not null
                .IsGreaterOrEqualsThan(Name, 3, "Name") //name not null
                .IsNotNullOrEmpty(CreatedBy, "CreatedBy") //name not null
                .IsNotNullOrEmpty(EditedBy, "EditedBy"); //name not null
            AddNotifications(contract); //pass contract to AddNotifications

        }
    }
}

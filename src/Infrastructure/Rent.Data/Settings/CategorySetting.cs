using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities;

namespace Rent.Data.Settings
{
    public class CategorySetting : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Type).HasMaxLength(60).HasColumnName("VARCHAR(60)").IsRequired();

            builder.HasData(new Category 
            {
                Id = Guid.NewGuid(),
                Type = "Casa"
            });
        
        }


        
    }
}

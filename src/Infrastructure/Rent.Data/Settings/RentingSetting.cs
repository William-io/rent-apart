using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities;

namespace Rent.Data.Settings
{
    public class RentingSetting : IEntityTypeConfiguration<Renting>
    {
        public void Configure(EntityTypeBuilder<Renting> builder)
        {
            //builder.ToTable("Renting");

            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(40).HasColumnName("VARCHAR(40)").IsRequired();
            builder.Property(x => x.Description).HasMaxLength(120).HasColumnName("VARCHAR(120)").IsRequired();
            builder.Property(x => x.Ranting).IsRequired();
            builder.Property(x => x.Rooms).IsRequired();
            builder.Property(x => x.Bookings).IsRequired();
            builder.Property(x => x.Gym);
            builder.Property(x => x.Pool);
            builder.Property(x => x.Price).HasPrecision(18, 2).IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Rentings)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);
          
            builder.HasData(new Renting
            {
                Id = Guid.NewGuid(),
                Name = "Hotel Quay",
                Description = "Hotel Quay is a hotel in the city of Quay, in the municipality of Quay, in the province of Québec, Canada.",
                Ranting = 5,
                Rooms = 2,
                Bookings = 0,
                Gym = true,
                Pool = true,
                Price = 1000.00M,
                CreatedOn = DateTime.Now
            });
        }



    }
}

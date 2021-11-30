using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Rent.Domain.Entities;

namespace Rent.Data.Context
{
    public class RentContext : DbContext
    {
        public RentContext(DbContextOptions<RentContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Renting> Rentings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Ignored Flunt on Runtime
            builder.Ignore<Notification>();

            builder.Entity<Category>().Property(p => p.Name).IsRequired();

            builder.Entity<Renting>().Property(p => p.Name).IsRequired();
            builder.Entity<Renting>().Property(p => p.Description).HasMaxLength(255);
            builder.Entity<Renting>().Property(p => p.Price).HasPrecision(18, 2).IsRequired();

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>().HaveMaxLength(100);
        }
    }
}

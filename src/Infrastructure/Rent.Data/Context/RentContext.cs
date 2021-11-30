using Microsoft.EntityFrameworkCore;
using Rent.Domain.Entities;

namespace Rent.Data.Context
{
    public class RentContext : DbContext
    {
        public RentContext(DbContextOptions<RentContext> options) : base(options) { }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Renting> Rentings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(RentContext)
                .Assembly);
        }

    }
}

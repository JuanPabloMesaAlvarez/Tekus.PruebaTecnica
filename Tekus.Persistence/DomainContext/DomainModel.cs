using System.Data.Entity;
using Tekus.Domain.Countries;
using Tekus.Domain.Customers;
using Tekus.Domain.Services;

namespace Tekus.Persistence.DomainContext
{
    class DomainModel : DbContext
    {
        public DomainModel()
            : base("TekusCnn")
        {
            Countries = base.Set<Country>();
            Customers = base.Set<Customer>();
            Services = base.Set<Service>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Countries)
                .WithMany(c => c.Services)
                .Map(cs =>
                {
                    cs.MapLeftKey("ServiceId");
                    cs.MapRightKey("CountryId");
                    cs.ToTable("ServicesCountries");
                });
        }

        public DbSet<Country> Countries { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Service> Services { get; private set; }

    }
}

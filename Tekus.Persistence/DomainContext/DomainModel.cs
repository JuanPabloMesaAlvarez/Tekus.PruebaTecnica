using System.Data.Entity;
using Tekus.Domain.Countries;
using Tekus.Domain.Customers;
using Tekus.Domain.Services;
using Tekus.Persistence.Cache;

namespace Tekus.Persistence.DomainContext
{
    class DomainModel : DbContext
    {
        private DbSet<Country> countries;
        private DbSet<Customer> customers;
        private DbSet<Service> services;

        public DomainModel()
            : base("TekusCnn")
        {
            IsCacheStorage = false;
            countries = base.Set<Country>();
            customers = base.Set<Customer>();
            services = base.Set<Service>();

            if (!CacheHandler.Data.ContainsKey("Countries"))
            {
                CacheHandler.Data.Add("Countries", countries);
            }
            if (!CacheHandler.Data.ContainsKey("Customers"))
            {
                CacheHandler.Data.Add("Customers", customers);
            }
            if (!CacheHandler.Data.ContainsKey("Services"))
            {
                CacheHandler.Data.Add("Services", services);
            }
        }

        /// <summary>
        /// this method configure database whit relationship needed
        /// </summary>
        /// <param name="modelBuilder">model builder</param>
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

        public bool IsCacheStorage { get; private set; }

        public void TurnOnCache()
        {
            IsCacheStorage = true;
        }

        public void TurnOffCache()
        {
            IsCacheStorage = false;
        }

        public DbSet<Country> Countries
        {
            get
            {
                if (IsCacheStorage)
                {
                    return (DbSet<Country>)CacheHandler.Data["Countries"];
                }

                return countries;
            }
        }
        public DbSet<Customer> Customers
        {
            get
            {
                if (IsCacheStorage)
                {
                    return (DbSet<Customer>)CacheHandler.Data["Customers"];
                }

                return customers;
            }
        }
        public DbSet<Service> Services
        {
            get
            {
                if (IsCacheStorage)
                {
                    return (DbSet<Service>)CacheHandler.Data["Services"];
                }

                return services;
            }
        }

    }
}

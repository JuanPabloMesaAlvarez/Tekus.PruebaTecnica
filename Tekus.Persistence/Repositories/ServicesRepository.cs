using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tekus.Domain.Countries;
using Tekus.Domain.Repositories;
using Tekus.Domain.Services;
using Tekus.Persistence.DomainContext;

namespace Tekus.Persistence.Repositories
{
    /// <summary>
    /// this class manage all data access to services table
    /// </summary>
    class ServicesRepository : IServicesRepository
    {
        private readonly DomainModel context;

        public ServicesRepository(DomainModel context)
        {
            this.context = context;
        }

        public void AddService(Service service)
        {
            if (service.CountriesIds.Length > 0)
            {
                var countries = context.Countries.Where(c => service.CountriesIds.Contains(c.CountryId));
                service.Countries.Clear();
                foreach (Country country in countries)
                {
                    service.Countries.Add(country);
                }
            }
            context.Services.Add(service);
        }

        public Service GetServiceById(int serviceId)
        {
            Service service = context.Services.Include("Countries").First(s => s.ServiceId == serviceId);
            service.CountriesIds = service.Countries.Select(c => c.CountryId).ToArray();
            return service;
        }

        public IEnumerable<Service> GetServices()
        {
            return context.Services;
        }

        public Service UpdateService(Service service)
        {
            var dbService = context.Services.Find(service.ServiceId);
            if (service.CountriesIds.Length > 0)
            {
                var countries = context.Countries.Where(c => service.CountriesIds.Contains(c.CountryId));
                dbService.Countries.Clear();
                foreach (Country country in countries)
                {
                    dbService.Countries.Add(country);
                }
            }
            dbService.CustomerId = service.CustomerId;
            dbService.Name = service.Name;
            dbService.Cost = service.Cost;

            var entry = context.Entry(dbService);

            if (entry.State == EntityState.Detached)
            {
                context.Services.Attach(dbService);
                entry = context.Entry(dbService);
            }
            entry.State = EntityState.Modified;
            return entry.Entity;
        }
    }
}

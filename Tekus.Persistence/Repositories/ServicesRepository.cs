using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            context.Services.Add(service);
        }

        public Service GetServiceById(int serviceId)
        {
            return context.Services.Include("Countries").First(s => s.ServiceId == serviceId);
        }

        public IEnumerable<Service> GetServices()
        {
            return context.Services;
        }

        public Service UpdateService(Service service)
        {
            var entry = context.Entry(service);

            if (entry.State == EntityState.Detached)
            {
                context.Services.Attach(service);
                entry = context.Entry(service);
            }
            entry.State = EntityState.Modified;
            return entry.Entity;
        }
    }
}

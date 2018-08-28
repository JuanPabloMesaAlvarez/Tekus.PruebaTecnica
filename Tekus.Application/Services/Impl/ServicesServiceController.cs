using System.Collections.Generic;
using Tekus.Application.Services.Contract;
using Tekus.Domain.Services;
using Tekus.DomainServices.DomainServices.Contract;

namespace Tekus.Application.Services.Impl
{
    class ServicesServiceController : IServicesServiceController
    {
        private readonly IServicesServices services;

        public ServicesServiceController(IServicesServices service)
        {
            this.services = service;
        }

        public void AddService(Service service)
        {
            services.AddService(service);
        }

        public Service GetServiceById(int serviceId)
        {
            return services.GetServiceById(serviceId);
        }

        public IEnumerable<Service> GetServices()
        {
            return services.GetServices();
        }

        public Service UpdateService(Service service)
        {
            return services.UpdateService(service);
        }

        public void TurnOffCache()
        {
            services.TurnOffCache();
        }

        public void TurnOnCache()
        {
            services.TurnOnCache();
        }
    }
}

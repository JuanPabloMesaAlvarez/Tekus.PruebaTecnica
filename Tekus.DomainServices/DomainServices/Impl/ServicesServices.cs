using System.Collections.Generic;
using Tekus.Domain.Repositories;
using Tekus.Domain.Services;
using Tekus.DomainServices.DomainServices.Contract;

namespace Tekus.DomainServices.DomainServices.Impl
{
    public class ServicesServices : IServicesServices
    {
        private readonly IUnitOfWork unitOfWork;

        public ServicesServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddService(Service service)
        {
            unitOfWork.ServicesRepository.AddService(service);
            unitOfWork.SaveChanges();
        }

        public Service GetServiceById(int serviceId)
        {
            return unitOfWork.ServicesRepository.GetServiceById(serviceId);
        }

        public IEnumerable<Service> GetServices()
        {
            return unitOfWork.ServicesRepository.GetServices();
        }

        public Service UpdateService(Service service)
        {
            Service udtService = unitOfWork.ServicesRepository.UpdateService(service);
            unitOfWork.SaveChanges();
            return udtService;
        }
    }
}

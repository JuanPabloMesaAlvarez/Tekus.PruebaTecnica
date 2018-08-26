using Tekus.Application.Services.Contract;
using Tekus.Application.Services.Impl;
using Tekus.Domain.Repositories;
using Tekus.DomainServices.DomainServices.Contract;
using Tekus.DomainServices.DomainServices.Impl;
using Tekus.Infraestructure.Dependencies;
using Tekus.Persistence.UnitOfWork;

namespace Tekus.Application.Utils
{
    public static class RegisterTypes
    {
        public static void RegisterApplicationTypes()
        {
            RegisterDomainRepositories();
            RegisterDomainServices();
            RegisterApplicationServices();
        }

        private static void RegisterApplicationServices()
        {
            DependencyFactory.RegisterType<ICountriesServiceController, CountriesServiceController>();
            DependencyFactory.RegisterType<ICustomersServiceController, CustomersServiceController>();
            DependencyFactory.RegisterType<IServicesServiceController, ServicesServiceController>();
        }

        private static void RegisterDomainServices()
        {
            DependencyFactory.RegisterType<ICountriesServices, CountriesServices>();
            DependencyFactory.RegisterType<ICustomersServices, CustomersServices>();
            DependencyFactory.RegisterType<IServicesServices, ServicesServices>();
        }

        private static void RegisterDomainRepositories()
        {
            DependencyFactory.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}

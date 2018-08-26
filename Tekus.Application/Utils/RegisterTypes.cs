using Tekus.Application.Services.Contract;
using Tekus.Application.Services.Impl;
using Tekus.Domain.Repositories;
using Tekus.DomainServices.DomainServices.Contract;
using Tekus.DomainServices.DomainServices.Impl;
using Tekus.Infraestructure.Dependencies;
using Tekus.Persistence.UnitOfWork;

namespace Tekus.Application.Utils
{
    /// <summary>
    /// this class is used to register all  application's dependencies
    /// </summary>
    public static class RegisterTypes
    {
        public static void RegisterApplicationTypes()
        {
            RegisterDomainRepositories();
            RegisterDomainServices();
            RegisterApplicationServices();
        }

        /// <summary>
        /// this method register interfaces needed in controller and itself implementation
        /// </summary>
        private static void RegisterApplicationServices()
        {
            DependencyFactory.RegisterType<ICountriesServiceController, CountriesServiceController>();
            DependencyFactory.RegisterType<ICustomersServiceController, CustomersServiceController>();
            DependencyFactory.RegisterType<IServicesServiceController, ServicesServiceController>();
        }

        /// <summary>
        /// this method register interfaces needed in domain logic and itself implementation
        /// </summary>
        private static void RegisterDomainServices()
        {
            DependencyFactory.RegisterType<ICountriesServices, CountriesServices>();
            DependencyFactory.RegisterType<ICustomersServices, CustomersServices>();
            DependencyFactory.RegisterType<IServicesServices, ServicesServices>();
        }

        /// <summary>
        /// this method register interfaces needed in data access and itself implementation
        /// </summary>
        private static void RegisterDomainRepositories()
        {
            DependencyFactory.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}

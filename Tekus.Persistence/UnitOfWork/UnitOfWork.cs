using System.Threading.Tasks;
using Tekus.Domain.Repositories;
using Tekus.Persistence.DomainContext;
using Tekus.Persistence.Repositories;

namespace Tekus.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainModel contexto;

        public UnitOfWork()
        {
            contexto = new DomainModel();
        }

        private ICountriesRepository countriesRepository;
        private ICustomersRepository customersRepository;
        private IServicesRepository servicesRepository;

        public ICountriesRepository CountriesRepository => countriesRepository ?? (countriesRepository = new CountriesRepository(contexto));
        public ICustomersRepository CustomersRepository => customersRepository ?? (customersRepository = new CustomersRepositoy(contexto));
        public IServicesRepository ServicesRepository => servicesRepository ?? (servicesRepository = new ServicesRepository(contexto));

        public int SaveChanges()
        {
            return contexto.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return contexto.SaveChangesAsync();
        }
    }
}

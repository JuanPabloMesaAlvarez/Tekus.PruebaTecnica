using System.Threading.Tasks;
using Tekus.Domain.Repositories;
using Tekus.Persistence.DomainContext;
using Tekus.Persistence.Repositories;

namespace Tekus.Persistence.UnitOfWork
{
    /// <summary>
    /// this class is facade that allow group all repositories in same place 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainModel contexto;

        public UnitOfWork()
        {
            contexto = new DomainModel();
        }

        public bool IsCacheStorage { get { return contexto.IsCacheStorage; } }

        public void TurnOnCache()
        {
            contexto.TurnOnCache();
        }

        public void TurnOffCache()
        {
            contexto.TurnOffCache();
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

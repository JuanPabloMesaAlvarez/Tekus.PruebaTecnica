using System.Threading.Tasks;

namespace Tekus.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICountriesRepository CountriesRepository { get; }
        ICustomersRepository CustomersRepository { get; }
        IServicesRepository ServicesRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

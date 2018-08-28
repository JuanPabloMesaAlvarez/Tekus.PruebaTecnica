using System.Threading.Tasks;
using Tekus.Domain.Utils.Cache;

namespace Tekus.Domain.Repositories
{
    public interface IUnitOfWork : ICacheMode
    {
        ICountriesRepository CountriesRepository { get; }
        ICustomersRepository CustomersRepository { get; }
        IServicesRepository ServicesRepository { get; }

        /// <summary>
        /// this method do commit to database
        /// </summary>
        /// <returns>number of changes done</returns>
        int SaveChanges();
        /// <summary>
        /// this method do commit to database asynchous
        /// </summary>
        /// <returns>task with number of changes done</returns>
        Task<int> SaveChangesAsync();
    }
}

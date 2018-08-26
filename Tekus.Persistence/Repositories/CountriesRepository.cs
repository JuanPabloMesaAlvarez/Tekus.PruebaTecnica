using System.Collections.Generic;
using System.Linq;
using Tekus.Domain.Countries;
using Tekus.Domain.Repositories;
using Tekus.Persistence.DomainContext;

namespace Tekus.Persistence.Repositories
{
    /// <summary>
    /// this class manage all data access to Countries table
    /// </summary>
    class CountriesRepository : ICountriesRepository
    {
        private readonly DomainModel context;

        public CountriesRepository(DomainModel context)
        {
            this.context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries;
        }

        public Country GetCountryById(int countryId)
        {
            var a = context.Countries.Include("Services").First(c => c.CountryId == countryId);
            return a;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Tekus.Domain.Countries;
using Tekus.Domain.Repositories;
using Tekus.Persistence.DomainContext;

namespace Tekus.Persistence.Repositories
{
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
            return context.Countries.Include("Services").First(c => c.CountryId == countryId);
        }
    }
}

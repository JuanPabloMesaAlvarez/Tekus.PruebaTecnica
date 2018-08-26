using System.Collections.Generic;
using Tekus.Application.Services.Contract;
using Tekus.Domain.Countries;
using Tekus.DomainServices.DomainServices.Contract;

namespace Tekus.Application.Services.Impl
{
    class CountriesServiceController : ICountriesServiceController
    {
        private readonly ICountriesServices service;

        public CountriesServiceController(ICountriesServices service)
        {
            this.service = service;
        }

        public IEnumerable<Country> GetCountries()
        {
            return service.GetCountries();
        }

        public Country GetCountryById(int countryId)
        {
            return service.GetCountryById(countryId);
        }
    }
}

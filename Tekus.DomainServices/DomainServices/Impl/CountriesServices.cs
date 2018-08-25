using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Domain.Countries;
using Tekus.Domain.Repositories;
using Tekus.DomainServices.DomainServices.Contract;

namespace Tekus.DomainServices.DomainServices.Impl
{
    public class CountriesServices : ICountriesServices
    {
        private readonly IUnitOfWork unitOfWork;

        public CountriesServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Country> GetCountries()
        {
            return unitOfWork.CountriesRepository.GetCountries();
        }

        public Country GetCountryById(int countryId)
        {
            return unitOfWork.CountriesRepository.GetCountryById(countryId);
        }
    }
}

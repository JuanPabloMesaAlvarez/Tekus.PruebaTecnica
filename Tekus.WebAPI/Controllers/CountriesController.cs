using System.Collections.Generic;
using System.Web.Http;
using Tekus.Application.Services.Contract;
using Tekus.Domain.Countries;

namespace Tekus.WebAPI.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountriesServiceController service;

        public CountriesController(ICountriesServiceController service)
        {
            this.service = service;
        }

        // GET: api/Countries
        public IEnumerable<Country> Get()
        {
            return service.GetCountries();
        }

        // GET: api/Countries/5
        public Country Get(int id)
        {
            return service.GetCountryById(id);
        }
    }
}

using Tekus.Application.Services.Contract;

namespace Tekus.WebAPI.Controllers
{
    public class CountriesCacheController : CountriesController
    {
        public CountriesCacheController(ICountriesServiceController service)
            : base(service)
        {
            service.TurnOnCache();
        }
    }
}

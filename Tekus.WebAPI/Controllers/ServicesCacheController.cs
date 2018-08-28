using Tekus.Application.Services.Contract;

namespace Tekus.WebAPI.Controllers
{
    public class ServicesCacheController : ServicesController
    {
        public ServicesCacheController(IServicesServiceController service)
            : base(service)
        {
            service.TurnOnCache();
        }
    }
}

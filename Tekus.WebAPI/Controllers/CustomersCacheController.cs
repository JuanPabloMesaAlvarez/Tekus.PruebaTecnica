using Tekus.Application.Services.Contract;

namespace Tekus.WebAPI.Controllers
{
    public class CustomersCacheController : CustomersController
    {
        public CustomersCacheController(ICustomersServiceController service)
            : base(service)
        {
            service.TurnOnCache();
        }
    }
}

using System.Collections.Generic;
using System.Web.Http;
using Tekus.Application.Services.Contract;
using Tekus.Domain.Services;

namespace Tekus.WebAPI.Controllers
{
    public class ServicesController : ApiController
    {
        private readonly IServicesServiceController service;

        public ServicesController(IServicesServiceController service)
        {
            service.TurnOffCache();
            this.service = service;
        }

        // GET: api/Services
        public IEnumerable<Service> Get()
        {
            return service.GetServices();
        }

        // GET: api/Services/5
        public Service Get(int id)
        {
            return service.GetServiceById(id);
        }

        // POST: api/Services
        public void Post([FromBody]Service value)
        {
            service.AddService(value);
        }

        // PUT: api/Services/5
        public Service Put(int id, [FromBody]Service value)
        {
            return service.UpdateService(value);
        }
    }
}

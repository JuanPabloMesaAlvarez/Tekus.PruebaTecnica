using System.Collections.Generic;
using System.Web.Http;
using Tekus.Application.Services.Contract;
using Tekus.Domain.Customers;

namespace Tekus.WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomersServiceController service;

        public CustomersController(ICustomersServiceController service)
        {
            this.service = service;
        }

        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            return service.GetCustomers();
        }

        // GET: api/Customers/5
        public Customer Get(int id)
        {
            return service.GetCustomerById(id);
        }
    }
}

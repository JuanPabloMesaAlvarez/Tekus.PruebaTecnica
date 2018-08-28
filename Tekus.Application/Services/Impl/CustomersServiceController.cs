using System.Collections.Generic;
using Tekus.Application.Services.Contract;
using Tekus.Domain.Customers;
using Tekus.DomainServices.DomainServices.Contract;

namespace Tekus.Application.Services.Impl
{
    class CustomersServiceController : ICustomersServiceController
    {
        private readonly ICustomersServices service;

        public CustomersServiceController(ICustomersServices service)
        {
            this.service = service;
        }

        public Customer GetCustomerById(int customerId)
        {
            return service.GetCustomerById(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return service.GetCustomers();
        }

        public void TurnOffCache()
        {
            service.TurnOffCache();
        }

        public void TurnOnCache()
        {
            service.TurnOnCache();
        }
    }
}

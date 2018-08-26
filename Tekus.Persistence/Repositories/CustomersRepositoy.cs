using System.Collections.Generic;
using System.Linq;
using Tekus.Domain.Customers;
using Tekus.Domain.Repositories;
using Tekus.Persistence.DomainContext;

namespace Tekus.Persistence.Repositories
{
    /// <summary>
    /// this class manage all data access to customers table
    /// </summary>
    class CustomersRepositoy : ICustomersRepository
    {
        private readonly DomainModel context;

        public CustomersRepositoy(DomainModel context)
        {
            this.context = context;
        }

        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.Include("Services").First(c => c.CustomerId == customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers;
        }
    }
}

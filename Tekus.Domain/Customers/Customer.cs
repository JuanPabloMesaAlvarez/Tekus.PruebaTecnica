using System.Collections.Generic;
using Tekus.Domain.Services;

namespace Tekus.Domain.Customers
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int Nit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<Service> Services { get; set; }
    }
}

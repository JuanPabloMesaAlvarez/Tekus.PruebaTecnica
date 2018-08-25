using System.Collections.Generic;
using Tekus.Domain.Customers;
using Tekus.Domain.Repositories;
using Tekus.DomainServices.DomainServices.Contract;

namespace Tekus.DomainServices.DomainServices.Impl
{
    class CustomerServices : ICustomerServices
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Customer GetCustomerById(int customerId)
        {
            return unitOfWork.CustomersRepository.GetCustomerById(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return unitOfWork.CustomersRepository.GetCustomers();
        }
    }
}

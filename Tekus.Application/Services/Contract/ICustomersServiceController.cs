using System.Collections.Generic;
using Tekus.Domain.Customers;
using Tekus.Domain.Utils.Cache;

namespace Tekus.Application.Services.Contract
{
    public interface ICustomersServiceController : ICacheMode
    {
        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns>List all customers</returns>
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Returns customer that match with input parameter
        /// </summary>
        /// <param name="countryId">Customer id</param>
        /// <returns>Customer entity</returns>
        Customer GetCustomerById(int customerId);
    }
}

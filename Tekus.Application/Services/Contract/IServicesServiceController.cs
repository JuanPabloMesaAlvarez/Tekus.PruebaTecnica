using System.Collections.Generic;
using Tekus.Domain.Services;
using Tekus.Domain.Utils.Cache;

namespace Tekus.Application.Services.Contract
{
    public interface IServicesServiceController : ICacheMode
    {
        /// <summary>
        /// Returns all services
        /// </summary>
        /// <returns>List all services</returns>
        IEnumerable<Service> GetServices();

        /// <summary>
        /// Returns service that match with input parameter
        /// </summary>
        /// <param name="serviceId">Service id</param>
        /// <returns>Service entity</returns>
        Service GetServiceById(int serviceId);

        /// <summary>
        /// Adds new service to database
        /// </summary>
        /// <param name="service">service which will be insert</param>
        void AddService(Service service);

        /// <summary>
        /// udpate existing service in database
        /// </summary>
        /// <param name="service">service which have new values</param>
        /// <returns>updated service entity</returns>
        Service UpdateService(Service service);
    }
}

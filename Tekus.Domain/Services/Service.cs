using Newtonsoft.Json;
using System.Collections.Generic;
using Tekus.Domain.Countries;
using Tekus.Domain.Customers;

namespace Tekus.Domain.Services
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Country> Countries { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using Tekus.Domain.Services;

namespace Tekus.Domain.Countries
{
    public class Country
    {
        public Country()
        {
            this.Services = new HashSet<Service>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Service> Services { get; set; }
    }
}

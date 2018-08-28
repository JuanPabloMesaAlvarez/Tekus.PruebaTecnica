using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tekus.Domain.Services;

namespace Tekus.Domain.Countries
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}

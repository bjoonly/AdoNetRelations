using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdoNetRelationships
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Flight> FlightsTo { get; set; }
        public virtual ICollection<Flight> FlightsFrom { get; set; }
    }
}
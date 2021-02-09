
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdoNetRelationships
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassengers { get; set; }

   
        public int TypeId { get; set; }
        public int? CountryId { get; set; }

      
        public virtual Country Country { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
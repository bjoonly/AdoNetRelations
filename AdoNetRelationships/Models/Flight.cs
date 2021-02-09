using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdoNetRelationships
{
    public class Flight
    {
        [Key]
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }

        
        public int AirplaneId { get; set; }
        public int CityFromId { get; set; }
        public int CityToId { get; set; }

  
        public virtual City CityFrom { get; set; }
        public virtual City CityTo { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
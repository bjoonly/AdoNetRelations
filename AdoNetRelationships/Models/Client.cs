using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdoNetRelationships
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; }


        public int? AccountId { get; set; }

       
        public virtual Account Account { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
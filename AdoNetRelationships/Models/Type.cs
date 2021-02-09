using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdoNetRelationships
{
    public class Type
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

     
        public virtual ICollection<Airplane> Airplanes { get; set; }
    }
}
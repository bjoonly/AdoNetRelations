using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetRelationships
{
    public class Account
    {
        [Key, ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }


        public virtual Client Client { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.Data.Entities
{
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual IEnumerable<Player> Players { get; set; }

    }
}

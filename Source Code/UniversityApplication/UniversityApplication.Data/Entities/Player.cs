using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.Data.Entities
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime DOB { get; set; }
        public int Rank { get; set; }
        public int TotalGoals { get; set; }
        [ForeignKey("ClubId")]
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}

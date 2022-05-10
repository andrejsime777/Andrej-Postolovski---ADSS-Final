using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.Models.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? SigningDate { get; set; }
        public DateTime? DOB { get; set; }
        public int Rank { get; set; }
        public int TotalGoals { get; set; }
        public int ClubId { get; set; }
        public virtual ClubDTO Club { get; set; }

    }
}

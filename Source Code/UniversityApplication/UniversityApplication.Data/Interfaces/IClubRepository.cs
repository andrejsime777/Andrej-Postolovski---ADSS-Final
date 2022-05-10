using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;

namespace UniversityApplication.Data.Interfaces
{
    public interface IClubRepository
    {
        IEnumerable<Club> GetClubs();
        Club GetClubById(int id);
        void AddClub(Club newClub);
        void UpdateClub(Club oldClub, Club Clubs);
        bool DeleteClub(Club Club);
    }
}

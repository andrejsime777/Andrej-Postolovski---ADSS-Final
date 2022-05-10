using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;

namespace UniversityApplication.Service.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDTO> GetClubs();
        ClubDTO GetClubById(int id);
        Club AddClub(Club Club);
        Club UpdateClub(Club Club);
        bool DeleteClub(int id);


    }
}

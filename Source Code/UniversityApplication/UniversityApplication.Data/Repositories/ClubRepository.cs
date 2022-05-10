using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;
using UniversityApplication.Data.Interfaces;

namespace UniversityApplication.Data.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly UniversityDataContext _dataContext;

        public ClubRepository(UniversityDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Club GetClubById(int id)
        {
            return _dataContext.Clubs.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Club> GetClubs()
        {
            return _dataContext.Clubs.ToList();
        }
        public void AddClub(Club newClub)
        {
            _dataContext.Clubs.Add(newClub);
            Save();
        }

        public bool DeleteClub(Club Club)
        {
            try
            {
                _dataContext.Clubs.Remove(Club);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateClub(Club oldClub, Club newClubs)
        {
            _dataContext.Entry(oldClub).CurrentValues.SetValues(newClubs);
            Save();
        }

        public void Save()
        {
            _dataContext.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;
using UniversityApplication.Data.Interfaces;

namespace UniversityApplication.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly UniversityDataContext _dataContext;

        public PlayerRepository(UniversityDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddPlayer(Player newPlayer)
        {
            _dataContext.Players.Add(newPlayer);
            Save();
        }

        public bool DeletePlayer(Player Player)
        {
            try
            {
                _dataContext.Players.Remove(Player);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Player GetPlayerById(int id)
        {
            return _dataContext.Players.Include(s => s.Club).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _dataContext.Players.Include(s => s.Club);
        }

        public void UpdatePlayer(Player oldStuden, Player newPlayers)
        {
            _dataContext.Entry(oldStuden).CurrentValues.SetValues(newPlayers);
            Save();
        }

        public void Save()
        {
            _dataContext.SaveChangesAsync();
        }
    }
}

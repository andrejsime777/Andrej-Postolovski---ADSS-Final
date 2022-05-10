using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;

namespace UniversityApplication.Data.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerById(int id);
        void AddPlayer(Player Player);
        void UpdatePlayer(Player oldStuden, Player Players);
        bool DeletePlayer(Player Player);

    }
}

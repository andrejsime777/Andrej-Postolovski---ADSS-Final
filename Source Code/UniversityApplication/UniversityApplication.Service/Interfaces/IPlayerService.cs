using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;

namespace UniversityApplication.Service.Interfaces
{
    public interface IPlayerService
    {
        List<PlayerDTO> GetPlayers();
        PlayerDTO GetPlayerById(int id);
        PlayerDTO AddPlayer(PlayerDTO Player);
        PlayerDTO UpdatePlayer(PlayerDTO Player);
        bool DeletePlayer(int id);
    }
}

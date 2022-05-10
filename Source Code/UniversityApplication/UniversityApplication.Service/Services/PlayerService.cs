using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;
using UniversityApplication.Service.Interfaces;
using AutoMapper;
using UniversityApplication.Data.Interfaces;

namespace UniversityApplication.Service.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _PlayerRepository;

        public PlayerService(IPlayerRepository PlayerRepository, IMapper mapper)
        {
            _PlayerRepository = PlayerRepository;
            _mapper = mapper;
        }

        public List<PlayerDTO> GetPlayers()
        {
            //1. Entities
            //return await _dataContext.Players.ToListAsync();

            //2. DTOs
            //return _dataContext.Players.Select(x => new PlayerDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    DOB = x.DOB,
            //    EnrollmentDate = x.EnrollmentDate,
            //    PlayerIndex = x.PlayerIndex,
            //    GPA = x.GPA,
            //    Mail = x.Mail,
            //    ClubId = x.ClubId,
            //    Club = new ClubDTO
            //    {
            //        Id = x.Club.Id,
            //        Street = x.Club.Street,
            //        City = x.Club.City,
            //        Country = x.Club.Country
            //    }
            //}).ToList();

            //3. AutoMapper DTOs
            var Players = _PlayerRepository.GetPlayers();
            return _mapper.Map<List<PlayerDTO>>(Players);
        }

        public PlayerDTO GetPlayerById(int id)
        {
            //Would cause circular dependency error, so we need DTOs
            //return await _dataContext.Players.Include(s => s.Club).FirstOrDefaultAsync(x => x.Id == id);

            var Player = _PlayerRepository.GetPlayerById(id);
            return _mapper.Map<PlayerDTO>(Player);
        }

        public PlayerDTO AddPlayer(PlayerDTO Player)
        {
            Player newPlayer = _mapper.Map<Player>(Player);

            if (_PlayerRepository.GetPlayerById(Player.Id) == null)
            {
                _PlayerRepository.AddPlayer(newPlayer);
            }
            return _mapper.Map<PlayerDTO>(newPlayer);
        }

        public PlayerDTO UpdatePlayer(PlayerDTO Player)
        {
            Player newPlayer = _mapper.Map<Player>(Player);
            Player oldPlayer = _PlayerRepository.GetPlayerById(newPlayer.Id);

            if (oldPlayer != null)
            {
                _PlayerRepository.UpdatePlayer(oldPlayer, newPlayer);
            }
            return _mapper.Map<PlayerDTO>(newPlayer);
        }

        public bool DeletePlayer(int id)
        {
            var PlayerEntity = _PlayerRepository.GetPlayerById(id);

            /* If we want to delete the Club associated with the current Player (in 1-to-1 relations) we should:
            //1. First retrieve the Club associated with the current Player ClubId
            var ClubEntity = await _dataContext.Clubs.FindAsync(PlayerEntity.ClubId);
            
            //2. Then delete all Players associated with the current ClubId
            var PlayersWithClub = await _dataContext.Players.Where(s => s.Id == PlayerEntity.Club.Id).ToListAsync();
            foreach(var Player in PlayersWithClub)
            {
                _dataContext.Players.Remove(Player);
            }

            //2. Then delete the Club associated with those Players
            _dataContext.Clubs.Remove(ClubEntity);
            */

            //If we want to remove only the Player without the associated Club (for 1-to-m relations) as in our case 1 Club - many Players, we should remove the Player only

            return _PlayerRepository.DeletePlayer(PlayerEntity);
        }
    }
}

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
    public class ClubService : IClubService
    {
        private readonly IMapper _mapper;
        private readonly IClubRepository _ClubRepository;

        public ClubService(IClubRepository ClubRepository, IMapper mapper)
        {
            _ClubRepository = ClubRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClubDTO> GetClubs()
        {

            //3. AutoMapper DTOs
            var Clubs = _ClubRepository.GetClubs();
            return _mapper.Map<List<ClubDTO>>(Clubs);
        }

        public ClubDTO GetClubById(int id)
        { 

            var Club = _ClubRepository.GetClubById(id);
            return _mapper.Map<ClubDTO>(Club);
        }

        public Club AddClub(Club Club)
        {
            Club newClub = _mapper.Map<Club>(Club);

            if (_ClubRepository.GetClubById(Club.Id) == null)
            {
                _ClubRepository.AddClub(newClub);
            }
            return _mapper.Map<Club>(newClub);
        }

        public Club UpdateClub(Club Club)
        {
            Club newClub = _mapper.Map<Club>(Club);
            Club oldClub = _ClubRepository.GetClubById(newClub.Id);

            if (oldClub != null)
            {
                _ClubRepository.UpdateClub(oldClub, newClub);
            }
            return _mapper.Map<Club>(newClub);
        }

        public bool DeleteClub(int id)
        {
            var ClubEntity = _ClubRepository.GetClubById(id);

            return _ClubRepository.DeleteClub(ClubEntity);
        }
    }
}

using AutoMapper;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;

namespace UniversityApplication.Models.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDTO>()
                .ReverseMap();
        }
    }
}

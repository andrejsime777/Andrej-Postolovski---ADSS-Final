using AutoMapper;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;

namespace UniversityApplication.Models.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubDTO>()
                .ReverseMap();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;
using UniversityApplication.Service.Interfaces;

namespace UniversityApplication.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _ClubService;
        private readonly ILogger<ClubController> _logger;

        public ClubController(ILogger<ClubController> logger, IClubService ClubService)
        {
            _ClubService = ClubService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllClubs")]
        public IEnumerable<ClubDTO> GetClubs()
        {
            var Clubs = _ClubService.GetClubs();

            return Clubs;
        }

        [HttpGet]
        [Route("GetClubById")]
        public IActionResult GetClubById(int id)
        {
            ClubDTO Club = _ClubService.GetClubById(id);

            if (Club == null)
            {
                return NotFound("Club with that id does not exist!");
            }

            return Ok(Club);
        }
    }
}

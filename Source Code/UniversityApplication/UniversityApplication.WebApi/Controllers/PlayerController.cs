using Microsoft.AspNetCore.Mvc;
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
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _PlayerService;

        public PlayerController(IPlayerService PlayerService)
        {
            _PlayerService = PlayerService;
        }

        [HttpGet]
        [Route("GetAllPlayers")]
        public IEnumerable<PlayerDTO> GetPlayers()
        {
            var Player = _PlayerService.GetPlayers();

            return Player;
        }

        [HttpGet]
        [Route("GetPlayerById")]
        public IActionResult GetPlayerById(int id)
        {
            PlayerDTO Player = _PlayerService.GetPlayerById(id);

            if (Player == null)
            {
                return NotFound("Player with that id does not exist!");
            }

            return Ok(Player);
        }

        [HttpDelete("RemovePlayer/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(_PlayerService.DeletePlayer(id));
            }
            return BadRequest();
        }

        [HttpPost("AddPlayer")]
        public IActionResult Post([FromBody] PlayerDTO Player)
        {
            if (ModelState.IsValid)
            {
                var newPlayer = _PlayerService.AddPlayer(Player);
                return Created($"Player with id {newPlayer.Id} is created", newPlayer.Id);
            }

            return UnprocessableEntity(ModelState);
        }

        [HttpPut("UpdatePlayer/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] PlayerDTO Player)
        {
            if (ModelState.IsValid)
            {
                Player.Id = id;
                var result = _PlayerService.UpdatePlayer(Player);

                return result != null
                    ? Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }
    }
}

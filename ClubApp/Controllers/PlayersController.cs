using AutoMapper;
using ClubApp.DTOs.Players;
using ClubApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubApp.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayersController(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        [HttpGet("getPlayers")]
        public IActionResult GetPlayers()
        {
            var players = _playerRepository.GetPlayers();
            if (players == null || players.Count == 0)
            {
                return NotFound("No players found.");
            }
            var playerDtos = _mapper.Map<ICollection<PlayerDto>>(players);
            return Ok(playerDtos);
        }

        [HttpGet("addPlayersToDb")]
        public IActionResult AddPlayersDb()
        {
            var addingPlayers = _playerRepository.AddPlayersDb();
            if (addingPlayers)
            {
                return Ok("Done");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}

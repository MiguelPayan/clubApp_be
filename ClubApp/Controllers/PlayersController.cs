using AutoMapper;
using ClubApp.Models.DTOs.Players;
using ClubApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet("Players/GetAll")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPlayers()
        {
            var player = _playerRepository.GetPlayers();
            var playerDto = _mapper.Map<ICollection<PlayerDto>>(player);
            return Ok(playerDto);
        }

        [HttpGet("Players/GetById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPlayerById(int id)
        {
            var player = _playerRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            var playerDto = _mapper.Map<PlayerDto>(player);
            return Ok(playerDto);
        }

        [HttpGet("Players/GetByName")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPlayerByName(string playerName)
        {
            var player = _playerRepository.GetPlayersByName(playerName);
            if (player == null)
            {
                return NotFound();
            }
            var playerDto = _mapper.Map<ICollection<PlayerDto>>(player);
            return Ok(playerDto);
        }


    }
}

using AutoMapper;
using ClubApp.Models.DTOs.Players;
using ClubApp.Models.DTOs.Users;
using ClubApp.Repositories;
using ClubApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubApp.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Users/Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RegisterUser(RegisterUserDTO newUser)
        {
            bool result = _userRepository.Register(newUser);

            if (!result)
            {
                return BadRequest("User already exists.");
            };
            return Ok("User registered successfully.");
        }

        [HttpPost("Users/Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string LoginUser(LoginDTO user)
        {
            string result = _userRepository.Login(user);

            if (result.Equals(string.Empty))
            {
                return ("Invalid credentials");
            }
            ;
            return (result);
        }
    }
}

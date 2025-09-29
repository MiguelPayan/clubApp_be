using ClubApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClubApp.Models.DTOs.Users;
using ClubApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using Azure.Core;

namespace ClubApp.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ClubAppsContext _context;
        private readonly IConfiguration _config;

        public UserRepository(ClubAppsContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }
        public string Login(LoginDTO userRequest)
        {
            var user = _context.Users.SingleOrDefault(u => u.Name == userRequest.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userRequest.Password, user.PasswordHash))
                return string.Empty;
            var token = GenerateJwtToken(user);
            return token;
        }

        public bool Register(RegisterUserDTO newUser)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
                return false;

            var user = new User
            {
                Email = newUser.Email,
                Name = newUser.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim("id", user.Id.ToString()),
            new Claim("name", user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

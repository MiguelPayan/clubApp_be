using ClubApp.Models;
using ClubApp.Models.DTOs.Users;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClubApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool Register(RegisterUserDTO newUser);
        string Login(LoginDTO user);
    }
}

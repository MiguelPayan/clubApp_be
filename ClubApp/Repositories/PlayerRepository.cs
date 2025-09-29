using System.Linq.Expressions;
using System.Text.Json;
using System.Text.RegularExpressions;
using AutoMapper;
using ClubApp.Models;
using ClubApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        private readonly ClubAppsContext _clubAppsContext;

        public PlayerRepository( IWebHostEnvironment env, IMapper mapper, ClubAppsContext clubAppsContext)
        {
            _env = env;
            _mapper = mapper;
            _clubAppsContext = clubAppsContext;
        }

        public Player GetPlayerById(int id)
        {
            return _clubAppsContext.Players.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Player> GetPlayers()
        {
            return _clubAppsContext.Players.ToList();
        }

        public ICollection<Player> GetPlayersByName(string playerName)
        {
            return _clubAppsContext.Players.Where(P => P.Playername.Contains(playerName)).ToList();
        }
    }
}

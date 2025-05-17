using System.Text.Json;
using System.Text.RegularExpressions;
using AutoMapper;
using ClubApp.DTOs.Players;
using ClubApp.Models;
using ClubApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IWebHostEnvironment _env;
        private readonly ClubAppsContext _context;
        private readonly IMapper _mapper;

        public PlayerRepository(ClubAppsContext context, IWebHostEnvironment env, IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }
        private ICollection<AddingFixedPlayersDTO> FixStatsType(ICollection<AddingPlayersDTO> playersBad)
        {
            ICollection<AddingFixedPlayersDTO> playersGood = new List<AddingFixedPlayersDTO>();
            foreach (var item in playersBad)
            {
                Console.WriteLine(item.MarketValue!.Substring(1, item.MarketValue.Length - 2));
                double marketValue; 
                if(item.MarketValue.Contains("M") || item.MarketValue.Contains("K"))
                {
                    marketValue = double.Parse(item.MarketValue!.Substring(1,item.MarketValue.Length - 2));
                }
                else
                {
                    marketValue = double.Parse(item.MarketValue!.Substring(1, item.MarketValue.Length - 1));
                }

                if (marketValue == 0)
                {
                    marketValue = 5;
                }
                if (item.MarketValue.Contains("K"))
                {
                    marketValue /= 1000;
                }
                playersGood.Add(new AddingFixedPlayersDTO
                {
                    PhotoSrc = item.PhotoSrc,
                    Playername = item.Playername,
                    Age = item.Age,
                    OriginalTeam = item.OriginalTeam,
                    OverallRating = item.OverallRating,
                    Potential = int.Parse(item.Potential!),
                    MarketValue = marketValue,
                    Shooting = item.Shooting,
                    Dribling = item.Dribling,
                    Pace = item.Pace,
                    Strenght = item.Strenght,
                    Interceptions = item.Interceptions,
                    DefensiveAwareness = item.DefensiveAwareness,
                    Reflects = item.Reflects,
                    ReleaseClause = item.ReleaseClause,
                    PositionX = item.PositionX,
                    PositionY = item.PositionY,
                    IsStarting = item.IsStarting
                });
            }
            return playersGood;
        }
        public bool AddPlayersDb()
        {
            try
            {
                var filePath = Path.Combine(_env.WebRootPath, "data", "players.json");
                var json = System.IO.File.ReadAllText(filePath);
                var players = JsonSerializer.Deserialize<ICollection<AddingPlayersDTO>>(json);
                if (players == null)
                {
                    Console.WriteLine("No players");
                    return false;
                }
                var fixedplayers = FixStatsType(players);
                foreach (var playerAdding in fixedplayers)
                {
                    PlayerDto player = _mapper.Map<PlayerDto>(playerAdding);
                    Player playerAdd = _mapper.Map<Player>(player);
                    _context.Players.Add(playerAdd);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public ICollection<Player> GetPlayers()
        {
            return _context.Players.OrderBy(p => p.Playername).ToList();
        }
    }
}

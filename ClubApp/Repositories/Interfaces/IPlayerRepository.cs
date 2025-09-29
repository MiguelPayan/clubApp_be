

using ClubApp.Models;

namespace ClubApp.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetPlayers();
        Player GetPlayerById(int id);

        ICollection<Player> GetPlayersByName(string playerName);
    }
}

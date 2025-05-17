using ClubApp.Models;

namespace ClubApp.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetPlayers();
        bool AddPlayersDb();
    }
}

namespace Exam.Services.Data.Contracts
{
    using System.Linq;
    using Exam.Data.Models;

    public interface IGamesService
    {
        IQueryable<Game> GetPublicGames(int page = 0);

        Game CreateGame(string name, string number, string userId);

        IQueryable<Game> GetGameDetails(int id);

        bool GameCanBeJoinedByUser(int id, string userId);

        string JoinGame(int id, string userId);
    }
}

namespace Exam.Services.Data.Contracts
{
    using System.Linq;
    using Exam.Data.Models;

    public interface IGamesService
    {
        IQueryable<Game> GetPublicGames(int page = 0);

        Game CreateGame(string name, string number, string userId);
    }
}

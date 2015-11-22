namespace Exam.Services.Data
{
    using System.Linq;
    using Exam.Data.Models;
    using Contracts;
    using Exam.Data.Repositories;
    using Common.Constants;
    using System;

    public class GamesService : IGamesService
    {
        private IRepository<Game> games;

        public GamesService(IRepository<Game> games)
        {
            this.games = games;
        }

        public IQueryable<Game> GetPublicGames(int page = 1)
        {
            return this.games
                .All()
                .OrderBy(g => g.DateCreated)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage);
        }

        public Game CreateGame(string name, string number, string userId)
        {
            var newGame = new Game
            {
                Name = name,
                RedUserId = userId,
                DateCreated = DateTime.UtcNow,
            };

            this.games.Add(newGame);
            this.games.SaveChanges();

            return newGame;
        }

        // Some additional helpers
        public IQueryable<Game> GetFollowingGames(int page = 1)
        {
            return this.games
                .All()
                .Where(g => g.DateCreated >= DateTime.Now)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage);
        }

        private IQueryable<Game> GetPreviousGames(int page = 1)
        {
            return this.games
                .All()
                .OrderBy(g => g.DateCreated)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage);
        }

        private IQueryable<Game> GetFollowingGames()
        {
            return GetAll(p => p.DateCreated >= DateTime.Now);
        }

        private IQueryable<Game> GetPreviousGames()
        {
            return GetAll(p => p.DateCreated < DateTime.Now);
        }

        private IQueryable<Game> GetAll(Func<Game, bool> func, int page = 1)
        {
            return this.games
                .All()
                .Where(func)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage)
                .AsQueryable<Game>();
        }
    }
}

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

        public bool GameCanBeJoinedByUser(int id, string userId)
        {
            return !this.games.All().Any(g => g.Id == id && g.RedUser.Id == userId);
        }
             

        public IQueryable<Game> GetGameDetails(int id)
        {
            return this.games.All().Where(g => g.Id == id);
        }

        public string JoinGame(int id, string userId)
        {
            var gameToJoin = this.games.GetById(id);
            gameToJoin.BlueUser.Id = userId;
            this.games.SaveChanges();
            // TODO: game state!

            return gameToJoin.Name;
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

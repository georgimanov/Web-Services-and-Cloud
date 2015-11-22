namespace Exam.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Models.Games;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Validation;
    using AutoMapper;
    using System.Net.Http;
    using System.Net;

    public class GamesController : ApiController
    {
        private IGamesService games;

        public GamesController(IGamesService games)
        {
            this.games = games;
        }

        public IHttpActionResult Get(int page = 1)
        {
            var userId = this.User.Identity.GetUserId();

            var games = this.games.GetPublicGames(page)
                .ProjectTo<PublicGameResponseModel>()
                .ToList();

            return this.Ok(games);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Post(CreateGameRequestModel model)
        {
            var newGame = this.games.CreateGame(
                 model.Name,
                 model.Number,
                 this.User.Identity.GetUserId());

            var gameResult = this.games
                .GetGameDetails(newGame.Id)
                .ProjectTo<PublicGameResponseModel>()
                .FirstOrDefault();

            var location = string.Format("api/games/{0}", newGame.Id);

            return this.Created(location, gameResult);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Put(int id)
        {
            var userId = this.User.Identity.GetUserId();
            if (this.games.GameCanBeJoinedByUser(id, userId))
            {
                return this.BadRequest("Game've already joined the game!");
            }

            return null; 
        }
    }
}
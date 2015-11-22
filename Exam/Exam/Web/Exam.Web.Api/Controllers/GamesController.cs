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
                 model.UserId);

            var gameResult = Mapper.Map<PublicGameResponseModel>(newGame);

            //this.Request.crea

            return this.Ok(gameResult);
        }
    }
}
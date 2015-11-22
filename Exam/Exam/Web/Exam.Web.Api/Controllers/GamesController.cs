namespace Exam.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Models.Games;
    using Microsoft.AspNet.Identity;

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
    }
}